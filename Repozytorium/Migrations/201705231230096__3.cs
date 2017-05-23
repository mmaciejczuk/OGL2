namespace Repozytorium.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _3 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Doswiadczenie", "KategoriaId", "dbo.Kategoria");
            DropIndex("dbo.Doswiadczenie", new[] { "KategoriaId" });
            DropColumn("dbo.Doswiadczenie", "KategoriaId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Doswiadczenie", "KategoriaId", c => c.Int(nullable: false));
            CreateIndex("dbo.Doswiadczenie", "KategoriaId");
            AddForeignKey("dbo.Doswiadczenie", "KategoriaId", "dbo.Kategoria", "Id");
        }
    }
}
