using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Entities;

namespace Core.Interfaces
{
    public interface IProductRepository
    {
         Task<Product> GetProductIdAsync(int id);

         // Returns a ReadOnly List of Products
         Task<IReadOnlyList<Product>> GetProductsAsync();

         // Returns a ReadOnly List of Brand Names
         Task<IReadOnlyList<ProductBrand>> GetProductBrandsAsync();

         // Returns a ReadOnly List of Product Types
         Task<IReadOnlyList<ProductType>> GetProductTypesAsync();
    }
}