namespace Controladores;
using Microsoft.AspNetCore.Mvc;
using Repositorios;
using Models;

[ApiController]
[Route("[controller]")]
public class ProductoController : ControllerBase
{
    private static ProductoRepository repositorioProducto = new ProductoRepository();
    Producto producto = new Producto();

    [HttpGet("Listar")]
    public ActionResult<List<Producto>> listarProducto()
    {
        return Ok(repositorioProducto.Listar());
    }

    [HttpPut("Modificar/{id}")]
    public ActionResult modificarProducto(int  id, string descripcionProducto, int precio)
    {
        producto.Descripcion = descripcionProducto;
        producto.Precio = precio;
        repositorioProducto.Modificar(id, producto);
        return Ok();
    }

    [HttpGet("Obtener")]
    public ActionResult<Producto> ObtenerProductoPorId(int id)
    {
        producto = repositorioProducto.Obtener(id);
        if (producto.Descripcion == null)
        {
            return NotFound();
        }
        return Ok(producto);
    }

    [HttpPut("Eliminar")]
    public ActionResult eliminarProducto(int id)
    {
        repositorioProducto.Eliminar(id);
        return Ok();
    }
}