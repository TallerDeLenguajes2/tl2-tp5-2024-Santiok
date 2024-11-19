namespace Controladores;
using Microsoft.AspNetCore.Mvc;
using Repositorios;
using Models;

[ApiController]
[Route("api/[controller]")]
public class PresupuestosController : ControllerBase
{
    private readonly PresupuestosRepository _presupuestoRepo;

    public PresupuestosController()
    {
        _presupuestoRepo = new PresupuestosRepository();
    }

    [HttpGet]
    public IActionResult GetPresupuestos()
    {
        var presupuestos = _presupuestoRepo.Listar();
        return Ok(presupuestos);
    }

    [HttpGet("{id}")]
    public IActionResult GetPresupuestoById(int id)
    {
        var presupuesto = _presupuestoRepo.ObtenerPresupuestos(id);
        if (presupuesto == null) return NotFound("Presupuesto no encontrado.");
        return Ok(presupuesto);
    }

    [HttpPost]
    public IActionResult CrearPresupuesto([FromBody] Presupuesto presupuesto)
    {
        _presupuestoRepo.Insertar(presupuesto);
        return CreatedAtAction(nameof(GetPresupuestoById), new { id = presupuesto.IdPresupuesto }, presupuesto);
    }

    [HttpPut("{id}")]
    public IActionResult ModificarPresupuesto(int id, [FromBody] Presupuesto presupuesto)
    {
        _presupuestoRepo.Modificar(id, presupuesto);
        return NoContent();
    }

    [HttpPost("{idPresupuesto}/productos/{idProducto}")]
    public IActionResult AgregarProducto(int idPresupuesto, int idProducto, [FromBody] int cantidad)
    {
        var success = _presupuestoRepo.AgregarProductoYCantidad(idPresupuesto, idProducto, cantidad);
        if (!success) return BadRequest("No se pudo agregar el producto.");
        return NoContent();
    }

    [HttpDelete("{id}")]
    public IActionResult EliminarPresupuesto(int id)
    {
        _presupuestoRepo.Eliminar(id);
        return NoContent();
    }
}
