using Microsoft.AspNetCore.Components;
using ShopOnline.Models.Dtos;
using ShopOnline.Web.Services.Contracts;

namespace ShopOnline.Web.Pages
{
	public class ShoppingCartBase: ComponentBase
	{
        [Inject]
        public IShoppingCartService CartService { get; set; }

        public IEnumerable<CartItemDto> CartItems{ get; set; }

        public string ErrorMessage { get; set; }

        protected override async Task OnInitializedAsync()
		{
			try
			{
				CartItems = await CartService.GetAll(1);

			}
			catch (Exception ex)
			{
				ErrorMessage = ex.Message;
			}
		}

	}
}
