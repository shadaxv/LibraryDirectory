namespace LibraryDirectory.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Third : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.CustomerModels", "FristName", c => c.String(nullable: false));
            AlterColumn("dbo.CustomerModels", "LastName", c => c.String(nullable: false));
            AlterColumn("dbo.CustomerModels", "Mail", c => c.String(nullable: false));
            AlterColumn("dbo.CustomerModels", "Password", c => c.String(nullable: false));
            AlterColumn("dbo.CustomerModels", "Address", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.CustomerModels", "Address", c => c.String(nullable: false, maxLength: 150));
            AlterColumn("dbo.CustomerModels", "Password", c => c.String(maxLength: 50));
            AlterColumn("dbo.CustomerModels", "Mail", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.CustomerModels", "LastName", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.CustomerModels", "FristName", c => c.String(nullable: false, maxLength: 50));
        }
    }
}
