namespace OARS.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addmigrationSecondaryMigration : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Artifact", "SoilColorMunsellValue", c => c.String(nullable: false));
            AddColumn("dbo.Artifact", "IsItDiagnostic", c => c.Boolean(nullable: false));
            AddColumn("dbo.Feature", "ContextSoilColorAsMunsellValue", c => c.String(nullable: false));
            AddColumn("dbo.Feature", "FeatureColorasMunsellValue", c => c.String(nullable: false));
            AddColumn("dbo.Feature", "IsItDiagnostic", c => c.Boolean(nullable: false));
            DropColumn("dbo.Artifact", "SoilColorHexValue");
            DropColumn("dbo.Feature", "Altitude");
            DropColumn("dbo.Feature", "ContextSoilColorAsHexValue");
            DropColumn("dbo.Feature", "FeatureSoilColorAsHexValue");
            DropColumn("dbo.Site", "Altitude");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Site", "Altitude", c => c.Double(nullable: false));
            AddColumn("dbo.Feature", "FeatureSoilColorAsHexValue", c => c.Int(nullable: false));
            AddColumn("dbo.Feature", "ContextSoilColorAsHexValue", c => c.Int(nullable: false));
            AddColumn("dbo.Feature", "Altitude", c => c.Double(nullable: false));
            AddColumn("dbo.Artifact", "SoilColorHexValue", c => c.Int(nullable: false));
            DropColumn("dbo.Feature", "IsItDiagnostic");
            DropColumn("dbo.Feature", "FeatureColorasMunsellValue");
            DropColumn("dbo.Feature", "ContextSoilColorAsMunsellValue");
            DropColumn("dbo.Artifact", "IsItDiagnostic");
            DropColumn("dbo.Artifact", "SoilColorMunsellValue");
        }
    }
}
