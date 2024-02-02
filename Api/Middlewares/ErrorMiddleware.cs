using System;
using System.IO;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using Serilog;
using Serilog.Events;
using VolvoFinalProject.Api.Model.Models;

namespace VolvoFinalProject.Api.Middlewares
{
    public class ErrorMiddleware
    {
        private readonly RequestDelegate next;
        private readonly IWebHostEnvironment environment;
        private readonly ILogger<ErrorMiddleware> logger;

        public ErrorMiddleware(RequestDelegate next, IWebHostEnvironment environment, ILogger<ErrorMiddleware> logger)
        {
            this.next = next ?? throw new ArgumentNullException(nameof(next));
            this.environment = environment ?? throw new ArgumentNullException(nameof(environment));
            this.logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await next(context);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(context, ex);
            }
        }

        private async Task HandleExceptionAsync(HttpContext context, Exception ex)
        {
            ErrorViewModel errorViewModel;

            if (ex is FileNotFoundException fileNotFoundException)
            {
                // Tratamento específico para FileNotFoundException
                errorViewModel = new ErrorViewModel(HttpStatusCode.NotFound.ToString(), $"Arquivo não encontrado: {fileNotFoundException.FileName}");
                context.Response.StatusCode = (int)HttpStatusCode.NotFound;
            }
            else if (ex is UnauthorizedAccessException unauthorizedAccessException)
            {
                // Tratamento específico para UnauthorizedAccessException
                errorViewModel = new ErrorViewModel(HttpStatusCode.Forbidden.ToString(), "Acesso não autorizado.");
                context.Response.StatusCode = (int)HttpStatusCode.Forbidden;
            }
            else
            {
                // Tratamento padrão para outras exceções
                if (environment.IsDevelopment() || environment.IsEnvironment("Qa"))
                {
                    errorViewModel = new ErrorViewModel(HttpStatusCode.InternalServerError.ToString(),
                        $"{ex.Message} {ex?.InnerException?.Message}");
                }
                else
                {
                    errorViewModel = new ErrorViewModel(HttpStatusCode.InternalServerError.ToString(),
                        "An internal server error has occurred.");
                }
                context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            }

            // Log the error using ILogger for further analysis.
            LogErrorWithContext(ex, context);

            var result = JsonConvert.SerializeObject(errorViewModel, new JsonSerializerSettings
            {
                ContractResolver = new CamelCasePropertyNamesContractResolver(),
                Formatting = Formatting.Indented
            });

            context.Response.ContentType = "application/json";
            await context.Response.WriteAsync(result);
        }

        private void LogErrorWithContext(Exception? ex, HttpContext context)
        {
            if (ex == null)
            {
                return;
            }

            // Obtém o nível de detalhamento dinâmico configurado
            var logLevel = GetLogLevel();

            // Verifica se o nível de detalhamento permite o log da exceção
            if (logLevel <= LogEventLevel.Error)
            {
                // Adiciona informações do contexto ao log
                Log.ForContext<ErrorMiddleware>()
                   .ForContext("RequestHeaders", context.Request.Headers, destructureObjects: true)
                   .ForContext("RequestHost", context.Request.Host)
                   .Error(ex, "Error processing request");
            }
        }

        private LogEventLevel GetLogLevel()
        {
            // Obter o nível de detalhamento configurado no appsettings.json
            var defaultLogLevel = LogEventLevel.Information;
            var logLevel = logger.IsEnabled(LogLevel.Debug) ? LogEventLevel.Debug : defaultLogLevel;

            return logLevel;
        }
    }
}