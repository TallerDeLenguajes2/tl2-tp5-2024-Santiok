namespace Controladores;
using Microsoft.AspNetCore.Mvc;
using Repositorios;
using Models;

[ApiController]
[Route("[controller]")]
public class PresupuestoController : ControllerBase
{
    private PresupuestosRepository presupuestoRepository = new PresupuestosRepository();
    private ProductoRepository productoRepository = new ProductoRepository();
    private Presupuesto presupuesto = new Presupuesto();

    public PresupuestoController()
    {

    }

    [HttpPost("CargarPresupuesto")]
    public ActionResult cargarPresupuesto(string nombreDestinatario, string fechaCreacion)
    {
        presupuesto.NombreDestinatario = nombreDestinatario;
        presupuesto.FechaCreacion = fechaCreacion;
        presupuestoRepository.Insertar(presupuesto);
        return Created();
    }

}
