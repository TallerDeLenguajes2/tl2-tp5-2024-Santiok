namespace Controladores;
using Microsoft.AspNetCore.Mvc;
using Repositorios;
using Models;

[ApiController]
[Route("[controller]")]
public class ProductosController : ControllerBase
{
    private readonly IRepository<Productos> repo;

    public ProductosController()
    {
        repo = new ProductoRepository();
    }    

    [HttpGet("api/ObtenerProductos")]
    public ActionResult<List<Productos>> GetProductos() {
        try {
            return Ok(repo.Listar());
        } catch (Exception ex) {
            return StatusCode(500, $"ERROR: {ex.Message}");
        }
    }

    [HttpPost("api/AgregarProducto")]
    public ActionResult AgregarProducto(string descripcion, int precio)
    {
        try {
            var nuevoProducto = new Producto(descripcion, precio);
            repo.Insertar(nuevoProducto);
            return Ok($"Se ha agregado el nuevo producto: {descripcion} - ${precio}");
        } catch (Exception ex) {
            return StatusCode(500, $"ERROR: {ex.Message}");
        }
    }

    [HttpPut("api/ModificarProducto/{id}")]
    public ActionResult ModificarProducto(int id, string descripcion)
    {
        try {
            var producto = repo.Obtener(id);
            if (producto.IdProducto == -1)
                throw new Exception($"No se ha encontrado un producto de ID {id}");
                
            producto.Descripcion = descripcion;
            repo.Modificar(id, producto);
            return Ok($"Producto modificado: {descripcion}");
        } catch (Exception ex) {
            return StatusCode(500, $"ERROR: {ex.Message}");
        }
    }
    
}
