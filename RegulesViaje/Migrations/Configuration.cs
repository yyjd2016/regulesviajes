namespace RegulesViaje.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using RegulesViaje.Models;
    using System.Collections.Generic;

    internal sealed class Configuration : DbMigrationsConfiguration<RegulesViaje.DataBaseContext.DataContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(RegulesViaje.DataBaseContext.DataContext context)
        {
            //  This method will be called after migrating to the latest version.

            /* Poblando tabla de paises */
            var countries = new List<Country>
            {
                new Country{Name="Cuba"},
                new Country{Name="Uruguay"},
                new Country{Name="Paraguay"},
                new Country{Name="Argentina"},
                new Country{Name="Brasil"},
                new Country{Name="Chile"},
                new Country{Name="Perú"},
                new Country{Name="Bolivia"},
                new Country{Name="Colombia"},
                new Country{Name="Venezuela"},
                new Country{Name="Panamá"},
                new Country{Name="El Salvador"},
                new Country{Name="Honduras"},
                new Country{Name="México"},
                new Country{Name="Ecuador"}
            };
            countries.ForEach(c => context.Countries.AddOrUpdate(p => p.Name, c));
            context.SaveChanges();

            var departments = new List<Department>
            {
                /* Departamentos/Provincia de Uruguay */
                new Department { Name = "Artigas", CountryId = countries.Single(s => s.Name == "Uruguay").Id },
                new Department { Name = "Montevideo", CountryId = countries.Single(s => s.Name == "Uruguay").Id },
                new Department { Name = "Durazno", CountryId = countries.Single(s => s.Name == "Uruguay").Id },
                new Department { Name = "Florida", CountryId = countries.Single(s => s.Name == "Uruguay").Id },
                new Department { Name = "Maldonado", CountryId = countries.Single(s => s.Name == "Uruguay").Id },
                new Department { Name = "Paysandú", CountryId = countries.Single(s => s.Name == "Uruguay").Id },

                /* Departamentos/Provincia de Cuba */
                new Department { Name = "Camaguey", CountryId = countries.Single(s => s.Name == "Cuba").Id },
                new Department { Name = "La Habana", CountryId = countries.Single(s => s.Name == "Cuba").Id },
                new Department { Name = "Pinar del Rio", CountryId = countries.Single(s => s.Name == "Cuba").Id },
                new Department { Name = "Las Tunas", CountryId = countries.Single(s => s.Name == "Cuba").Id }
            };
            departments.ForEach(d => context.Departments.AddOrUpdate(c => c.Id, d));
            context.SaveChanges();

            var locations = new List<Location> 
            {
                /* Localidades/Municipios de Montevideo -> Uruguay */
                new Location { Name = "Municipio A", DepartmentId = departments.Single(d => d.Name == "Montevideo").Id },
                new Location { Name = "Municipio B", DepartmentId = departments.Single(d => d.Name == "Montevideo").Id },
                new Location { Name = "Municipio C", DepartmentId = departments.Single(d => d.Name == "Montevideo").Id },
            
                /* Localidades/Municipios de Camaguey -> Cuba */
                new Location { Name = "Camaguey", DepartmentId = departments.Single(d => d.Name == "Camaguey").Id },
                new Location { Name = "Vertientes", DepartmentId = departments.Single(d => d.Name == "Camaguey").Id },
                new Location { Name = "Florida", DepartmentId = departments.Single(d => d.Name == "Camaguey").Id }
            };
            locations.ForEach(l => context.Locations.AddOrUpdate(d => d.Id, l));
            context.SaveChanges();

            var neighborhoods = new List<Neighborhood>
            {
                /* Barrios del municipio Municipio A -> Montevideo -> Uruguay */
                new Neighborhood { Name = "Centro", LocationId = locations.Single( l => l.Name == "Municipio A").Id },
                new Neighborhood { Name = "Ciudad Vieja", LocationId = locations.Single( l => l.Name == "Municipio A").Id },

                /* Barrios del municipio Camaguey -> Camaguey -> Cuba */
                new Neighborhood { Name = "Jayamá", LocationId = locations.Single( l => l.Name == "Camaguey").Id },
                new Neighborhood { Name = "La Caridad", LocationId = locations.Single( l => l.Name == "Camaguey").Id }
            };
            neighborhoods.ForEach(n => context.Neighborhoods.AddOrUpdate(l => l.Id, n));
            context.SaveChanges();

            var currencies = new List<Currency>
            {
                new Currency{Description="Peso cubano", Code="CUP", Symbol="$"},
                new Currency{Description="Peso convertible cubano", Code="CUC", Symbol="$"},
                new Currency{Description="Peso uruguayo", Code="UYU", Symbol="$"},
                new Currency{Description="Peso mexicano", Code="MXN", Symbol="$"},
                new Currency{Description="Dollar estadounidence", Code="USD", Symbol="$"},
                new Currency{Description="Real brasilero", Code="BRL", Symbol="$"}
            };
            currencies.ForEach(c => context.Currencies.AddOrUpdate(p => p.Id, c));
            context.SaveChanges();

            var groups = new List<Group>
            {
                new Group{Name="Supervisores"},
                new Group{Name="Agentes"},
                new Group{Name="Administradores"}
            };
            groups.ForEach(g => context.Groups.AddOrUpdate(c => c.Id, g));
            context.SaveChanges();

            var identifications = new List<IdentificationType>
            {
                new IdentificationType { Name="Pasaporte" },
                new IdentificationType { Name="Cédula de identidad" },
                new IdentificationType { Name="Carné de identidad" }
            };
            identifications.ForEach(i => context.IdentificationTypes.AddOrUpdate(c => c.Id, i));
            context.SaveChanges();

            var modules = new List<Module>
            {
                new Module { Name="Reserva" },
                new Module { Name="Configuración" },
                new Module { Name="Informes" }
            };
            modules.ForEach(m => context.Modules.AddOrUpdate(c => c.Id, m));
            context.SaveChanges();

            var options = new List<Option>
            {
                new Option { Description="Opcion1" },
                new Option { Description="Opcion2" },
                new Option { Description="Opcion3" }
            };
            options.ForEach(o => context.Options.AddOrUpdate(c => c.Id, o));
            context.SaveChanges();

            var paymentModes = new List<PayMode>
            {
                new PayMode { Code="EFE", Description="Efectivo" },
                new PayMode { Code="TDC", Description="Tarjeta de credito" },
                new PayMode { Code="TDD", Description="Tarjeta de débito" },
                new PayMode { Code="CHE", Description="Cheque" }
            };
            paymentModes.ForEach(p => context.PayModes.AddOrUpdate(c => c.Id, p));
            context.SaveChanges();

            var providerClass = new List<ProviderClasification>
            {
                new ProviderClasification { Name="Transporte", Code="TRANS", StartDate=DateTime.Now, EndDate=DateTime.Parse("2016-05-01T00:00") },
                new ProviderClasification { Name="Alojamiento", Code="ALOJA", StartDate=DateTime.Now, EndDate=DateTime.Parse("2016-05-01T00:00") },
                new ProviderClasification { Name="Alimentación", Code="ALIM", StartDate=DateTime.Now, EndDate=DateTime.Parse("2016-05-01T00:00") },
                new ProviderClasification { Name="Entretenimiento", Code="ENTRE", StartDate=DateTime.Now, EndDate=DateTime.Parse("2016-05-01T00:00") }
            };
            providerClass.ForEach(p => context.ProviderClasifications.AddOrUpdate(c => c.Id, p));
            context.SaveChanges();

            var providers = new List<Provider>
            {
                new Provider {  
                    Code="P001", 
                    Name="Cooperativa Taxi-1", 
                    Description="Cooperativa de servicio de Taxi",
                    ProviderClasificationId = providerClass.Single(s => s.Code == "TRANS").Id,
                    CountryId = countries.Single(s => s.Name == "Uruguay").Id,
                    DepartmentId = departments.Single(s => s.Name == "Montevideo").Id,
                    LocationId = locations.Single(s => s.Name == "Municipio A").Id,
                    NeighborhoodId = neighborhoods.Single(s => s.Name == "Centro").Id,
                    Address = "Andes 1371"
                },
                new Provider {  
                    Code="H001", 
                    Name="Hotel Radinsson", 
                    Description="Hotel 5 estrellas",
                    ProviderClasificationId = providerClass.Single(s => s.Code == "ALOJA").Id,
                    CountryId = countries.Single(s => s.Name == "Uruguay").Id,
                    DepartmentId = departments.Single(s => s.Name == "Montevideo").Id,
                    LocationId = locations.Single(s => s.Name == "Municipio A").Id,
                    NeighborhoodId = neighborhoods.Single(s => s.Name == "Ciudad Vieja").Id,
                    Address = "Juncal 1390 of 1304"
                },
                new Provider {
                    Code="A001",
                    Name="La Pasiva", 
                    Description="Restaurante 1ra categoría de comida chatarra",
                    ProviderClasificationId = providerClass.Single(s => s.Code == "ALIM").Id,
                    CountryId = countries.Single(s => s.Name == "Uruguay").Id,
                    DepartmentId = departments.Single(s => s.Name == "Montevideo").Id,
                    LocationId = locations.Single(s => s.Name == "Municipio A").Id,
                    NeighborhoodId = neighborhoods.Single(s => s.Name == "Centro").Id,
                    Address = "Av. 18 de julio 9012"
                }
            };
            providers.ForEach(p => context.Providers.AddOrUpdate(c => c.Id, p));
            context.SaveChanges();

            var states = new List<State>
            {
                new State { Description = "Periodo de prueba" },
                new State { Description = "Contratado" },
                new State { Description = "Baja" },
                new State { Description = "Pendiente" },
                new State { Description = "Reservado" },
                new State { Description = "Cancelado" },
                new State { Description = "Eliminado" }
            };
            states.ForEach(s => context.States.AddOrUpdate(c => c.Id, s));
            context.SaveChanges();

            var employees = new List<Employed>
            {
                new Employed 
                {
                    // Datos modelo User
                    FirstName = "Juan",
                    SecondName = "Alberto",
                    FirstLastName = "Pérez",
                    SecondLastName = "Castellano",
                    IdentificationValue = "I020052",
                    IdentificationTypeId = identifications.Single(s => s.Name == "Pasaporte").Id,
                    Phone = "216465789",
                    CellPhone = "095465789",
                    eMail = "juanalbert@gmail.com",
                    CountryId = countries.Single(s => s.Name == "Uruguay").Id,
                    DepartmentId = departments.Single(s => s.Name == "Montevideo").Id,
                    LocationId = locations.Single(s => s.Name == "Municipio A").Id,
                    NeighborhoodId = neighborhoods.Single(s => s.Name == "Ciudad Vieja").Id,
                    Address = "Juncal 1390 of 606",
                    EntryDate = DateTime.Now,

                    // Datos modelo Employed
                    Salary = 20000.00,
                    StateId = states.Single(s => s.Description == "Contratado").Id,
                    FinishDate = DateTime.Parse("2017-10-10T00:00")
                }
            };
            employees.ForEach(e => context.Employees.AddOrUpdate(c => c.Id, e));
            context.SaveChanges();

            var clients = new List<Client>
            {
                new Client 
                {
                    // Data of User model
                    FirstName = "Periquito",
                    SecondName = "",
                    FirstLastName = "Pérez",
                    SecondLastName = "Rodríguez",
                    IdentificationValue = "6.159.190-3",
                    IdentificationTypeId = identifications.Single(s => s.Name == "Cédula de identidad").Id,
                    Phone = "216456723",
                    CellPhone = "094345123",
                    eMail = "periquito@gmail.com",
                    CountryId = countries.Single(s => s.Name == "Uruguay").Id,
                    DepartmentId = departments.Single(s => s.Name == "Montevideo").Id,
                    LocationId = locations.Single(s => s.Name == "Municipio A").Id,
                    NeighborhoodId = neighborhoods.Single(s => s.Name == "Ciudad Vieja").Id,
                    Address = "Juncal 14563",
                    EntryDate = DateTime.Now,

                    // Data of Client model
                    EmergencyContact = "Laura Zerpa, Tel: +189123244, Av. Independencia Edif:1 Apto: 50",
                    FootRequirement = "Bajo de Sal y Grasa",
                    HealthRequirement = "",
                    LifeInsurance = "Seguro ProSalud"
                }
            };
            clients.ForEach(c => context.Clients.AddOrUpdate(i => i.Id, c));
            context.SaveChanges();


        }
    }
}
