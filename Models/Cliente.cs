using System;
using System.Collections.Generic;

namespace proyectoBD.Models;

public partial class Cliente
{
    public int Id { get; set; }

    public string Nombre { get; set; } = null!;

    public string ApellidoPrimero { get; set; } = null!;

    public string? ApellidoSegundo { get; set; }

    public string Direccion { get; set; } = null!;

    public string Telefono { get; set; } = null!;

    public virtual ICollection<Venta> Venta { get; set; } = new List<Venta>();
}
