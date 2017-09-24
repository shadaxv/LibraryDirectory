namespace LibraryDirectory.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _4 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.BookModels", "CustomerModel_Id", c => c.Int());
            CreateIndex("dbo.BookModels", "CustomerModel_Id");
            CreateIndex("dbo.LentBooksModels", "CustomerId");
            CreateIndex("dbo.LentBooksModels", "BookId");
            CreateIndex("dbo.HistoryOfLendingModels", "CustomerId");
            CreateIndex("dbo.HistoryOfLendingModels", "BookId");
            CreateIndex("dbo.HistoryOfLendingModels", "UniqueBookId");
            AddForeignKey("dbo.LentBooksModels", "BookId", "dbo.BookModels", "Id", cascadeDelete: true);
            AddForeignKey("dbo.BookModels", "CustomerModel_Id", "dbo.CustomerModels", "Id");
            AddForeignKey("dbo.HistoryOfLendingModels", "BookId", "dbo.BookModels", "Id", cascadeDelete: true);
            AddForeignKey("dbo.HistoryOfLendingModels", "CustomerId", "dbo.CustomerModels", "Id", cascadeDelete: true);
            AddForeignKey("dbo.HistoryOfLendingModels", "UniqueBookId", "dbo.LentBooksModels", "Id", cascadeDelete: false);
            AddForeignKey("dbo.LentBooksModels", "CustomerId", "dbo.CustomerModels", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.LentBooksModels", "CustomerId", "dbo.CustomerModels");
            DropForeignKey("dbo.HistoryOfLendingModels", "UniqueBookId", "dbo.LentBooksModels");
            DropForeignKey("dbo.HistoryOfLendingModels", "CustomerId", "dbo.CustomerModels");
            DropForeignKey("dbo.HistoryOfLendingModels", "BookId", "dbo.BookModels");
            DropForeignKey("dbo.BookModels", "CustomerModel_Id", "dbo.CustomerModels");
            DropForeignKey("dbo.LentBooksModels", "BookId", "dbo.BookModels");
            DropIndex("dbo.HistoryOfLendingModels", new[] { "UniqueBookId" });
            DropIndex("dbo.HistoryOfLendingModels", new[] { "BookId" });
            DropIndex("dbo.HistoryOfLendingModels", new[] { "CustomerId" });
            DropIndex("dbo.LentBooksModels", new[] { "BookId" });
            DropIndex("dbo.LentBooksModels", new[] { "CustomerId" });
            DropIndex("dbo.BookModels", new[] { "CustomerModel_Id" });
            DropColumn("dbo.BookModels", "CustomerModel_Id");
        }
    }
}
