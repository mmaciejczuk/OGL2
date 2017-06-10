namespace Repozytorium.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _8 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.CV", "MiastoId", c => c.Int());
            AddColumn("dbo.AspNetUsers", "NazwaMiasta", c => c.String());
            CreateIndex("dbo.CV", "MiastoId");
            AddForeignKey("dbo.CV", "MiastoId", "dbo.Miasto", "Id");
            DropColumn("dbo.AspNetUsers", "Miasto");
        }
        
        public override void Down()
        {
            AddColumn("dbo.AspNetUsers", "Miasto", c => c.String());
            DropForeignKey("dbo.CV", "MiastoId", "dbo.Miasto");
            DropIndex("dbo.CV", new[] { "MiastoId" });
            DropColumn("dbo.AspNetUsers", "NazwaMiasta");
            DropColumn("dbo.CV", "MiastoId");
        }
    }
}
