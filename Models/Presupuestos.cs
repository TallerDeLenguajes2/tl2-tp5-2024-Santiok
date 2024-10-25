using presupuestoDetalle;

public class Presupuestos
{
    public static double IVA = 0.21;
    private int idPresupuesto;
    private string nombreDestinatario;
    private List<PresupuestosDetalles> detalle;


    //CONSTRUCTOR.
    public Presupuestos(int idPresupuesto, string nombreDestinatario, List<PresupuestosDetalles> detalle)
    {
        this.idPresupuesto = idPresupuesto;
        this.nombreDestinatario = nombreDestinatario;
        this.detalle = detalle;
    }

    public int IdPresupuesto { get => idPresupuesto; set => idPresupuesto = value; }
    public string NombreDestinatario { get => nombreDestinatario; set => nombreDestinatario = value; }
    public List<PresupuestosDetalles> Detalle { get => detalle; set => detalle = value; }

    //Calcular monto.
    public double MontoPresupuesto()
    {
        int total = 0;

        foreach (var det in detalle)
        {
            total = total + det.Producto.Precio*det.Cantidad;
        }
        return total;
    }
    //Calcular monto con iva.
    public double MontoPresupuestoConIva()
    {
        return MontoPresupuesto() + MontoPresupuesto()*IVA;
    }
    //Cantidad de productos.
    public int CantidadProductos()
    {
        int cant = 0;

        foreach (var det in detalle)
        {
            cant = cant + det.Cantidad;
        }
        return cant;
    }
}