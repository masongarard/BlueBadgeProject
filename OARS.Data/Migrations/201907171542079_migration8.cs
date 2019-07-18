namespace OARS.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class migration8 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Artifact", "SiteID", c => c.Int(nullable: false));
            CreateIndex("dbo.Artifact", "SiteID");
            AddForeignKey("dbo.Artifact", "SiteID", "dbo.Site", "SiteID", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Artifact", "SiteID", "dbo.Site");
            DropIndex("dbo.Artifact", new[] { "SiteID" });
            DropColumn("dbo.Artifact", "SiteID");
        }
    }
}
