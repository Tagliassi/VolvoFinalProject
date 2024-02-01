using System;
using System.IO;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
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

            // Log the error using ILogger for further analysis.
            logger.LogError(ex, "Error processing request");

            // Log the error to a file.
            LogErrorToFile(ex);

            var result = JsonConvert.SerializeObject(errorViewModel, new JsonSerializerSettings
            {
                ContractResolver = new CamelCasePropertyNamesContractResolver(),
                Formatting = Formatting.Indented
            });

            context.Response.ContentType = "application/json";
            
            await context.Response.WriteAsync(result);
        }

        private void LogErrorToFile(Exception ex)
        {
            try
            {
                // Caminho do arquivo de log.
                string logFilePath = @"C:\VolvoFinalProject\Api\log.txt";

                // Criando arquivo de log.
                using (StreamWriter writer = File.AppendText(logFilePath))
                {
                    // Registrando as informações de erro no arquivo.
                    writer.WriteLine($"[{DateTime.Now}] {ex.Message}");
                    writer.WriteLine($"StackTrace: {ex.StackTrace}");
                    writer.WriteLine();
                }
            }
            catch (Exception logEx)
            {
                // Se houver um erro ao tentar registrar no arquivo de log, registra o erro no console ou em outro local.
                logger.LogError(logEx, "Error logging to file");
            }
        }
    }
}
