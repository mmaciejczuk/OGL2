namespace Repozytorium.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _6 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Ogloszenie", "Firma", c => c.String(nullable: true));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Ogloszenie", "Firma");
        }
    }
}
