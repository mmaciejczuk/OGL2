namespace Repozytorium.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _7 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "MiastoId", c => c.Int());
            CreateIndex("dbo.AspNetUsers", "MiastoId");
            AddForeignKey("dbo.AspNetUsers", "MiastoId", "dbo.Miasto", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUsers", "MiastoId", "dbo.Miasto");
            DropIndex("dbo.AspNetUsers", new[] { "MiastoId" });
            DropColumn("dbo.AspNetUsers", "MiastoId");
        }
    }
}
