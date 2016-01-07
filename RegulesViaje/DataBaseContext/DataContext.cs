using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using RegulesViaje.Models;

namespace RegulesViaje.DataBaseContext
{
    public class DataContext : DbContext
    {
        public DataContext()
            : base(nameOrConnectionString : "MSSQLCONNECT")
        {
        
        }

        public DbSet<User> Users { get; set; }
        public DbSet<UserGroup> UserGroups { get; set; }
        public DbSet<Group> Groups { get; set; }
        public DbSet<Security> Securities { get; set; }
        public DbSet<Module> Modules { get; set; }
        public DbSet<Option> Options { get; set; }
        public DbSet<Currency> Currencies { get; set; }
        public DbSet<ConvertionRate> ConvertionRates { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Location> Locations { get; set; }
        public DbSet<Neighborhood> Neighborhoods { get; set; }
        public DbSet<Employed> Employees { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<Provider> Providers { get; set; }
        public DbSet<ProviderClasification> ProviderClasifications { get; set; }
        public DbSet<PayMode> PayModes { get; set; }
        public DbSet<State> States { get; set; }
        public DbSet<IdentificationType> IdentificationTypes { get; set; }
        public DbSet<Property> Properties { get; set; }
        public DbSet<Voucher> Vouchers { get; set; }
        public DbSet<VoucherProperty> VoucherProperties { get; set; }
        public DbSet<Package> Packages { get; set; }
        public DbSet<PackagePayMode> PackagePayModes { get; set; }
        public DbSet<Service> Services { get; set; }
        public DbSet<ServiceProperty> ServiceProperties { get; set; }
        public DbSet<ProviderProperty> ProviderProperties { get; set; }
      
  
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            // ConvertionRate table
            // Para definir la doble relacion de la tabla ConvertionRate (tasa de cambio) con Currency (moneda)
            modelBuilder.Entity<ConvertionRate>()
                .HasRequired(c => c.CurrencyOne)
                .WithMany(r => r.RateOne)
                .HasForeignKey(c => c.CurrencyOneId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<ConvertionRate>()
                .HasRequired(c => c.CurrencyTwo)
                .WithMany(r => r.RateTwo)
                .HasForeignKey(c => c.CurrencyTwoId)
                .WillCascadeOnDelete(false);
            
            // On cascade delete false
            modelBuilder.Entity<ConvertionRate>()
                .HasMany(e => e.Packages)
                .WithRequired(e => e.ConvertionRate)
                .HasForeignKey(e => e.ConvertionRateId)
                .WillCascadeOnDelete(false);

            // Department table
            // On cascade delete false with Location, User and Provider tables
            modelBuilder.Entity<Department>()
                .HasMany(e => e.Locations)
                .WithRequired(e => e.Department)
                .HasForeignKey(e => e.DepartmentId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Department>()
                .HasMany(e => e.Users)
                .WithRequired(e => e.Department)
                .HasForeignKey(e => e.DepartmentId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Department>()
                .HasMany(e => e.Providers)
                .WithRequired(e => e.Department)
                .HasForeignKey(e => e.DepartmentId)
                .WillCascadeOnDelete(false);

            // Country table
            // Para desabilitar la eliminacion en cascada en la tabla Country
            modelBuilder.Entity<Country>()
                .HasMany(e => e.Departments)
                .WithRequired(e => e.Country)
                .HasForeignKey(e => e.CountryId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Country>()
                .HasMany(e => e.Users)
                .WithRequired(e => e.Country)
                .HasForeignKey(e => e.CountryId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Country>()
                .HasMany(e => e.Providers)
                .WithRequired(e => e.Country)
                .HasForeignKey(e => e.CountryId)
                .WillCascadeOnDelete(false);

            // IdentificationType table
            // Para desabilitar la eliminacion en cascada en la tabla IdentificationType
            modelBuilder.Entity<IdentificationType>()
                .HasMany(e => e.Users)
                .WithRequired(e => e.IdentificationType)
                .HasForeignKey(e => e.IdentificationTypeId)
                .WillCascadeOnDelete(false);

            // Location table
            // On casade delete true with Neighborhood table
            modelBuilder.Entity<Location>() 
                .HasMany(e => e.Neighborhoods)
                .WithRequired(e => e.Location)
                .HasForeignKey(e => e.LocationId)
                .WillCascadeOnDelete(true);

            // On casade delete false with User table
            modelBuilder.Entity<Location>()
                .HasMany(e => e.Users)
                .WithRequired(e => e.Location)
                .HasForeignKey(e => e.LocationId)
                .WillCascadeOnDelete(false);

            // On casade delete false with Provider table
            modelBuilder.Entity<Location>()
                .HasMany(e => e.Providers)
                .WithRequired(e => e.Location)
                .HasForeignKey(e => e.LocationId)
                .WillCascadeOnDelete(false);

            // Neighborhood table
            // On cascade delete false with User and Provider tables
            modelBuilder.Entity<Neighborhood>()
                .HasMany(e => e.Users)
                .WithRequired(e => e.Neighborhood)
                .HasForeignKey(e => e.NeighborhoodId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Neighborhood>()
                .HasMany(e => e.Providers)
                .WithRequired(e => e.Neighborhood)
                .HasForeignKey(e => e.NeighborhoodId)
                .WillCascadeOnDelete(false);

            // Module table
            // On cascade delete true with Security table
            modelBuilder.Entity<Module>()
                .HasMany(e => e.Securities)
                .WithRequired(e => e.Module)
                .HasForeignKey(e => e.ModuleId)
                .WillCascadeOnDelete(true);

            // Option table
            // On cascade delete true with Securirty table
            modelBuilder.Entity<Option>()
                .HasMany(e => e.Securities)
                .WithRequired(e => e.Option)
                .HasForeignKey(e => e.OptionId)
                .WillCascadeOnDelete(true);
            
            // Group table
            // On cascade delete true with Security table
            modelBuilder.Entity<Group>()
                .HasMany(e => e.Securities)
                .WithRequired(e => e.Group)
                .HasForeignKey(e => e.GroupId)
                .WillCascadeOnDelete(true);

            // On cascade delete true with UserGroup table
            modelBuilder.Entity<Group>()
                .HasMany(e => e.UserGroups)
                .WithRequired(e => e.Group)
                .HasForeignKey(e => e.GroupId)
                .WillCascadeOnDelete(true);

            // ProviderClasification table
            // Para desabilitar la eliminacion en cascada en la tabla ProviderClasification
            modelBuilder.Entity<ProviderClasification>()
                .HasMany(e => e.Providers)
                .WithRequired(e => e.ProviderClasification)
                .HasForeignKey(e => e.ProviderClasificationId)
                .WillCascadeOnDelete(false);

            // Provider table
            // On cascade delete false with Service and ProviderProperties tables
            modelBuilder.Entity<Provider>()
                .HasMany(e => e.Services)
                .WithRequired(e => e.Provider)
                .HasForeignKey(e => e.ProviderId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Provider>()
                .HasMany(e => e.ProviderProperties)
                .WithRequired(e => e.Provider)
                .HasForeignKey(e => e.ProviderId)
                .WillCascadeOnDelete(false);

            // State table
            // On cascade delete to false with Employed and Package tables
            modelBuilder.Entity<State>()
                .HasMany(e => e.Employees)
                .WithRequired(e => e.State)
                .HasForeignKey(e => e.StateId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<State>()
                .HasMany(e => e.Packages)
                .WithRequired(e => e.State)
                .HasForeignKey(e => e.StateId)
                .WillCascadeOnDelete(false);

            // Property table
            // Enable on cascade delete with VoucherProperties table
            modelBuilder.Entity<Property>()
                .HasMany(e => e.VoucherProperties)
                .WithRequired(e => e.Property)
                .HasForeignKey(e => e.PropertyId)
                .WillCascadeOnDelete(true);

            modelBuilder.Entity<Property>()
                .HasMany(e => e.ProviderProperties)
                .WithRequired(e => e.Property)
                .HasForeignKey(e => e.PropertyId)
                .WillCascadeOnDelete(true);

            modelBuilder.Entity<Property>()
                .HasMany(e => e.ServiceProperties)
                .WithRequired(e => e.Property)
                .HasForeignKey(e => e.PropertyId)
                .WillCascadeOnDelete(true);

            // Voucher table
            // Enable on cascade delete
            modelBuilder.Entity<Voucher>()
                .HasMany(e => e.VoucherProperties)
                .WithRequired(e => e.Voucher)
                .HasForeignKey(e => e.VoucherId)
                .WillCascadeOnDelete(true);
            
            // Package table
            // On cascade delete false with Service table 
            // TODO: Here may be true? 
            modelBuilder.Entity<Package>()
                .HasMany(e => e.Services)
                .WithRequired(e => e.Package)
                .HasForeignKey(e => e.PackageId)
                .WillCascadeOnDelete(false);

            // On cascade delete true with PackagePayModes table
            modelBuilder.Entity<Package>()
                .HasMany(e => e.PackagePayModes)
                .WithRequired(e => e.Package)
                .HasForeignKey(e => e.PackageId)
                .WillCascadeOnDelete(true);

            // PayMode table
            // On cascade delete true with PackagePayModes table
            modelBuilder.Entity<PayMode>()
                .HasMany(e => e.PackagePayModes)
                .WithRequired(e => e.PayMode)
                .HasForeignKey(e => e.PayModeId)
                .WillCascadeOnDelete(true);

            // Service table
            // On cascade delete true with ServiceProperties table
            modelBuilder.Entity<Service>()
                .HasMany(e => e.ServiceProperties)
                .WithRequired(e => e.Service)
                .HasForeignKey(e => e.ServiceId)
                .WillCascadeOnDelete(true);

            // On cascade delete true with Vouchers table
            modelBuilder.Entity<Service>()
                .HasMany(e => e.Vouchers)
                .WithRequired(e => e.Service)
                .HasForeignKey(e => e.ServiceId)
                .WillCascadeOnDelete(true);

            // User table
            // On cascade delete true with UserGroup table
            modelBuilder.Entity<User>()
                .HasMany(e => e.UserGroups)
                .WithRequired(e => e.User)
                .HasForeignKey(e => e.UserId)
                .WillCascadeOnDelete(true);

            // IdentificationType table
            // On cascade delete false with User table
            modelBuilder.Entity<IdentificationType>()
                .HasMany(e => e.Users)
                .WithRequired(e => e.IdentificationType)
                .HasForeignKey(e => e.IdentificationTypeId)
                .WillCascadeOnDelete(false);

            // Employed table
            // On cascade delete false with Package table
            modelBuilder.Entity<Employed>()
                .HasMany(e => e.Packages)
                .WithRequired(e => e.Employed)
                .HasForeignKey(e => e.EmployedId)
                .WillCascadeOnDelete(false);

            // Employed table
            // On cascade delete false with Package table
            modelBuilder.Entity<Employed>()
                .HasMany(e => e.Packages)
                .WithRequired(e => e.Employed)
                .HasForeignKey(e => e.EmployedId)
                .WillCascadeOnDelete(false);

            // Client table
            // On cascade delete false with Package table
            modelBuilder.Entity<Client>()
                .HasMany(e => e.Packages)
                .WithRequired(e => e.Client)
                .HasForeignKey(e => e.ClientId)
                .WillCascadeOnDelete(false);

        }

    }
}
