namespace Repozytorium.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _4 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Wiadomosc", "TypOferty", c => c.String());
            AddColumn("dbo.Wiadomosc", "IdOferty", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Wiadomosc", "IdOferty");
            DropColumn("dbo.Wiadomosc", "TypOferty");
        }
    }
}
