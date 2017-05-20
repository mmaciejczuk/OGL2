namespace Repozytorium.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _4 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Wymaganie",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Tresc = c.String(maxLength: 500),
                        Ogloszenie_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Ogloszenie", t => t.Ogloszenie_Id)
                .Index(t => t.Ogloszenie_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Wymaganie", "Ogloszenie_Id", "dbo.Ogloszenie");
            DropIndex("dbo.Wymaganie", new[] { "Ogloszenie_Id" });
            DropTable("dbo.Wymaganie");
        }
    }
}
