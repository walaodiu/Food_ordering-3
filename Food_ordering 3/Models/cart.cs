using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Food_ordering_3.Models; // or the correct namespace where Product class is defined


public class CartModel
{
	public List<CartItem> CartItems { get; set; }

	public CartModel()
	{
		CartItems = new List<CartItem>();
	}

	public void AddCartItem(CartItem item)
	{
		CartItems.Add(item);
	}

	public void RemoveCartItem(CartItem item)
	{
		CartItems.Remove(item);
	}

	public void ClearCart()
	{
		CartItems.Clear();
	}
}



public class CartItem
{
	public int Id { get; set; }
	public int ProductId { get; set; }
	public int Quantity { get; set; }
	public string UserId { get; set; }
	public decimal Price { get; set; }
	public string ProductName { get; set; }
	public Product Product { get; set; }
	public string ImagePath { get; set; } // Add a reference to the Product entity
}
