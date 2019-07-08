namespace OARS.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Artifact",
                c => new
                    {
                        ArtifactID = c.Int(nullable: false, identity: true),
                        Description = c.String(nullable: false),
                        Weight = c.Double(nullable: false),
                        ElevationFound = c.Single(nullable: false),
                        ComparativeLayer = c.String(nullable: false),
                        Latitude = c.Double(nullable: false),
                        Longitude = c.Double(nullable: false),
                        Altitude = c.Double(nullable: false),
                        Material = c.String(nullable: false),
                        ContextSoilType = c.String(nullable: false),
                        SoilColorHexValue = c.Int(nullable: false),
                        DateTimeDiscovered = c.DateTime(nullable: false),
                        ArchaeologicalSignificance = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.ArtifactID);
            
            CreateTable(
                "dbo.Feature",
                c => new
                    {
                        FeatureID = c.Int(nullable: false, identity: true),
                        Description = c.String(nullable: false),
                        ElevationFound = c.Single(nullable: false),
                        ComparativeLayer = c.String(nullable: false),
                        Latitude = c.Double(nullable: false),
                        Longitude = c.Double(nullable: false),
                        Altitude = c.Double(nullable: false),
                        Material = c.String(nullable: false),
                        ContextSoilType = c.String(nullable: false),
                        ContextSoilColorAsHexValue = c.Int(nullable: false),
                        FeatureSoilType = c.String(nullable: false),
                        FeatureSoilColorAsHexValue = c.Int(nullable: false),
                        DateTimeDiscovered = c.DateTime(nullable: false),
                        ArchaeologicalSignificance = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.FeatureID);
            
            CreateTable(
                "dbo.IdentityRole",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.IdentityUserRole",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(),
                        IdentityRole_Id = c.String(maxLength: 128),
                        ApplicationUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.UserId)
                .ForeignKey("dbo.IdentityRole", t => t.IdentityRole_Id)
                .ForeignKey("dbo.ApplicationUser", t => t.ApplicationUser_Id)
                .Index(t => t.IdentityRole_Id)
                .Index(t => t.ApplicationUser_Id);
            
            CreateTable(
                "dbo.Site",
                c => new
                    {
                        ModernSiteName = c.String(nullable: false, maxLength: 128),
                        AncientSiteName = c.String(),
                        Latitude = c.Double(nullable: false),
                        Longitude = c.Double(nullable: false),
                        Altitude = c.Double(nullable: false),
                        OccupiedEras = c.String(nullable: false),
                        CulturesPresent = c.String(nullable: false),
                        PastSiteDirectors = c.String(),
                        CurrentSiteDirectors = c.String(nullable: false),
                        AssociatedUniversities = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.ModernSiteName);
            
            CreateTable(
                "dbo.ApplicationUser",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        FullName = c.String(),
                        DegreeObtained = c.String(),
                        AlmaMater = c.String(),
                        ArchaeologicalSpecialty = c.String(),
                        PublishedWorks = c.String(),
                        CurrentSites = c.String(),
                        PreviousSitesWorked = c.String(),
                        Email = c.String(),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.IdentityUserClaim",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                        ApplicationUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ApplicationUser", t => t.ApplicationUser_Id)
                .Index(t => t.ApplicationUser_Id);
            
            CreateTable(
                "dbo.IdentityUserLogin",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        LoginProvider = c.String(),
                        ProviderKey = c.String(),
                        ApplicationUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.UserId)
                .ForeignKey("dbo.ApplicationUser", t => t.ApplicationUser_Id)
                .Index(t => t.ApplicationUser_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.IdentityUserRole", "ApplicationUser_Id", "dbo.ApplicationUser");
            DropForeignKey("dbo.IdentityUserLogin", "ApplicationUser_Id", "dbo.ApplicationUser");
            DropForeignKey("dbo.IdentityUserClaim", "ApplicationUser_Id", "dbo.ApplicationUser");
            DropForeignKey("dbo.IdentityUserRole", "IdentityRole_Id", "dbo.IdentityRole");
            DropIndex("dbo.IdentityUserLogin", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.IdentityUserClaim", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.IdentityUserRole", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.IdentityUserRole", new[] { "IdentityRole_Id" });
            DropTable("dbo.IdentityUserLogin");
            DropTable("dbo.IdentityUserClaim");
            DropTable("dbo.ApplicationUser");
            DropTable("dbo.Site");
            DropTable("dbo.IdentityUserRole");
            DropTable("dbo.IdentityRole");
            DropTable("dbo.Feature");
            DropTable("dbo.Artifact");
        }
    }
}
