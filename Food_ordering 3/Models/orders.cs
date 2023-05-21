namespace Food_ordering_3.Models
{
	public class orders
	{
		public int Id { get; set; }
		public int user_id { get; set; }
		public int dish_id { get; set;}
		public int quantity { get; set; }
		public order_status order_status { get; set; }
		public payment_status payment_status { get; set; }
	}

	public enum order_status
	{
		Pending,
		Completed,
		Cancelled
	}

	public enum payment_status
	{
		Pending,
		Paid
	}
}
