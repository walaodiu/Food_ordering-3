namespace Food_ordering_3.Models
{
	public class inventory
	{
		public int Id { get; set; }
		public int dish_id { get; set; }
		public int quantity { get; set; }
		public DishStatus Status { get; set; }

	}

	public enum DishStatus
	{
		Available,
		OutOfStock
	}
}
