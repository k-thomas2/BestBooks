namespace BestBooks.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class comment : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Comment",
                c => new
                    {
                        CommentId = c.Int(nullable: false, identity: true),
                        ReviewId = c.Int(nullable: false),
                        Content = c.String(nullable: false, maxLength: 250),
                        OwnerId = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.CommentId)
                .ForeignKey("dbo.Review", t => t.ReviewId, cascadeDelete: true)
                .Index(t => t.ReviewId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Comment", "ReviewId", "dbo.Review");
            DropIndex("dbo.Comment", new[] { "ReviewId" });
            DropTable("dbo.Comment");
        }
    }
}
