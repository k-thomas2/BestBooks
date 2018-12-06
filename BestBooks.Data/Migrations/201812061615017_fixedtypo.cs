namespace BestBooks.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class fixedtypo : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Review",
                c => new
                    {
                        ReviewId = c.Int(nullable: false, identity: true),
                        OwnerId = c.Guid(nullable: false),
                        Title = c.String(nullable: false),
                        Summary = c.String(nullable: false),
                        ReviewContent = c.String(nullable: false),
                        BookId = c.Int(nullable: false),
                        AvgBookRating = c.Decimal(nullable: false, precision: 18, scale: 2),
                        CreatedUtc = c.DateTimeOffset(nullable: false, precision: 7),
                        ModifiedUtc = c.DateTimeOffset(precision: 7),
                    })
                .PrimaryKey(t => t.ReviewId)
                .ForeignKey("dbo.Book", t => t.BookId, cascadeDelete: true)
                .Index(t => t.BookId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Review", "BookId", "dbo.Book");
            DropIndex("dbo.Review", new[] { "BookId" });
            DropTable("dbo.Review");
        }
    }
}
