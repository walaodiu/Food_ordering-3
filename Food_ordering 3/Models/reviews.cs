namespace Food_ordering_3.Models
{
	public class reviews
	{
		public int Id { get; set; }
		public string user_id { get; set; }
		public string dish_id { get; set; }
		public decimal rating { get; set; }
		public string comment { get; set; }

	}
}
