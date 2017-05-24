namespace Repozytorium.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _11 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Kategoria", "CV_Id", "dbo.CV");
            DropIndex("dbo.Kategoria", new[] { "CV_Id" });
            CreateTable(
                "dbo.KategoriaCV",
                c => new
                    {
                        Kategoria_Id = c.Int(nullable: false),
                        CV_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Kategoria_Id, t.CV_Id })
                .ForeignKey("dbo.Kategoria", t => t.Kategoria_Id, cascadeDelete: true)
                .ForeignKey("dbo.CV", t => t.CV_Id, cascadeDelete: true)
                .Index(t => t.Kategoria_Id)
                .Index(t => t.CV_Id);
            
            AddColumn("dbo.Kategoria", "CVId", c => c.Int(nullable: false));
            DropColumn("dbo.Kategoria", "CV_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Kategoria", "CV_Id", c => c.Int());
            DropForeignKey("dbo.KategoriaCV", "CV_Id", "dbo.CV");
            DropForeignKey("dbo.KategoriaCV", "Kategoria_Id", "dbo.Kategoria");
            DropIndex("dbo.KategoriaCV", new[] { "CV_Id" });
            DropIndex("dbo.KategoriaCV", new[] { "Kategoria_Id" });
            DropColumn("dbo.Kategoria", "CVId");
            DropTable("dbo.KategoriaCV");
            CreateIndex("dbo.Kategoria", "CV_Id");
            AddForeignKey("dbo.Kategoria", "CV_Id", "dbo.CV", "Id");
        }
    }
}
