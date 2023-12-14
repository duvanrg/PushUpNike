using System;
using System.Collections.Generic;

namespace API.Dtos;

public  class ProductoDto : BaseEntityS
{

    public string Titulo { get; set; } = null!;

    public string Imagen { get; set; } = null!;

    public string CategoriaId { get; set; } = null!;

    public decimal Precio { get; set; }

    // public virtual Categoria Categoria { get; set; } = null!;
}
