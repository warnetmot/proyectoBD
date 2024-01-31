using System;
using System.Collections.Generic;

namespace proyectoBD.Models;

public partial class Proveedore
{
    public int Id { get; set; }

    public string Nombre { get; set; } = null!;

    public string ApellidoPrimero { get; set; } = null!;

    public string? ApellidoSegundo { get; set; }

    public string Contacto { get; set; } = null!;

    public string Direccion { get; set; } = null!;

    public int? CantidadPan { get; set; }

    public virtual ICollection<Producto> Productos { get; set; } = new List<Producto>();
}
