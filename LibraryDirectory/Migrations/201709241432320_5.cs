namespace LibraryDirectory.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _5 : DbMigration
    {
        public override void Up()
        {
            CreateIndex("dbo.CustomerModels", "Mail", unique: true);
        }
        
        public override void Down()
        {
            DropIndex("dbo.CustomerModels", new[] { "Mail" });
        }
    }
}
