using System;
using System.Collections.Generic;

namespace BikerStorm.Model;

public partial class Rol
{
    public int IdRol { get; set; }

    public string? Descripcion { get; set; }

    public bool? EsActivo { get; set; }

    public DateTime? FechaRegistro { get; set; }

    public virtual ICollection<RolMan> RolMen { get; set; } = new List<RolMan>();

    public virtual ICollection<Usuario> Usuarios { get; set; } = new List<Usuario>();
}
