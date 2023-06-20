using System.Runtime.CompilerServices;

namespace ShopOnline.API.Extensions
{
    public static class DtoConversions
    {
        public static IEnumerable<ProductDto> ProductToDto(this IEnumerable<Product> products,
                                                IEnumerable<Category> categories)
        {
            return
                (from product in products
                 join category in categories
                 on product.CategoryId equals category.Id
                 select new ProductDto
                 {
                     Id = product.Id,
                     Name = product.Name,
                     CategoryId = product.CategoryId,
                     Description = product.Description,
                     ImageUrl = product.ImageUrl,
                     Qty = product.Qty,
                     Price = product.Price,
                     CategoryName = category.Name
                 });
        }
    }
}
