namespace Store.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class OrderItems : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Items",
                c => new
                    {
                        ItemId = c.Int(nullable: false, identity: true),
                        ItemName = c.String(),
                        OrderId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ItemId)
                .ForeignKey("dbo.Orders", t => t.OrderId, cascadeDelete: true)
                .Index(t => t.OrderId);
            
            CreateTable(
                "dbo.Orders",
                c => new
                    {
                        OrderId = c.Int(nullable: false, identity: true),
                        OrderName = c.String(),
                    })
                .PrimaryKey(t => t.OrderId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Items", "OrderId", "dbo.Orders");
            DropIndex("dbo.Items", new[] { "OrderId" });
            DropTable("dbo.Orders");
            DropTable("dbo.Items");
        }
    }
}
