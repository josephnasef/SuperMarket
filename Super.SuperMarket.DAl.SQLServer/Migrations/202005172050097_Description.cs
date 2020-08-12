namespace Super.SuperMarket.DAl.SQLServer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Description : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.PaymentMethods", "Description", c => c.String(nullable: false));
            DropColumn("dbo.PaymentMethods", "Descreption");
        }
        
        public override void Down()
        {
            AddColumn("dbo.PaymentMethods", "Descreption", c => c.String(nullable: false));
            DropColumn("dbo.PaymentMethods", "Description");
        }
    }
}
