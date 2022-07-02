using Microsoft.AspNetCore.Mvc;
using APIContagem.Models;
using APIContagem.Logging;

namespace APIContagem.Controllers;

[ApiController]
[Route("[controller]")]
public class ForceErrorController : ControllerBase
{
    private static readonly Contador _CONTADOR = new Contador();
    private readonly ILogger<ForceErrorController> _logger;

    public ForceErrorController(ILogger<ForceErrorController> logger)
    {
        _logger = logger;
    }

    [HttpGet]
    public HealthStatus Get()
    {
        ApplicationStatus.Healthy = false;
        _logger.LogWarning("Status da aplicação configurado para simulação de erro do tipo 500!");

        return new ()
        {
            Healthy = false,
            Instancia = ApplicationStatus.Local,
            Horario = DateTime.UtcNow.AddHours(-3).ToString("HH:mm:ss")
        };
    }
}