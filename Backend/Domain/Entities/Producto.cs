using System;
using System.Collections.Generic;

namespace Domain.Entities;

public partial class Producto : BaseEntityS
{

    public string Titulo { get; set; } = null!;

    public string Imagen { get; set; } = null!;

    public string CategoriaId { get; set; } = null!;

    public decimal Precio { get; set; }

    public virtual Categoria Categoria { get; set; } = null!;
}
