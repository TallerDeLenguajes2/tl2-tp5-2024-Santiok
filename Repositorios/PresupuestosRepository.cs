using Models;

namespace Repositorios;

public class PresupuestosRepository : IRepository<Presupuestos>
{
    private readonly string cadenaDeConexion = "Data Source=bd/Tienda.db;Cache=Shared";

    //Insertar presupuesto.
    public void Insertar(Presupuestos pres)
    {

    }

    //Modificar un presupuesto.
    public void Modificar(int id, Presupuestos pres)
    {

    }

    //Listar los presupuestos.
    public List<Presupuestos> Listar()
    {

    }

    //Obtener presupuestos.
    public Presupuestos(int id)
    {

    }

    //Eliminar presupuesto.
    public void Eliminar(int id)
    {

    }
}