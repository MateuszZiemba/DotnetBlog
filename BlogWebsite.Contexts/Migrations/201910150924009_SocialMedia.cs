namespace BlogWebsite.Core.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SocialMedia : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                        Description = c.String(nullable: false, maxLength: 200),
                        Slug = c.String(nullable: false, maxLength: 200),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Posts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false, maxLength: 500),
                        Description = c.String(nullable: false, maxLength: 500),
                        Text = c.String(nullable: false),
                        Slug = c.String(nullable: false, maxLength: 200),
                        IsPublished = c.Boolean(nullable: false),
                        CreatedOn = c.DateTime(nullable: false),
                        PublishedOn = c.DateTime(nullable: false),
                        ModifiedOn = c.DateTime(nullable: false),
                        Category_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Categories", t => t.Category_Id, cascadeDelete: true)
                .Index(t => t.Category_Id);
            
            CreateTable(
                "dbo.Tags",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                        Description = c.String(nullable: false, maxLength: 200),
                        Slug = c.String(nullable: false, maxLength: 200),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.SocialMedias",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 60),
                        Url = c.String(nullable: false, maxLength: 300),
                        DisplayOrder = c.Int(nullable: false),
                        IsEnabled = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.TagPosts",
                c => new
                    {
                        Tag_Id = c.Int(nullable: false),
                        Post_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Tag_Id, t.Post_Id })
                .ForeignKey("dbo.Tags", t => t.Tag_Id, cascadeDelete: true)
                .ForeignKey("dbo.Posts", t => t.Post_Id, cascadeDelete: true)
                .Index(t => t.Tag_Id)
                .Index(t => t.Post_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.TagPosts", "Post_Id", "dbo.Posts");
            DropForeignKey("dbo.TagPosts", "Tag_Id", "dbo.Tags");
            DropForeignKey("dbo.Posts", "Category_Id", "dbo.Categories");
            DropIndex("dbo.TagPosts", new[] { "Post_Id" });
            DropIndex("dbo.TagPosts", new[] { "Tag_Id" });
            DropIndex("dbo.Posts", new[] { "Category_Id" });
            DropTable("dbo.TagPosts");
            DropTable("dbo.SocialMedias");
            DropTable("dbo.Tags");
            DropTable("dbo.Posts");
            DropTable("dbo.Categories");
        }
    }
}
