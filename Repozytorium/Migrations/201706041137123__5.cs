namespace Repozytorium.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _5 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Wymaganie", "Ogloszenie_Id", "dbo.Ogloszenie");
            DropIndex("dbo.Wymaganie", new[] { "Ogloszenie_Id" });
            AddColumn("dbo.Ogloszenie", "Wymagania", c => c.String());
            DropTable("dbo.Wymaganie");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Wymaganie",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Tresc = c.String(maxLength: 500),
                        Ogloszenie_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id);
            
            DropColumn("dbo.Ogloszenie", "Wymagania");
            CreateIndex("dbo.Wymaganie", "Ogloszenie_Id");
            AddForeignKey("dbo.Wymaganie", "Ogloszenie_Id", "dbo.Ogloszenie", "Id");
        }
    }
}
