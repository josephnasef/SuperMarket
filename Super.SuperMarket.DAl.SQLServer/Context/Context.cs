namespace Super.SuperMarket.DAl.SQLServer.Context
{
    using Super.SuperMarket.DAl.SQLServer.Migrations;
    using Super.SuperMarket.DAl.SQLServer.Model;
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class Context : DbContext
    {

        public Context()
            : base("name=Context")
        {
        }


        public virtual DbSet<Product> Product { get; set; }
        public virtual DbSet<Category> Category { get; set; }
        public virtual DbSet<Operation> Operation { get; set; }
        public virtual DbSet<AppUser> AppUser { get; set; }
        public virtual DbSet<PaymentMethod> PaymentMethod { get; set; }
        public virtual DbSet<Role> Role { get; set; }
        public virtual DbSet<Supplier> Supplier { get; set; }
        public virtual DbSet<Bill> Bill { get; set; }
        public virtual DbSet<OperationType> OperationType { get; set; }
        public virtual DbSet<BankAccount> BankAccount { get; set; }
        public virtual DbSet<ShippingDetails> ShippingDetail { get; set; }
        public virtual DbSet<CartLine> CartLine { get; set; }

    }



}