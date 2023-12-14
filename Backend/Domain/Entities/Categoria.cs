using System;
using System.Collections.Generic;

namespace Domain.Entities;

public  class Categoria : BaseEntityS
{

    public string Nombre { get; set; } = null!;

    public virtual ICollection<Producto> Productos { get; set; } = new List<Producto>();
}
