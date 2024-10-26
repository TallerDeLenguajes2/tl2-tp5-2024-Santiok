namespace Repositorios;
using Microsoft.Data.Sqlite;
using Models;


public class ProductoRepository : IRepository<Productos>
{
    private readonly string connectionString = "Data Source=Db/Tienda.db;Cache=Shared";

    //Inserto un producto.
    public void Insertar(Productos prod)
    {

    }

    //Modifico un producto existente.
    public void Modificar(int id, Productos prod)
    {

    }

    //Listo los productos registrados.
    public List<Productos> Listar()
    {
        return;
    }

    //Elimino un producto.
    void Eliminar(int id)
    {

    }

    //Obtengo detalles del producto.
    public Productos Obtener(int id)
    {
        return;
    }
}