using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Entities;
using Core.Specifications;

namespace Core.Interfaces
{
    // This interface can only be used by classes that are derived from the BaseEntity class
    public interface IGenericRepository<T> where T : BaseEntity
    {
        Task<T> GetByIdAsync(int id);  // Replaces - Task<Product> GetProductIdAsync(int id);
         

        Task<IReadOnlyList<T>> ListAllAsync();     // Replaces - Task<IReadOnlyList<Product>> GetProductsAsync();
                                                   // Replaces - Task<IReadOnlyList<ProductBrand>> GetProductBrandsAsync();
                                                   // Replaces - Task<IReadOnlyList<ProductType>> GetProductTypesAsync();

        Task<T> GetEntityWithSpec(ISpecification<T> spec);

        Task<IReadOnlyList<T>> ListAsync(ISpecification<T> spec);
        
        Task<int> CountAsync(ISpecification<T> spec);

        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);

    }
}