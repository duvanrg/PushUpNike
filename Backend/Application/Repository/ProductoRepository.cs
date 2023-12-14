using System;
using System.Collections.Generic;
using Application.Repository;
using Domain.Data;
using Domain.Interfaces;

namespace Domain.Entities;

public class ProductoRepository : GenericRepository<Producto>, IProducto
{
    private readonly ApiContext _context;
    public ProductoRepository(ApiContext context) : base(context)
    {
        _context = context;
    }
}
