using System;
using System.Collections.Generic;

namespace API.Dtos;

public  class CategoriaDto : BaseEntityS
{

    public string Nombre { get; set; } = null!;

    // public virtual ICollection<Producto> Productos { get; set; } = new List<Producto>();
}
