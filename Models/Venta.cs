using System;
using System.Collections.Generic;

namespace proyectoBD.Models;

public partial class Venta
{
    public int Id { get; set; }

    public DateOnly Fecha { get; set; }

    public int IdCliente { get; set; }

    public int IdEmpleado { get; set; }

    public int IdFormaDePago { get; set; }

    public virtual Cliente IdClienteNavigation { get; set; } = null!;

    public virtual Empleado IdEmpleadoNavigation { get; set; } = null!;

    public virtual FormaDePago IdFormaDePagoNavigation { get; set; } = null!;

    public virtual ICollection<Producto> Productos { get; set; } = new List<Producto>();
}
