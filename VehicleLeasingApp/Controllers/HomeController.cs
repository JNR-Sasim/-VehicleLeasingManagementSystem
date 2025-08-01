using System;
using System.Linq;
using System.Web.Mvc;
using VehicleLeasingApp.Models;
using System.Collections.Generic; // Added missing import for List

namespace VehicleLeasingApp.Controllers
{
    public class HomeController : Controller
    {
        private VehicleLeasingContext db = new VehicleLeasingContext();

        public ActionResult Index()
        {
            var dashboardViewModel = new DashboardViewModel
            {
                TotalVehicles = db.Vehicles.Count(),
                AvailableVehicles = db.Vehicles.Count(v => v.Status == "Available"),
                LeasedVehicles = db.Vehicles.Count(v => v.Status == "Leased"),
                TotalSuppliers = db.Suppliers.Count(),
                TotalBranches = db.Branches.Count(),
                TotalClients = db.Clients.Count(),
                TotalDrivers = db.Drivers.Count(),
                
                // Vehicle statistics by manufacturer
                VehicleStatsByManufacturer = db.Vehicles
                    .GroupBy(v => v.Make)
                    .Select(g => new VehicleManufacturerStats
                    {
                        Manufacturer = g.Key,
                        TotalVehicles = g.Count(),
                        AvailableVehicles = g.Count(v => v.Status == "Available"),
                        LeasedVehicles = g.Count(v => v.Status == "Leased"),
                        TotalDailyRate = g.Sum(v => v.DailyRate)
                    })
                    .OrderByDescending(s => s.TotalVehicles)
                    .ToList(),

                // Vehicle statistics by supplier
                VehicleStatsBySupplier = db.Vehicles
                    .GroupBy(v => v.Supplier.Name)
                    .Select(g => new VehicleSupplierStats
                    {
                        SupplierName = g.Key,
                        TotalVehicles = g.Count(),
                        AvailableVehicles = g.Count(v => v.Status == "Available"),
                        LeasedVehicles = g.Count(v => v.Status == "Leased"),
                        TotalDailyRate = g.Sum(v => v.DailyRate)
                    })
                    .OrderByDescending(s => s.TotalVehicles)
                    .ToList(),

                // Vehicle statistics by branch
                VehicleStatsByBranch = db.Vehicles
                    .GroupBy(v => v.Branch.Name)
                    .Select(g => new VehicleBranchStats
                    {
                        BranchName = g.Key,
                        TotalVehicles = g.Count(),
                        AvailableVehicles = g.Count(v => v.Status == "Available"),
                        LeasedVehicles = g.Count(v => v.Status == "Leased"),
                        TotalDailyRate = g.Sum(v => v.DailyRate)
                    })
                    .OrderByDescending(s => s.TotalVehicles)
                    .ToList(),

                // Vehicle statistics by client
                VehicleStatsByClient = db.Vehicles
                    .Where(v => v.Client != null)
                    .GroupBy(v => v.Client.CompanyName)
                    .Select(g => new VehicleClientStats
                    {
                        ClientName = g.Key,
                        TotalVehicles = g.Count(),
                        TotalDailyRate = g.Sum(v => v.DailyRate)
                    })
                    .OrderByDescending(s => s.TotalVehicles)
                    .ToList()
            };

            return View(dashboardViewModel);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }

    public class DashboardViewModel
    {
        public int TotalVehicles { get; set; }
        public int AvailableVehicles { get; set; }
        public int LeasedVehicles { get; set; }
        public int TotalSuppliers { get; set; }
        public int TotalBranches { get; set; }
        public int TotalClients { get; set; }
        public int TotalDrivers { get; set; }
        public List<VehicleManufacturerStats> VehicleStatsByManufacturer { get; set; }
        public List<VehicleSupplierStats> VehicleStatsBySupplier { get; set; }
        public List<VehicleBranchStats> VehicleStatsByBranch { get; set; }
        public List<VehicleClientStats> VehicleStatsByClient { get; set; }
    }

    public class VehicleManufacturerStats
    {
        public string Manufacturer { get; set; }
        public int TotalVehicles { get; set; }
        public int AvailableVehicles { get; set; }
        public int LeasedVehicles { get; set; }
        public decimal TotalDailyRate { get; set; }
    }

    public class VehicleSupplierStats
    {
        public string SupplierName { get; set; }
        public int TotalVehicles { get; set; }
        public int AvailableVehicles { get; set; }
        public int LeasedVehicles { get; set; }
        public decimal TotalDailyRate { get; set; }
    }

    public class VehicleBranchStats
    {
        public string BranchName { get; set; }
        public int TotalVehicles { get; set; }
        public int AvailableVehicles { get; set; }
        public int LeasedVehicles { get; set; }
        public decimal TotalDailyRate { get; set; }
    }

    public class VehicleClientStats
    {
        public string ClientName { get; set; }
        public int TotalVehicles { get; set; }
        public decimal TotalDailyRate { get; set; }
    }
} 