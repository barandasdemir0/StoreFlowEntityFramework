using Microsoft.EntityFrameworkCore;
using StoreFlowEntityFramework.Entities;

namespace StoreFlowEntityFramework.Context
{
    public class StoreContext:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=BARANPC\\SQLEXPRESS;initial Catalog=StoreFlowEntityFrameworkDB; integrated Security = true; trust server certificate=true;");
        }

        //veritabanı bağlantı adresi yukarıdadır

        //aşağıda ise veritabanına yansıyacak tablolarımızı giriyoruz
       public  DbSet<Category> Categories { get; set; } // tekil olan kısım C# kısmı Çoğul olan kısım Veritabanımıza yansıyacak kısmı
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Activity> Activities { get; set; }
        public DbSet<Todo> Todos { get; set; }
        public DbSet<Message> Messages { get; set; }
    }
}
