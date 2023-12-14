using System;
using System.Collections.Generic;
using Application.Repository;
using Domain.Data;
using Domain.Interfaces;

namespace Domain.Entities;

public class CategoriaRepository : GenericRepository<Categoria>, ICategoria
{
        private readonly ApiContext _context;
    public CategoriaRepository(ApiContext context) : base(context)
    {
            _context = context;
    }
}
