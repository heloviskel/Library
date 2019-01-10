namespace MyLibrary.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class DataContext : DbContext
    {
        public DataContext()
            : base("name=DataConnection")
        {
        }

        public virtual DbSet<Book> Books { get; set; }
        public virtual DbSet<Books_Customers> Books_Customers { get; set; }
        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<Auth_Users> Auth_Users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Book>()
                .HasMany(e => e.Books_Customers)
                .WithOptional(e => e.Book)
                .HasForeignKey(e => e.Books_ID);

            modelBuilder.Entity<Customer>()
                .HasMany(e => e.Books_Customers)
                .WithOptional(e => e.Customer)
                .HasForeignKey(e => e.Customers_ID);
        }
    }
}
