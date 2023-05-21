using Food_ordering_3.Data;
using Microsoft.AspNetCore.Mvc;
using Food_ordering_3.Models;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;



namespace Food_ordering_3.Controllers
{
	public class CartController : Controller
	{
		private readonly utsloverDbContext _dbContext;

		public CartController(utsloverDbContext dbContext)
		{
			_dbContext = dbContext;
		}

		public IActionResult Cart()
		{
			var cartModel = new CartModel();

			// 从数据库加载购物车项到 cartModel.CartItems
			cartModel.CartItems = _dbContext.CartItems
				.Include(item => item.Product)
				.ToList();

			if (cartModel.CartItems == null)
			{
				cartModel.CartItems = new List<CartItem>();
			}

			return View(cartModel.CartItems);
		}

		public IActionResult AddToCart(int productId, decimal Price, string ProductName , string ImagePath)
		{
			// 创建购物车项
			var cartItem = new CartItem
			{
				ProductId = productId,
				Quantity = 1,
				Price = Price,
				ProductName = ProductName,
				ImagePath = ImagePath,
				UserId = "yourUserId" // 可以是当前登录用户的ID或其他唯一标识符
			};

			// 添加购物车项到数据库
			_dbContext.CartItems.Add(cartItem);
			_dbContext.SaveChanges();

			// 跳转到购物车页面或其他页面
			return RedirectToAction("Cart");
		}
	}
}
