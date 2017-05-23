namespace Repozytorium.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _2 : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.Doswiadczenie", new[] { "CV_Id" });
            DropColumn("dbo.Doswiadczenie", "CVId");
            RenameColumn(table: "dbo.Doswiadczenie", name: "CV_Id", newName: "CVId");
            AlterColumn("dbo.Doswiadczenie", "CVId", c => c.Int(nullable: false));
            AlterColumn("dbo.Doswiadczenie", "CVId", c => c.Int(nullable: false));
            CreateIndex("dbo.Doswiadczenie", "CVId");
        }
        
        public override void Down()
        {
            DropIndex("dbo.Doswiadczenie", new[] { "CVId" });
            AlterColumn("dbo.Doswiadczenie", "CVId", c => c.Int());
            AlterColumn("dbo.Doswiadczenie", "CVId", c => c.String());
            RenameColumn(table: "dbo.Doswiadczenie", name: "CVId", newName: "CV_Id");
            AddColumn("dbo.Doswiadczenie", "CVId", c => c.String());
            CreateIndex("dbo.Doswiadczenie", "CV_Id");
        }
    }
}
