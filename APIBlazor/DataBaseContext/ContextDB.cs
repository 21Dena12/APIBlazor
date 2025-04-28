using APIBlazor.Model;
using Microsoft.EntityFrameworkCore;

namespace APIBlazor.DataBaseContext
{
    public class ContextDB : DbContext
    {
        public ContextDB(DbContextOptions options) : base(options) 
        {
            
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Logins>()
                .HasIndex(u => u.Email)
                .IsUnique();
            // Указание типа столбца для свойства Price в Menu
            modelBuilder.Entity<Menu>()
                .Property(m => m.Price)
                .HasColumnType("decimal(18,2)"); // Укажите нужную точность и масштаб

            // Указание типа столбца для свойства TotalAmount в Order
            modelBuilder.Entity<Order>()
                .Property(o => o.TotalAmount)
                .HasColumnType("decimal(18,2)"); // Укажите нужную точность и масштаб
        }
        public DbSet<Users> Users { get; set; }
        public DbSet<Logins> Logins { get; set; }
        public DbSet<Role> Role {  get; set; }
        public DbSet<Menu> Menu { get; set; }
        public DbSet<Order> Order { get; set; }
    }
}
