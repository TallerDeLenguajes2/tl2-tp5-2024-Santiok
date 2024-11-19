namespace Models;
public class PresupuestosDetalles
{
    private Producto producto;
    private int cantidad;

    public Producto Producto { get => producto; set => producto = value; }
    public int Cantidad { get => cantidad; set => cantidad = value; }

    //Constructores.
    public PresupuestosDetalles(Producto produ, int cant)
    {
        this.producto = produ;
        this.Cantidad = cant;
    }
}