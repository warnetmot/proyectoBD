using System;
using System.Collections.Generic;

namespace proyectoBD.Models;

public partial class Empleado
{
    public int Id { get; set; }

    public string Nombre { get; set; } = null!;

    public string ApellidoPrimero { get; set; } = null!;

    public string? ApellidoSegundo { get; set; }

    public string Cargo { get; set; } = null!;

    public decimal Salario { get; set; }

    public virtual ICollection<Venta> Venta { get; set; } = new List<Venta>();
}
