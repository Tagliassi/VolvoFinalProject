using System;
using System.ComponentModel;
using System.IO;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
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

            if (ex is DbUpdateConcurrencyException concurrencyException)
            {
                // Tratamento específico para concorrência de dados
                errorViewModel = new ErrorViewModel(HttpStatusCode.Conflict.ToString(), "Concurrency conflict occurred during database update.");
                context.Response.StatusCode = (int)HttpStatusCode.Conflict;
            }
            else if (ex is DbUpdateException dbUpdateException)
            {
                // Tratamento geral para falhas de atualização do banco de dados
                errorViewModel = new ErrorViewModel(HttpStatusCode.InternalServerError.ToString(), "Database update error occurred.");
                context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

                // Registra a exceção para diagnóstico
                logger.LogError(dbUpdateException, "Database update error occurred.");
            }
            else if (ex is FileNotFoundException fileNotFoundException)
            {
                // Tratamento específico para FileNotFoundException
                errorViewModel = new ErrorViewModel(HttpStatusCode.NotFound.ToString(), $"File not found: {fileNotFoundException.FileName}");
                context.Response.StatusCode = (int)HttpStatusCode.NotFound;
            }
            else if (ex is UnauthorizedAccessException unauthorizedAccessException)
            {
                // Tratamento específico para UnauthorizedAccessException
                errorViewModel = new ErrorViewModel(HttpStatusCode.Forbidden.ToString(), "Unauthorized access.");
                context.Response.StatusCode = (int)HttpStatusCode.Forbidden;
            }
            else if (ex is ErrorViewModel errorViewModelException)
            {
                // Tratamento para exceções do tipo ErrorViewModel lançadas pelos repositórios
                errorViewModel = errorViewModelException;
                context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            }
            else if (ex is SqlException sqlException && sqlException.Number == 547)
            {
                // Tratamento para violação de restrição de chave estrangeira
                errorViewModel = new ErrorViewModel(HttpStatusCode.Conflict.ToString(), "Foreign key constraint violation occurred during database operation.");
                context.Response.StatusCode = (int)HttpStatusCode.Conflict;
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

                // Registra a exceção para diagnóstico
                logger.LogError(ex, "Unhandled error occurred.");
            }

            // Loga o erro usando ILogger para análises adicionais.
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

            // Obtém o nível do log da exceção
            var exceptionLogLevel = GetExceptionLogLevel(ex);

            // Verifica se o nível da exceção é igual ou superior ao nível configurado
            if (exceptionLogLevel <= logLevel)
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

        private LogEventLevel GetExceptionLogLevel(Exception ex)
        {
            // Define os níveis de log para diferentes tipos de exceção
            if (ex is DbUpdateException || ex is FileNotFoundException || ex is UnauthorizedAccessException || ex is ErrorViewModel)
            {
                return LogEventLevel.Error;
            }
            else if (ex is WarningException) 
            {
                return LogEventLevel.Warning;
            }
            else
            {
                return LogEventLevel.Information;
            }
        }
    }
}