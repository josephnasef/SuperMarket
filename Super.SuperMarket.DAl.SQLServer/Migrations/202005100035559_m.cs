namespace Super.SuperMarket.DAl.SQLServer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class m : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.PaymentMethods", "Descreption", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.PaymentMethods", "Descreption");
        }
    }
}
