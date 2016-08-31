namespace playbootstrap.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addgoods : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Goods",
                c => new
                    {
                        GoodsId = c.Guid(nullable: false),
                        GoodsName = c.String(),
                        Thumbnail = c.String(),
                        BannerUrl = c.String(),
                        Description = c.String(),
                        GoodsKind = c.String(),
                        GoodsBreed = c.String(),
                        GoodsProduce = c.String(),
                        GoodsGrade = c.String(),
                        GoodsLabels = c.String(),
                        GoodsCode = c.String(),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        OriginalPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        PriceUnit = c.String(),
                        OrderUnit = c.String(),
                    })
                .PrimaryKey(t => t.GoodsId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Goods");
        }
    }
}
