namespace Repozytorium.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _6 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.CV", "KategoriaId", c => c.Int(nullable: false));
            AddColumn("dbo.Kategoria", "CV_Id", c => c.Int());
            CreateIndex("dbo.Kategoria", "CV_Id");
            AddForeignKey("dbo.Kategoria", "CV_Id", "dbo.CV", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Kategoria", "CV_Id", "dbo.CV");
            DropIndex("dbo.Kategoria", new[] { "CV_Id" });
            DropColumn("dbo.Kategoria", "CV_Id");
            DropColumn("dbo.CV", "KategoriaId");
        }
    }
}
