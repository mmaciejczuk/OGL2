namespace Repozytorium.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _3 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Ogloszenie", "ZarobkiOd", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.Ogloszenie", "ZarobkiDo", c => c.Decimal(nullable: false, precision: 18, scale: 2));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Ogloszenie", "ZarobkiDo");
            DropColumn("dbo.Ogloszenie", "ZarobkiOd");
        }
    }
}
