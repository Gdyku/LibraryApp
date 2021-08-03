namespace Library.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Books",
                c => new
                    {
                        ID = c.Guid(nullable: false),
                        Title = c.String(),
                        Author = c.String(),
                        Category = c.String(),
                        ReleaseDate = c.DateTime(nullable: false),
                        IsBorrowed = c.Boolean(nullable: false),
                        RentalHistory_ID = c.Guid(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.BooksRentals", t => t.RentalHistory_ID)
                .Index(t => t.RentalHistory_ID);
            
            CreateTable(
                "dbo.BooksRentals",
                c => new
                    {
                        ID = c.Guid(nullable: false),
                        BookID = c.Guid(nullable: false),
                        ClientID = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Clients",
                c => new
                    {
                        ID = c.Guid(nullable: false),
                        Name = c.String(),
                        RentalHistory_ID = c.Guid(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.BooksRentals", t => t.RentalHistory_ID)
                .Index(t => t.RentalHistory_ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Clients", "RentalHistory_ID", "dbo.BooksRentals");
            DropForeignKey("dbo.Books", "RentalHistory_ID", "dbo.BooksRentals");
            DropIndex("dbo.Clients", new[] { "RentalHistory_ID" });
            DropIndex("dbo.Books", new[] { "RentalHistory_ID" });
            DropTable("dbo.Clients");
            DropTable("dbo.BooksRentals");
            DropTable("dbo.Books");
        }
    }
}
