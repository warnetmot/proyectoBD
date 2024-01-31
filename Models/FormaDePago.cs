using System;
using System.Collections.Generic;

namespace proyectoBD.Models;

public partial class FormaDePago
{
    public int Id { get; set; }

    public string TipoPago { get; set; } = null!;

    public string Nombre { get; set; } = null!;

    public virtual ICollection<Venta> Venta { get; set; } = new List<Venta>();
}
