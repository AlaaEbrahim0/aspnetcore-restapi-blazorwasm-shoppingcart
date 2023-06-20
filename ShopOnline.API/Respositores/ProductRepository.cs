using Microsoft.EntityFrameworkCore;
using ShopOnline.API.Data;
using ShopOnline.API.Entites;
using ShopOnline.API.Respositores.Contracts;

namespace ShopOnline.API.Respositores
{
    public class ProductRepository : IProductRepository
    {
        private readonly AppDbContext context;

        public ProductRepository(AppDbContext context)
        {
            this.context = context;
        }

        public async Task<IEnumerable<Product>> GetProducts()
        {
            var products = await context.Products
                .AsNoTracking()
                .Include(p => p.Category)
                .ToListAsync();

            return products;
        }

        public async Task<Product> GetProductById(int id)
        {
            var product = await context.Products
                .FindAsync(id);

            return product;
        }


        public async Task<IEnumerable<Product>> GetProductsByCategoryId(int categoryId)
        {
            var products = await context.Products
                .AsNoTracking()
                .Where(p => p.CategoryId == categoryId)
                .Include(p => p.Category)
                .ToListAsync();

            return products;
        }
    }
}
