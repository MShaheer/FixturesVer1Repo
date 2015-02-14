namespace FixturesVer1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Properties",
                c => new
                    {
                        ID = c.String(nullable: false, maxLength: 128),
                        Name = c.String(),
                        Type = c.String(),
                        Location = c.String(),
                        Accomodates = c.Int(nullable: false),
                        Price = c.Int(nullable: false),
                        RoomType = c.String(),
                        Description = c.String(),
                        Rating = c.Int(nullable: false),
                        Owner = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Reviews",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        PropertyId = c.Int(nullable: false),
                        Body = c.String(),
                        DatePosted = c.DateTime(nullable: false),
                        PostedBy = c.String(),
                       // PropertyName = c.String(),
                        Property_ID = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Properties", t => t.Property_ID)
                .Index(t => t.Property_ID);
            
            CreateTable(
                "dbo.References",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Body = c.String(),
                        PostedBy = c.String(),
                        DatePosted = c.DateTime(nullable: false),
                        User_usr_Username = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Users", t => t.User_usr_Username)
                .Index(t => t.User_usr_Username);
            
            CreateTable(
                "dbo.RequestToBooks",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        usr_Username = c.String(nullable: false, maxLength: 128),
                        usr_Password = c.String(),
                        FirstName = c.String(),
                        LastName = c.String(),
                        Gender = c.String(),
                        BirthDate = c.DateTime(),
                        Email = c.String(),
                        City = c.String(),
                        Country = c.String(),
                        PhoneNumber = c.String(),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.usr_Username);
            
            CreateTable(
                "dbo.WishLists",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        PropertyId = c.Int(nullable: false),
                        usr_Username = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Users", t => t.usr_Username)
                .Index(t => t.usr_Username);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.WishLists", "usr_Username", "dbo.Users");
            DropForeignKey("dbo.References", "User_usr_Username", "dbo.Users");
            DropForeignKey("dbo.Reviews", "Property_ID", "dbo.Properties");
            DropIndex("dbo.WishLists", new[] { "usr_Username" });
            DropIndex("dbo.References", new[] { "User_usr_Username" });
            DropIndex("dbo.Reviews", new[] { "Property_ID" });
            DropTable("dbo.WishLists");
            DropTable("dbo.Users");
            DropTable("dbo.RequestToBooks");
            DropTable("dbo.References");
            DropTable("dbo.Reviews");
            DropTable("dbo.Properties");
        }
    }
}
