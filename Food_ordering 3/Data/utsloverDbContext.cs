using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Food_ordering_3.Data
{
	public class utsloverDbContext : IdentityDbContext
	{
		public utsloverDbContext(DbContextOptions<utsloverDbContext> options)
			: base(options)
		{
		}

		public DbSet<CartItem> CartItems { get; set; }
		public DbSet<Product> Product { get; set; }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			// 模型之间的关联配置
			modelBuilder.Entity<CartItem>()
				.HasOne(c => c.Product)
				.WithMany()
				.HasForeignKey(c => c.ProductId);

			base.OnModelCreating(modelBuilder);
		}
	}
}
