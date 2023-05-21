using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Food_ordering_3.Pages.Shared
{
	public class cartModel : PageModel
	{
		public List<CartItem> cartItems { get; set; }

        public void OnGet() =>
            // 获取购物车物品列表的逻辑
            cartItems = GetCartItems();

        private List<CartItem> GetCartItems()
		{
			// 在这里实现获取购物车物品列表的逻辑，可以从数据库或会话中获取数据
			// 返回一个包含购物车物品的列表
			return new List<CartItem>();
		}

        private List<CartItem> GetCartItems()
        {
            List<CartItem> cartItems = new List<CartItem>();

            // 在这里实现获取购物车物品列表的逻辑，例如从数据库或会话中获取数据
            // 假设你的购物车物品存储在一个名为 "cartItems" 的会话变量中
            if (HttpContext.Session.TryGetValue("cartItems", out byte[] cartItemsData))
            {
                string cartItemsJson = Encoding.UTF8.GetString(cartItemsData);
                cartItems = JsonConvert.DeserializeObject<List<CartItem>>(cartItemsJson);
            }

            return cartItems;
        }

    }

    public class CartItem
	{
		public string ItemName { get; set; }
		public decimal Price { get; set; }
	}
}
