namespace ShopOnline.API.Respositores
{
	public class ShoppingCartRepository : IShoppingCartRepository
	{
		private readonly AppDbContext context;

		public ShoppingCartRepository(AppDbContext context)
        {
			this.context = context;
		}

		private async Task<bool> CartItemExists (int cartId, int productId)
		{
			return await context.CartItems
				.AsNoTracking()
				.AnyAsync(x => x.ProductId == productId && x.CartId == cartId);
		}

        public async Task<CartItem> AddItem(CartItemToAddDto itemToAdd)
		{
			if (await CartItemExists(itemToAdd.CartId, itemToAdd.ProductId) == false)
			{
				var item = await
					(from product in context.Products
					 where product.Id == itemToAdd.ProductId
					 select new CartItem
					 {
						 CartId = itemToAdd.CartId,
						 ProductId = product.Id,
						 Qty = itemToAdd.Qty,
						 Product = product
					 })
					 .FirstOrDefaultAsync();


				if (item != null)
				{
					var result = await context.AddAsync(item);
					await context.SaveChangesAsync();
					return result.Entity;
				}
			}
			return null;
		}

		public async Task<IEnumerable<CartItem>> GetAll(int userId)
		{
			return await context.CartItems
				 .AsNoTracking()
				 .Include(c => c.Product)
				 .Include(c => c.Cart)
				 .Where(c => c.Cart.UserId == userId)
				 .ToListAsync();
		}

		public async Task<CartItem> GetItem(int id)
		{
			return await context.CartItems
				.AsNoTracking()
				.Include(x => x.Cart)
				.Include(x => x.Product)
				.Where(x => x.Id == id)
				.SingleOrDefaultAsync();
		}

		public Task<CartItem> RemoveItem(int id)
		{
			throw new NotImplementedException();
		}
	}
}
