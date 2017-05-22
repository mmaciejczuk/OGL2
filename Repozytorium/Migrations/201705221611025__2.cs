namespace Repozytorium.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.CV", "Zaakceptowane", c => c.Boolean(nullable: false));
            AddColumn("dbo.Ogloszenie", "Zaakceptowane", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Ogloszenie", "Zaakceptowane");
            DropColumn("dbo.CV", "Zaakceptowane");
        }
    }
}
