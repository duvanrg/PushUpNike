namespace Domain.Interfaces
{
    public interface IUnitOfWork
    {
        IProducto Productos{get;}
        ICategoria Categorias{get;}
        Task<int> SaveAsync();
    }
}