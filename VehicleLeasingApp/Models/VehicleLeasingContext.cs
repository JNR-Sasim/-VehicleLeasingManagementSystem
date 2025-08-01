using System;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace VehicleLeasingApp.Models
{
    public class VehicleLeasingContext : DbContext
    {
        public VehicleLeasingContext() : base("DefaultConnection")
        {
        }

        public DbSet<Vehicle> Vehicles { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }
        public DbSet<Branch> Branches { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<Driver> Drivers { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            // Configure relationships
            modelBuilder.Entity<Vehicle>()
                .HasRequired(v => v.Supplier)
                .WithMany(s => s.Vehicles)
                .HasForeignKey(v => v.SupplierId);

            modelBuilder.Entity<Vehicle>()
                .HasRequired(v => v.Branch)
                .WithMany(b => b.Vehicles)
                .HasForeignKey(v => v.BranchId);

            modelBuilder.Entity<Vehicle>()
                .HasOptional(v => v.Client)
                .WithMany(c => c.Vehicles)
                .HasForeignKey(v => v.ClientId);

            modelBuilder.Entity<Vehicle>()
                .HasOptional(v => v.Driver)
                .WithMany(d => d.Vehicles)
                .HasForeignKey(v => v.DriverId);
        }
    }

    public class VehicleLeasingInitializer : CreateDatabaseIfNotExists<VehicleLeasingContext>
    {
        protected override void Seed(VehicleLeasingContext context)
        {
            // Seed Suppliers
            var supplier1 = new Supplier
            {
                Name = "AutoZone South Africa",
                Address = "123 Commissioner Street",
                City = "Johannesburg",
                State = "Gauteng",
                PostalCode = "2000",
                Country = "South Africa",
                Phone = "+27 11 555 0101",
                Email = "info@autozone.co.za",
                Website = "www.autozone.co.za",
                ContactPerson = "Thabo Mokoena",
                RegistrationDate = DateTime.Now.AddDays(-30),
                IsActive = true,
                Notes = "Premium vehicle supplier"
            };

            var supplier2 = new Supplier
            {
                Name = "Cape Town Motors",
                Address = "456 Long Street",
                City = "Cape Town",
                State = "Western Cape",
                PostalCode = "8001",
                Country = "South Africa",
                Phone = "+27 21 555 0202",
                Email = "contact@capetownmotors.co.za",
                Website = "www.capetownmotors.co.za",
                ContactPerson = "Sarah van der Merwe",
                RegistrationDate = DateTime.Now.AddDays(-25),
                IsActive = true,
                Notes = "Luxury vehicle specialist"
            };

            var supplier3 = new Supplier
            {
                Name = "Durban Fleet Solutions",
                Address = "789 Musgrave Road",
                City = "Durban",
                State = "KwaZulu-Natal",
                PostalCode = "4001",
                Country = "South Africa",
                Phone = "+27 31 555 0303",
                Email = "sales@durbanfleet.co.za",
                Website = "www.durbanfleet.co.za",
                ContactPerson = "David Ndlovu",
                RegistrationDate = DateTime.Now.AddDays(-20),
                IsActive = true,
                Notes = "Commercial fleet provider"
            };

            context.Suppliers.AddRange(new[] { supplier1, supplier2, supplier3 });

            // Seed Branches
            var branch1 = new Branch
            {
                Name = "Sandton Branch",
                Address = "100 Maude Street",
                City = "Johannesburg",
                State = "Gauteng",
                PostalCode = "2196",
                Country = "South Africa",
                Phone = "+27 11 555 1001",
                Email = "sandton@leasing.co.za",
                Manager = "Sarah Brown",
                OpeningHours = "Mon-Fri 8AM-6PM, Sat 9AM-4PM",
                BranchCode = "SAN001",
                EstablishmentDate = DateTime.Now.AddDays(-60),
                IsActive = true,
                Description = "Main Sandton location"
            };

            var branch2 = new Branch
            {
                Name = "OR Tambo Airport Branch",
                Address = "200 Airport Road",
                City = "Johannesburg",
                State = "Gauteng",
                PostalCode = "1627",
                Country = "South Africa",
                Phone = "+27 11 555 1002",
                Email = "airport@leasing.co.za",
                Manager = "Mike Davis",
                OpeningHours = "Mon-Sun 6AM-10PM",
                BranchCode = "ORT002",
                EstablishmentDate = DateTime.Now.AddDays(-45),
                IsActive = true,
                Description = "Convenient airport location"
            };

            var branch3 = new Branch
            {
                Name = "Cape Town CBD Branch",
                Address = "300 Adderley Street",
                City = "Cape Town",
                State = "Western Cape",
                PostalCode = "8001",
                Country = "South Africa",
                Phone = "+27 21 555 1003",
                Email = "cbd@leasing.co.za",
                Manager = "Lisa Anderson",
                OpeningHours = "Mon-Fri 9AM-7PM, Sat 10AM-5PM",
                BranchCode = "CT003",
                EstablishmentDate = DateTime.Now.AddDays(-40),
                IsActive = true,
                Description = "Cape Town CBD location"
            };

            context.Branches.AddRange(new[] { branch1, branch2, branch3 });

            // Seed Clients
            var client1 = new Client
            {
                CompanyName = "Johannesburg Tech Solutions",
                ContactPerson = "Robert Mokoena",
                Address = "500 Commissioner Street",
                City = "Johannesburg",
                State = "Gauteng",
                PostalCode = "2000",
                Country = "South Africa",
                Phone = "+27 11 555 2001",
                Email = "robert@joburgtech.co.za",
                Website = "www.joburgtech.co.za",
                TaxId = "VAT001",
                BusinessLicense = "BL001",
                RegistrationDate = DateTime.Now.AddDays(-15),
                IsActive = true,
                Notes = "Technology consulting firm",
                CreditLimit = 500000.00m,
                PaymentTerms = "Net 30"
            };

            var client2 = new Client
            {
                CompanyName = "Cape Town Logistics",
                ContactPerson = "Jennifer van der Merwe",
                Address = "600 Long Street",
                City = "Cape Town",
                State = "Western Cape",
                PostalCode = "8001",
                Country = "South Africa",
                Phone = "+27 21 555 2002",
                Email = "jennifer@ctlogistics.co.za",
                Website = "www.ctlogistics.co.za",
                TaxId = "VAT002",
                BusinessLicense = "BL002",
                RegistrationDate = DateTime.Now.AddDays(-10),
                IsActive = true,
                Notes = "International logistics company",
                CreditLimit = 750000.00m,
                PaymentTerms = "Net 45"
            };

            var client3 = new Client
            {
                CompanyName = "Durban Renewable Energy",
                ContactPerson = "Thomas Ndlovu",
                Address = "700 Musgrave Road",
                City = "Durban",
                State = "KwaZulu-Natal",
                PostalCode = "4001",
                Country = "South Africa",
                Phone = "+27 31 555 2003",
                Email = "thomas@durbanenergy.co.za",
                Website = "www.durbanenergy.co.za",
                TaxId = "VAT003",
                BusinessLicense = "BL003",
                RegistrationDate = DateTime.Now.AddDays(-5),
                IsActive = true,
                Notes = "Renewable energy company",
                CreditLimit = 300000.00m,
                PaymentTerms = "Net 30"
            };

            context.Clients.AddRange(new[] { client1, client2, client3 });

            // Seed Drivers
            var driver1 = new Driver
            {
                FirstName = "James",
                LastName = "Mokoena",
                DriverLicenseNumber = "DL001",
                LicenseExpiryDate = DateTime.Now.AddYears(2),
                Phone = "+27 11 555 3001",
                Email = "james.mokoena@email.com",
                Address = "100 Commissioner Street",
                City = "Johannesburg",
                State = "Gauteng",
                PostalCode = "2000",
                Country = "South Africa",
                DateOfBirth = new DateTime(1985, 3, 15),
                HireDate = DateTime.Now.AddDays(-30),
                IsActive = true,
                EmergencyContact = "Jane Mokoena",
                EmergencyPhone = "+27 11 555 3002",
                Notes = "Experienced driver with clean record"
            };

            var driver2 = new Driver
            {
                FirstName = "Maria",
                LastName = "van der Merwe",
                DriverLicenseNumber = "DL002",
                LicenseExpiryDate = DateTime.Now.AddYears(1),
                Phone = "+27 21 555 3003",
                Email = "maria.vandermerwe@email.com",
                Address = "200 Long Street",
                City = "Cape Town",
                State = "Western Cape",
                PostalCode = "8001",
                Country = "South Africa",
                DateOfBirth = new DateTime(1990, 7, 22),
                HireDate = DateTime.Now.AddDays(-25),
                IsActive = true,
                EmergencyContact = "Carlos van der Merwe",
                EmergencyPhone = "+27 21 555 3004",
                Notes = "Commercial license holder"
            };

            var driver3 = new Driver
            {
                FirstName = "Michael",
                LastName = "Ndlovu",
                DriverLicenseNumber = "DL003",
                LicenseExpiryDate = DateTime.Now.AddYears(3),
                Phone = "+27 31 555 3005",
                Email = "michael.ndlovu@email.com",
                Address = "300 Musgrave Road",
                City = "Durban",
                State = "KwaZulu-Natal",
                PostalCode = "4001",
                Country = "South Africa",
                DateOfBirth = new DateTime(1988, 11, 8),
                HireDate = DateTime.Now.AddDays(-20),
                IsActive = true,
                EmergencyContact = "Sarah Ndlovu",
                EmergencyPhone = "+27 31 555 3006",
                Notes = "CDL license holder"
            };

            context.Drivers.AddRange(new[] { driver1, driver2, driver3 });

            // Seed Vehicles
            var vehicle1 = new Vehicle
            {
                LicensePlate = "GP 123-456",
                Make = "Toyota",
                Model = "Corolla",
                Year = 2022,
                Color = "Silver",
                FuelType = "Petrol",
                EngineSize = 1.8m,
                Mileage = 15000,
                DailyRate = 1200.00m,
                Status = "Available",
                RegistrationDate = DateTime.Now.AddDays(-30),
                LastServiceDate = DateTime.Now.AddDays(-10),
                NextServiceDue = DateTime.Now.AddDays(20),
                SupplierId = 1,
                BranchId = 1
            };

            var vehicle2 = new Vehicle
            {
                LicensePlate = "WC 789-012",
                Make = "Honda",
                Model = "Civic",
                Year = 2021,
                Color = "Blue",
                FuelType = "Petrol",
                EngineSize = 1.5m,
                Mileage = 25000,
                DailyRate = 1100.00m,
                Status = "Leased",
                RegistrationDate = DateTime.Now.AddDays(-25),
                LastServiceDate = DateTime.Now.AddDays(-15),
                NextServiceDue = DateTime.Now.AddDays(15),
                SupplierId = 2,
                BranchId = 2,
                ClientId = 1,
                DriverId = 1
            };

            var vehicle3 = new Vehicle
            {
                LicensePlate = "KZN 456-789",
                Make = "Ford",
                Model = "Ranger",
                Year = 2023,
                Color = "Red",
                FuelType = "Diesel",
                EngineSize = 2.2m,
                Mileage = 8000,
                DailyRate = 1500.00m,
                Status = "Available",
                RegistrationDate = DateTime.Now.AddDays(-20),
                LastServiceDate = DateTime.Now.AddDays(-5),
                NextServiceDue = DateTime.Now.AddDays(25),
                SupplierId = 3,
                BranchId = 3
            };

            var vehicle4 = new Vehicle
            {
                LicensePlate = "GP 987-654",
                Make = "Volkswagen",
                Model = "Golf",
                Year = 2022,
                Color = "Black",
                FuelType = "Petrol",
                EngineSize = 1.4m,
                Mileage = 18000,
                DailyRate = 1000.00m,
                Status = "Leased",
                RegistrationDate = DateTime.Now.AddDays(-15),
                LastServiceDate = DateTime.Now.AddDays(-8),
                NextServiceDue = DateTime.Now.AddDays(22),
                SupplierId = 1,
                BranchId = 1,
                ClientId = 2,
                DriverId = 2
            };

            var vehicle5 = new Vehicle
            {
                LicensePlate = "JKL012",
                Make = "Nissan",
                Model = "Altima",
                Year = 2023,
                Color = "White",
                FuelType = "Gasoline",
                EngineSize = 2.0m,
                Mileage = 12000,
                DailyRate = 72.00m,
                Status = "Available",
                RegistrationDate = DateTime.Now.AddDays(-10),
                LastServiceDate = DateTime.Now.AddDays(-3),
                NextServiceDue = DateTime.Now.AddDays(27),
                SupplierId = 2,
                BranchId = 2
            };

            context.Vehicles.AddRange(new[] { vehicle1, vehicle2, vehicle3, vehicle4, vehicle5 });

            context.SaveChanges();
        }
    }
} 