using System.Net.Mime;
using System.Text.Json;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using APIContagem.Models;

namespace APIContagem.HealthChecks;

public static class HealthChecksExtensions
{
    public static HealthCheckOptions GetJsonReturn()
    {
        return new HealthCheckOptions()
        {
            ResponseWriter = async (context, report) =>
            {
                var result = JsonSerializer.Serialize(
                    new HealthStatus()
                    {
                        Healthy = ApplicationStatus.Healthy,
                        Instancia = ApplicationStatus.Local,
                        Horario = DateTime.UtcNow.AddHours(-3).ToString("HH:mm:ss")
                    });
                context.Response.ContentType = MediaTypeNames.Application.Json;

                // Simulação de falha
                context.Response.StatusCode =
                    ApplicationStatus.Healthy ? StatusCodes.Status200OK : StatusCodes.Status500InternalServerError;

                await context.Response.WriteAsync(result);
            }
        };
    }
}