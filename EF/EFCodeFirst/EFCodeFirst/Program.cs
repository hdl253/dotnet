using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;   

namespace EFCodeFirst
{
    class Program
    {
        static void Main(string[] args)
        {
            Database.SetInitializer<ProductContext>(new DropCreateDatabaseIfModelChanges<ProductContext>());
            using (var db = new ProductContext()){
                var food = db.Categories.Find("FOOD");

                if (food == null)
                {
                    food = new Category { CategoryId = "FOOD", Name = "FOODS" };
                    db.Categories.Add(food);
                }

                Console.WriteLine("Please enter a name for a new food");
                var productName = Console.ReadLine();

                var product = new Product { ProductId=productName,Name = productName, Category = food };
                db.Products.Add(product);

                int recordsAffected = db.SaveChanges();

                Console.WriteLine("Saved {0} entities to database.", recordsAffected);

                var allFoods = from p in db.Products
                               where p.CategoryID == "FOOD"
                               orderby p.Name
                               select p;

                Console.WriteLine("All foods in database:");
                foreach (var item in allFoods)
                {
                    Console.WriteLine(" -{0}", item.Name);
                }

                Console.WriteLine("Press any key to exit");
                Console.ReadKey();
                                
            }
        }
    }

    public class ProductContext : DbContext
    {
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Supplier>()
                .Property(s => s.Name)
                .IsRequired();
        }
    }

    public class Category
    {
        public string CategoryId { get; set; }
        public string Name { get; set; }

        public ICollection<Product> Products { get; set; }
    }

    public class Product
    {
        public string ProductId { get; set; }
        public string Name { get; set; }
        public string CategoryID { get; set; }

        public virtual Category Category { get; set; }
    }

    public class Supplier
    {
        [Key]
        public string SupplierCode { get; set; }
        public string Name { get; set; }
    }
}
