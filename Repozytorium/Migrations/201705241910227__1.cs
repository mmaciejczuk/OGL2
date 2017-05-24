namespace Repozytorium.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.CV", "KategoriaId", c => c.Int());
            CreateIndex("dbo.CV", "KategoriaId");
            AddForeignKey("dbo.CV", "KategoriaId", "dbo.Kategoria", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.CV", "KategoriaId", "dbo.Kategoria");
            DropIndex("dbo.CV", new[] { "KategoriaId" });
            DropColumn("dbo.CV", "KategoriaId");
        }
    }
}
