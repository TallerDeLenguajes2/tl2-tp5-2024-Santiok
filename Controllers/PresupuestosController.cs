namespace Controladores;
using Microsoft.AspNetCore.Mvc;
using Repositorios;
using Models;

[ApiController]
[Route("[controller]")]
public class PresupuestoController : ControllerBase
{
    private readonly ILogger<PresupuestoController> _logger;
    private readonly PresupuestosRepository presupuestoRepository;
    public PresupuestoController(ILogger<PresupuestoController> logger)
    {
        _logger = logger;
        presupuestoRepository = new PresupuestosRepository("Data Source=bd/Tienda.db;Cache=Shared");
    }

    [HttpPost("/api/Presupuesto")]
     public ActionResult<Presupuesto> CrearPresupuesto([FromBody] Presupuesto presupuesto)
    {
        bool presupuestoCreado = presupuestoRepository.CrearPresupuesto(presupuesto);
        if (!presupuestoCreado) return BadRequest("No se pudo crear el presupuesto.");
        return Ok("El presupuesto se creo con exito.");
    }

    [HttpGet("/api/presupuesto")]
     public ActionResult<List<Presupuesto>> ListarPresupuesto()
    {
        List<Presupuesto> listaPresupuesto = presupuestoRepository.ListarPresupuestos();
        if (listaPresupuesto is null) return BadRequest("No se pudo completar la accion.");
        return Ok(listaPresupuesto);
    }
}
