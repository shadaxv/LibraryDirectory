namespace LibraryDirectory.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.BookModels",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        BookTitle = c.String(),
                        Description = c.String(),
                        Author = c.String(),
                        ReleaseDate = c.String(),
                        NumberOfPages = c.Int(nullable: false),
                        Cover = c.String(),
                        AvailableBooks = c.Int(nullable: false),
                        AllBooks = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.CustomerModels",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FristName = c.String(nullable: false, maxLength: 50),
                        LastName = c.String(nullable: false, maxLength: 50),
                        Phone = c.Int(nullable: false),
                        Mail = c.String(nullable: false, maxLength: 50),
                        Password = c.Binary(nullable: false, maxLength: 50),
                        Address = c.String(nullable: false, maxLength: 150),
                        CurrentlyLentBooks = c.Int(nullable: false),
                        AllLentBooks = c.Int(nullable: false),
                        Privilege = c.Int(nullable: false),
                        Token = c.String(),
                        IsActive = c.Boolean(nullable: false),
                        LastLogin = c.DateTime(nullable: false),
                        AccountBalance = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.HistoryOfLendingModels",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CustomerId = c.Int(nullable: false),
                        BookId = c.Int(nullable: false),
                        UniqueBookId = c.Int(nullable: false),
                        BookLentOn = c.DateTime(nullable: false),
                        BookReturnedOn = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.LentBooksModels",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CustomerId = c.Int(nullable: false),
                        BookId = c.Int(nullable: false),
                        BookLentOn = c.DateTime(nullable: false),
                        BookMustBeReturnedTo = c.DateTime(nullable: false),
                        BookReturnedOn = c.DateTime(nullable: false),
                        IsBookBorrowed = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.LentBooksModels");
            DropTable("dbo.HistoryOfLendingModels");
            DropTable("dbo.CustomerModels");
            DropTable("dbo.BookModels");
        }
    }
}
