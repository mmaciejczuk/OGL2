namespace Repozytorium.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _2 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Kategoria", "CVId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Kategoria", "CVId", c => c.Int(nullable: false));
        }
    }
}
