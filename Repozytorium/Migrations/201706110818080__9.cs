namespace Repozytorium.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _9 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Edukacja",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Szkola = c.String(maxLength: 500),
                        Tytul = c.String(maxLength: 72),
                        DataRozpoczecia = c.DateTime(nullable: false),
                        DataZakonczenia = c.DateTime(nullable: false),
                        CVId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.CV", t => t.CVId)
                .Index(t => t.CVId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Edukacja", "CVId", "dbo.CV");
            DropIndex("dbo.Edukacja", new[] { "CVId" });
            DropTable("dbo.Edukacja");
        }
    }
}
