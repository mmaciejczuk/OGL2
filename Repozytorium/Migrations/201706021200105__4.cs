namespace Repozytorium.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _4 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Wiadomosc", "Tytul", c => c.String(maxLength: 500));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Wiadomosc", "Tytul", c => c.String(maxLength: 72));
        }
    }
}
