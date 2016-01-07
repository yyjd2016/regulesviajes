namespace RegulesViaje.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialSchema : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.User",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IdentificationTypeId = c.Int(nullable: false),
                        IdentificationValue = c.String(nullable: false, maxLength: 50),
                        FirstName = c.String(nullable: false, maxLength: 50),
                        SecondName = c.String(maxLength: 50),
                        FirstLastName = c.String(nullable: false, maxLength: 50),
                        SecondLastName = c.String(nullable: false, maxLength: 50),
                        EntryDate = c.DateTime(nullable: false),
                        Phone = c.String(),
                        CellPhone = c.String(),
                        CountryId = c.Int(nullable: false),
                        DepartmentId = c.Int(nullable: false),
                        LocationId = c.Int(nullable: false),
                        NeighborhoodId = c.Int(nullable: false),
                        Address = c.String(maxLength: 128),
                        eMail = c.String(maxLength: 50),
                        EmergencyContact = c.String(maxLength: 128),
                        FootRequirement = c.String(maxLength: 128),
                        HealthRequirement = c.String(maxLength: 128),
                        LifeInsurance = c.String(maxLength: 128),
                        Salary = c.Double(),
                        FinishDate = c.DateTime(),
                        StateId = c.Int(),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.IdentificationType", t => t.IdentificationTypeId)
                .ForeignKey("dbo.State", t => t.StateId)
                .ForeignKey("dbo.Neighborhood", t => t.NeighborhoodId)
                .ForeignKey("dbo.Location", t => t.LocationId)
                .ForeignKey("dbo.Department", t => t.DepartmentId)
                .ForeignKey("dbo.Country", t => t.CountryId)
                .Index(t => t.IdentificationTypeId)
                .Index(t => t.StateId)
                .Index(t => t.NeighborhoodId)
                .Index(t => t.LocationId)
                .Index(t => t.DepartmentId)
                .Index(t => t.CountryId);
            
            CreateTable(
                "dbo.Country",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Department",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        CountryId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Country", t => t.CountryId)
                .Index(t => t.CountryId);
            
            CreateTable(
                "dbo.Location",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        DepartmentId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Department", t => t.DepartmentId)
                .Index(t => t.DepartmentId);
            
            CreateTable(
                "dbo.Neighborhood",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        LocationId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Location", t => t.LocationId, cascadeDelete: true)
                .Index(t => t.LocationId);
            
            CreateTable(
                "dbo.Provider",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Code = c.String(nullable: false, maxLength: 50),
                        Name = c.String(nullable: false, maxLength: 128),
                        Description = c.String(maxLength: 255),
                        ProviderClasificationId = c.Int(nullable: false),
                        CountryId = c.Int(nullable: false),
                        DepartmentId = c.Int(nullable: false),
                        LocationId = c.Int(nullable: false),
                        NeighborhoodId = c.Int(nullable: false),
                        Address = c.String(maxLength: 255),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ProviderClasification", t => t.ProviderClasificationId)
                .ForeignKey("dbo.Neighborhood", t => t.NeighborhoodId)
                .ForeignKey("dbo.Location", t => t.LocationId)
                .ForeignKey("dbo.Department", t => t.DepartmentId)
                .ForeignKey("dbo.Country", t => t.CountryId)
                .Index(t => t.ProviderClasificationId)
                .Index(t => t.NeighborhoodId)
                .Index(t => t.LocationId)
                .Index(t => t.DepartmentId)
                .Index(t => t.CountryId);
            
            CreateTable(
                "dbo.ProviderClasification",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                        Code = c.String(maxLength: 50),
                        StartDate = c.DateTime(nullable: false),
                        EndDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ProviderProperty",
                c => new
                    {
                        ProviderId = c.Int(nullable: false),
                        PropertyId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.ProviderId, t.PropertyId })
                .ForeignKey("dbo.Property", t => t.PropertyId, cascadeDelete: true)
                .ForeignKey("dbo.Provider", t => t.ProviderId)
                .Index(t => t.PropertyId)
                .Index(t => t.ProviderId);
            
            CreateTable(
                "dbo.Property",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                        DisplayName = c.String(maxLength: 100),
                        Description = c.String(maxLength: 255),
                        DataType = c.Short(nullable: false),
                        Source = c.String(maxLength: 100),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ServiceProperty",
                c => new
                    {
                        ServiceId = c.Int(nullable: false),
                        PropertyId = c.Int(nullable: false),
                        Value = c.String(nullable: false, maxLength: 255),
                    })
                .PrimaryKey(t => new { t.ServiceId, t.PropertyId })
                .ForeignKey("dbo.Service", t => t.ServiceId, cascadeDelete: true)
                .ForeignKey("dbo.Property", t => t.PropertyId, cascadeDelete: true)
                .Index(t => t.ServiceId)
                .Index(t => t.PropertyId);
            
            CreateTable(
                "dbo.Service",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Order = c.Int(nullable: false),
                        PeopleCount = c.Int(nullable: false),
                        PackageId = c.Int(nullable: false),
                        ProviderId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Package", t => t.PackageId)
                .ForeignKey("dbo.Provider", t => t.ProviderId)
                .Index(t => t.PackageId)
                .Index(t => t.ProviderId);
            
            CreateTable(
                "dbo.Package",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Date = c.DateTime(nullable: false),
                        ClientId = c.Int(nullable: false),
                        EmployedId = c.Int(nullable: false),
                        CurrencyId = c.Int(nullable: false),
                        StateId = c.Int(nullable: false),
                        ConvertionRateId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Currency", t => t.CurrencyId, cascadeDelete: true)
                .ForeignKey("dbo.ConvertionRate", t => t.ConvertionRateId)
                .ForeignKey("dbo.User", t => t.EmployedId)
                .ForeignKey("dbo.State", t => t.StateId)
                .ForeignKey("dbo.User", t => t.ClientId)
                .Index(t => t.CurrencyId)
                .Index(t => t.ConvertionRateId)
                .Index(t => t.EmployedId)
                .Index(t => t.StateId)
                .Index(t => t.ClientId);
            
            CreateTable(
                "dbo.ConvertionRate",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PurchaseValue = c.Double(nullable: false),
                        SaleValue = c.Double(nullable: false),
                        Date = c.DateTime(nullable: false),
                        CurrencyOneId = c.Int(nullable: false),
                        CurrencyTwoId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Currency", t => t.CurrencyOneId)
                .ForeignKey("dbo.Currency", t => t.CurrencyTwoId)
                .Index(t => t.CurrencyOneId)
                .Index(t => t.CurrencyTwoId);
            
            CreateTable(
                "dbo.Currency",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Description = c.String(nullable: false),
                        Code = c.String(nullable: false),
                        Symbol = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.IdentificationType",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.UserGroup",
                c => new
                    {
                        UserId = c.Int(nullable: false),
                        GroupId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.UserId, t.GroupId })
                .ForeignKey("dbo.Group", t => t.GroupId, cascadeDelete: true)
                .ForeignKey("dbo.User", t => t.UserId, cascadeDelete: true)
                .Index(t => t.GroupId)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.Group",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Security",
                c => new
                    {
                        GroupId = c.Int(nullable: false),
                        ModuleId = c.Int(nullable: false),
                        OptionId = c.Int(nullable: false),
                        Value = c.Short(nullable: false),
                    })
                .PrimaryKey(t => new { t.GroupId, t.ModuleId, t.OptionId })
                .ForeignKey("dbo.Module", t => t.ModuleId, cascadeDelete: true)
                .ForeignKey("dbo.Option", t => t.OptionId, cascadeDelete: true)
                .ForeignKey("dbo.Group", t => t.GroupId, cascadeDelete: true)
                .Index(t => t.ModuleId)
                .Index(t => t.OptionId)
                .Index(t => t.GroupId);
            
            CreateTable(
                "dbo.Module",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Option",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Description = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.State",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Description = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.PackagePayMode",
                c => new
                    {
                        PackageId = c.Int(nullable: false),
                        PayModeId = c.Int(nullable: false),
                        Amount = c.Double(nullable: false),
                    })
                .PrimaryKey(t => new { t.PackageId, t.PayModeId })
                .ForeignKey("dbo.PayMode", t => t.PayModeId, cascadeDelete: true)
                .ForeignKey("dbo.Package", t => t.PackageId, cascadeDelete: true)
                .Index(t => t.PayModeId)
                .Index(t => t.PackageId);
            
            CreateTable(
                "dbo.PayMode",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Code = c.String(nullable: false, maxLength: 20),
                        Description = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Voucher",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Description = c.String(maxLength: 50),
                        ServiceId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Service", t => t.ServiceId, cascadeDelete: true)
                .Index(t => t.ServiceId);
            
            CreateTable(
                "dbo.VoucherProperty",
                c => new
                    {
                        VoucherId = c.Int(nullable: false),
                        PropertyId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.VoucherId, t.PropertyId })
                .ForeignKey("dbo.Voucher", t => t.VoucherId, cascadeDelete: true)
                .ForeignKey("dbo.Property", t => t.PropertyId, cascadeDelete: true)
                .Index(t => t.VoucherId)
                .Index(t => t.PropertyId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Package", "ClientId", "dbo.User");
            DropForeignKey("dbo.User", "CountryId", "dbo.Country");
            DropForeignKey("dbo.Provider", "CountryId", "dbo.Country");
            DropForeignKey("dbo.Department", "CountryId", "dbo.Country");
            DropForeignKey("dbo.User", "DepartmentId", "dbo.Department");
            DropForeignKey("dbo.Provider", "DepartmentId", "dbo.Department");
            DropForeignKey("dbo.Location", "DepartmentId", "dbo.Department");
            DropForeignKey("dbo.User", "LocationId", "dbo.Location");
            DropForeignKey("dbo.Provider", "LocationId", "dbo.Location");
            DropForeignKey("dbo.Neighborhood", "LocationId", "dbo.Location");
            DropForeignKey("dbo.User", "NeighborhoodId", "dbo.Neighborhood");
            DropForeignKey("dbo.Provider", "NeighborhoodId", "dbo.Neighborhood");
            DropForeignKey("dbo.Service", "ProviderId", "dbo.Provider");
            DropForeignKey("dbo.ProviderProperty", "ProviderId", "dbo.Provider");
            DropForeignKey("dbo.VoucherProperty", "PropertyId", "dbo.Property");
            DropForeignKey("dbo.ServiceProperty", "PropertyId", "dbo.Property");
            DropForeignKey("dbo.Voucher", "ServiceId", "dbo.Service");
            DropForeignKey("dbo.VoucherProperty", "VoucherId", "dbo.Voucher");
            DropForeignKey("dbo.ServiceProperty", "ServiceId", "dbo.Service");
            DropForeignKey("dbo.Service", "PackageId", "dbo.Package");
            DropForeignKey("dbo.PackagePayMode", "PackageId", "dbo.Package");
            DropForeignKey("dbo.PackagePayMode", "PayModeId", "dbo.PayMode");
            DropForeignKey("dbo.Package", "StateId", "dbo.State");
            DropForeignKey("dbo.User", "StateId", "dbo.State");
            DropForeignKey("dbo.Package", "EmployedId", "dbo.User");
            DropForeignKey("dbo.User", "IdentificationTypeId", "dbo.IdentificationType");
            DropForeignKey("dbo.UserGroup", "UserId", "dbo.User");
            DropForeignKey("dbo.UserGroup", "GroupId", "dbo.Group");
            DropForeignKey("dbo.Security", "GroupId", "dbo.Group");
            DropForeignKey("dbo.Security", "OptionId", "dbo.Option");
            DropForeignKey("dbo.Security", "ModuleId", "dbo.Module");
            DropForeignKey("dbo.Package", "ConvertionRateId", "dbo.ConvertionRate");
            DropForeignKey("dbo.ConvertionRate", "CurrencyTwoId", "dbo.Currency");
            DropForeignKey("dbo.ConvertionRate", "CurrencyOneId", "dbo.Currency");
            DropForeignKey("dbo.Package", "CurrencyId", "dbo.Currency");
            DropForeignKey("dbo.ProviderProperty", "PropertyId", "dbo.Property");
            DropForeignKey("dbo.Provider", "ProviderClasificationId", "dbo.ProviderClasification");
            DropIndex("dbo.Package", new[] { "ClientId" });
            DropIndex("dbo.User", new[] { "CountryId" });
            DropIndex("dbo.Provider", new[] { "CountryId" });
            DropIndex("dbo.Department", new[] { "CountryId" });
            DropIndex("dbo.User", new[] { "DepartmentId" });
            DropIndex("dbo.Provider", new[] { "DepartmentId" });
            DropIndex("dbo.Location", new[] { "DepartmentId" });
            DropIndex("dbo.User", new[] { "LocationId" });
            DropIndex("dbo.Provider", new[] { "LocationId" });
            DropIndex("dbo.Neighborhood", new[] { "LocationId" });
            DropIndex("dbo.User", new[] { "NeighborhoodId" });
            DropIndex("dbo.Provider", new[] { "NeighborhoodId" });
            DropIndex("dbo.Service", new[] { "ProviderId" });
            DropIndex("dbo.ProviderProperty", new[] { "ProviderId" });
            DropIndex("dbo.VoucherProperty", new[] { "PropertyId" });
            DropIndex("dbo.ServiceProperty", new[] { "PropertyId" });
            DropIndex("dbo.Voucher", new[] { "ServiceId" });
            DropIndex("dbo.VoucherProperty", new[] { "VoucherId" });
            DropIndex("dbo.ServiceProperty", new[] { "ServiceId" });
            DropIndex("dbo.Service", new[] { "PackageId" });
            DropIndex("dbo.PackagePayMode", new[] { "PackageId" });
            DropIndex("dbo.PackagePayMode", new[] { "PayModeId" });
            DropIndex("dbo.Package", new[] { "StateId" });
            DropIndex("dbo.User", new[] { "StateId" });
            DropIndex("dbo.Package", new[] { "EmployedId" });
            DropIndex("dbo.User", new[] { "IdentificationTypeId" });
            DropIndex("dbo.UserGroup", new[] { "UserId" });
            DropIndex("dbo.UserGroup", new[] { "GroupId" });
            DropIndex("dbo.Security", new[] { "GroupId" });
            DropIndex("dbo.Security", new[] { "OptionId" });
            DropIndex("dbo.Security", new[] { "ModuleId" });
            DropIndex("dbo.Package", new[] { "ConvertionRateId" });
            DropIndex("dbo.ConvertionRate", new[] { "CurrencyTwoId" });
            DropIndex("dbo.ConvertionRate", new[] { "CurrencyOneId" });
            DropIndex("dbo.Package", new[] { "CurrencyId" });
            DropIndex("dbo.ProviderProperty", new[] { "PropertyId" });
            DropIndex("dbo.Provider", new[] { "ProviderClasificationId" });
            DropTable("dbo.VoucherProperty");
            DropTable("dbo.Voucher");
            DropTable("dbo.PayMode");
            DropTable("dbo.PackagePayMode");
            DropTable("dbo.State");
            DropTable("dbo.Option");
            DropTable("dbo.Module");
            DropTable("dbo.Security");
            DropTable("dbo.Group");
            DropTable("dbo.UserGroup");
            DropTable("dbo.IdentificationType");
            DropTable("dbo.Currency");
            DropTable("dbo.ConvertionRate");
            DropTable("dbo.Package");
            DropTable("dbo.Service");
            DropTable("dbo.ServiceProperty");
            DropTable("dbo.Property");
            DropTable("dbo.ProviderProperty");
            DropTable("dbo.ProviderClasification");
            DropTable("dbo.Provider");
            DropTable("dbo.Neighborhood");
            DropTable("dbo.Location");
            DropTable("dbo.Department");
            DropTable("dbo.Country");
            DropTable("dbo.User");
        }
    }
}
