using System;
using System.Collections.Generic;

namespace proyectoBD.Models;

public partial class Producto
{
    public int Id { get; set; }

    public string Nombre { get; set; } = null!;

    public decimal? Precio { get; set; }

    public int Cantidad { get; set; }

    public DateOnly FechaVencimiento { get; set; }

    public int? IdProveedor { get; set; }

    public int? IdCategoria { get; set; }

    public int? IdVentas { get; set; }

    public virtual Categoria? IdCategoriaNavigation { get; set; }

    public virtual Proveedore? IdProveedorNavigation { get; set; }

    public virtual Venta? IdVentasNavigation { get; set; }
}
