using Domain.Data;
using Domain.Entities;
using Domain.Interfaces;

namespace Application.UnitOfWork;
public class UnitOfWork : IUnitOfWork, IDisposable
{
    private readonly ApiContext _context;
    private ProductoRepository _Productos;
    private CategoriaRepository _Categorias;

    public IProducto Productos
    {
        get
        {
            if (_Productos == null) _Productos = new ProductoRepository(_context);
            return _Productos;
        }
    }

    public ICategoria Categorias
    {
        get
        {
            if (_Categorias == null) _Categorias = new CategoriaRepository(_context);
            return _Categorias;
        }
    }

    public UnitOfWork(ApiContext context)
    {
        _context = context;
    }
    public async Task<int> SaveAsync()
    {
        return await _context.SaveChangesAsync();
    }

    public void Dispose()
    {
        _context.Dispose();
    }
}
