namespace Controladores;
using Microsoft.AspNetCore.Mvc;
using Repositorios;
using Models;

[ApiController]
[Route("[controller]")]
public class ProductoController : ControllerBase
{
    private readonly ILogger<ProductoController> _logger;
    private readonly ProductoRepository productoRepository;
    public ProductoController(ILogger<ProductoController> logger)
    {
        _logger = logger;
        productoRepository = new ProductoRepository("Data Source=bd/Tienda.db;Cache=Shared");
    }

    [HttpPost("/api/Producto")]
    public ActionResult<Producto> CrearProducto([FromBody] Producto producto)
    {
        bool productoCreado = productoRepository.CrearProducto(producto);
        if (!productoCreado) return BadRequest("No se pudo crear el producto.");
        return Ok("El producto se creo con exito.");
    }

    [HttpGet("/api/Producto")]
    public ActionResult<List<Producto>> ListarProductos()
    {
        List<Producto> listaProducto = productoRepository.ListarProductos();
        if (listaProducto is null) return BadRequest("No se pudo completar la accion.");
        return Ok(listaProducto);
    }

    [HttpPut("/api/Producto/{Id}")]
    public ActionResult ModificarNombreProducto(int Id, string nuevoNom)
    {
        bool productoModificado = productoRepository.ModificarNombre(Id, nuevoNom);
        if (!productoModificado) return BadRequest("No se pudo completar la accion.");
        return Ok("Se modifico con exito la tarea.");
    }
}