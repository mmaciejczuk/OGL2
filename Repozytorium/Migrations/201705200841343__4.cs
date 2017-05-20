namespace Repozytorium.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _4 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.CV", "KategoriaId", "dbo.Kategoria");
            DropIndex("dbo.CV", new[] { "KategoriaId" });
            AddColumn("dbo.Doswiadczenie", "KategoriaId", c => c.Int(nullable: false));
            CreateIndex("dbo.Doswiadczenie", "KategoriaId");
            AddForeignKey("dbo.Doswiadczenie", "KategoriaId", "dbo.Kategoria", "Id");
            DropColumn("dbo.CV", "KategoriaId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.CV", "KategoriaId", c => c.Int(nullable: false));
            DropForeignKey("dbo.Doswiadczenie", "KategoriaId", "dbo.Kategoria");
            DropIndex("dbo.Doswiadczenie", new[] { "KategoriaId" });
            DropColumn("dbo.Doswiadczenie", "KategoriaId");
            CreateIndex("dbo.CV", "KategoriaId");
            AddForeignKey("dbo.CV", "KategoriaId", "dbo.Kategoria", "Id");
        }
    }
}
