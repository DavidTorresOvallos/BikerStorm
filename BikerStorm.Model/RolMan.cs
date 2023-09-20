using System;
using System.Collections.Generic;

namespace BikerStorm.Model;

public partial class RolMan
{
    public int IdRolMenu { get; set; }

    public int? IdRol { get; set; }

    public int? IdMenu { get; set; }

    public bool? EsActivo { get; set; }

    public DateTime? FechaRegistro { get; set; }

    public virtual Menu? IdMenuNavigation { get; set; }

    public virtual Rol? IdRolNavigation { get; set; }
}
