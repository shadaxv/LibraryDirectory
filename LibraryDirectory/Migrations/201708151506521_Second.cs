namespace LibraryDirectory.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Second : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.CustomerModels", "Password", c => c.String(maxLength: 50));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.CustomerModels", "Password", c => c.Binary(nullable: false, maxLength: 50));
        }
    }
}
