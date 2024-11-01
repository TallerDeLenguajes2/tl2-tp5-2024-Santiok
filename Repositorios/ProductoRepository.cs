namespace Repositorios;
using Microsoft.Data.Sqlite;
using Models;


public class ProductoRepository : IRepository<Productos>
{
    private readonly string cadenaDeConexion = "Data Source=bd/Tienda.db;Cache=Shared";

    //Inserto un producto.
    public void Insertar(Productos prod)
    {
        using(var connection = new SqliteConnection(cadenaDeConexion))
        {
            connection.Open();

            string query = "INSERT INTO Productos (Descripcion, Precio) VALUES ($desc, $precio)";
            SqliteCommand command = new SqliteCommand(query, connection);
            command.Parameters.AddWithValue("$desc", prod.Descripcion);
            command.Parameters.AddWithValue("$precio", prod.Precio);

            connection.Close();
        }
    }

    //Modifico un producto existente.
    public void Modificar(int id, Productos prod)
    {
        using(var connection = new SqliteConnection(cadenaDeConexion))
        {
            connection.Open();

            string query = "UPDATE Productos(Descripcion, Precio) VALUES ($desc, $precio) WHERE idProductos = $id_pasado;";
            SqliteCommand command = new SqliteCommand(query, connection);
            command.Parameters.AddWithValue("$desc", prod.Descripcion);
            command.Parameters.AddWithValue("$precio", prod.Precio);
            command.Parameters.AddWithValue("$id_pasado", prod.IdProducto);

            connection.Close();
        }
    }

    //Listo los productos registrados.
    public List<Productos> Listar()
    {
        List<Productos> listaProd = new List<Productos>();
        using (var connection = new SqliteConnection(cadenaDeConexion))
        {
            connection.Open();

            string query = "SELECT * FROM Productos;";
            SqliteCommand command = new SqliteCommand(query, connection);

            using (SqliteDataReader reader = command.ExecuteReader())
            {
                while(reader.Read())
                {
                    var prod = new Productos();
                    prod.IdProducto = Convert.ToInt32(reader["idProducto"]);
                    prod.Descripcion = reader["Descripcion"].ToString();
                    prod.Precio = Convert.ToInt32(reader["Precio"]);
                    listaProd.Add(prod);
                }
            }
            connection.Close();
        }
        return listaProd;
    }

    //Obtengo detalles del producto.
    public Productos Obtener(int id)
    {
        var prod = new Productos();

        using (var connection = new SqliteConnection(cadenaDeConexion))
        {
            connection.Open();

            string query = "SELECT * FROM Productos WHERE idProductos = $id_pasado;";
            SqliteCommand command = new SqliteCommand(query, connection);
            command.Parameters.AddWithValue("$id_pasado", prod.IdProducto);

            using (SqliteDataReader reader = command.ExecuteReader())
            {
                prod.IdProducto = Convert.ToInt32(reader["idProducto"]);
                prod.Descripcion = reader["Descripcion"].ToString();
                prod.Precio = Convert.ToInt32(reader["Precio"]);
            }

            connection.Close();
        }
        return prod;
    }

//Elimino un producto.
    void IRepository<Productos>.Eliminar(int id)
    {
        using (var connection = new SqliteConnection(cadenaDeConexion))
        {
            connection.Open();

            string query = "DELETE FROM Productos WHERE idProductos = $id_pasado;";
            SqliteCommand command = new SqliteCommand(query, connection);
            command.Parameters.AddWithValue("$id_pasado", id);

            connection.Close();
        }
    }
}