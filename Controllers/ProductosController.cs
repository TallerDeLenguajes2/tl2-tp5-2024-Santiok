namespace Controladores;
using Microsoft.AspNetCore.Mvc;
using Repositorios;
using Models;

[ApiController]
[Route("api/[controller]")]
public class ProductosController : ControllerBase
{
    private readonly ProductoRepository _productoRepo;

    public ProductosController()
    {
        _productoRepo = new ProductoRepository();
    }

    [HttpGet]
    public IActionResult GetProductos()
    {
        var productos = _productoRepo.Listar();
        return Ok(productos);
    }

    [HttpGet("{id}")]
    public IActionResult GetProductoById(int id)
    {
        var producto = _productoRepo.Obtener(id);
        if (producto == null) return NotFound("Producto no encontrado.");
        return Ok(producto);
    }

    [HttpPost]
    public IActionResult CrearProducto([FromBody] Producto producto)
    {
        _productoRepo.Insertar(producto);
        return CreatedAtAction(nameof(GetProductoById), new { id = producto.IdProducto }, producto);
    }

    [HttpPut("{id}")]
    public IActionResult ModificarProducto(int id, [FromBody] Producto producto)
    {
        _productoRepo.Modificar(id, producto);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public IActionResult EliminarProducto(int id)
    {
        _productoRepo.Eliminar(id);
        return NoContent();
    }
}
