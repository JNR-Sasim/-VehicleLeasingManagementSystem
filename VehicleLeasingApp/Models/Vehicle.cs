using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VehicleLeasingApp.Models
{
    public class Vehicle
    {
        [Key]
        public int VehicleId { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "License Plate")]
        public string LicensePlate { get; set; }

        [Required]
        [StringLength(100)]
        [Display(Name = "Make")]
        public string Make { get; set; }

        [Required]
        [StringLength(100)]
        [Display(Name = "Model")]
        public string Model { get; set; }

        [Required]
        [Display(Name = "Year")]
        public int Year { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "Color")]
        public string Color { get; set; }

        [Required]
        [StringLength(20)]
        [Display(Name = "Fuel Type")]
        public string FuelType { get; set; }

        [Required]
        [Display(Name = "Engine Size (L)")]
        public decimal EngineSize { get; set; }

        [Required]
        [Display(Name = "Mileage")]
        public int Mileage { get; set; }

        [Required]
        [Display(Name = "Daily Rate")]
        [DataType(DataType.Currency)]
        public decimal DailyRate { get; set; }

        [Display(Name = "Status")]
        public string Status { get; set; } = "Available";

        [Display(Name = "Registration Date")]
        [DataType(DataType.Date)]
        public DateTime RegistrationDate { get; set; } = DateTime.Now;

        [Display(Name = "Last Service Date")]
        [DataType(DataType.Date)]
        public DateTime? LastServiceDate { get; set; }

        [Display(Name = "Next Service Due")]
        [DataType(DataType.Date)]
        public DateTime? NextServiceDue { get; set; }

        // Foreign Keys
        [Required]
        [Display(Name = "Supplier")]
        public int SupplierId { get; set; }

        [Required]
        [Display(Name = "Branch")]
        public int BranchId { get; set; }

        [Display(Name = "Client")]
        public int? ClientId { get; set; }

        [Display(Name = "Driver")]
        public int? DriverId { get; set; }

        // Navigation Properties
        [ForeignKey("SupplierId")]
        public virtual Supplier Supplier { get; set; }

        [ForeignKey("BranchId")]
        public virtual Branch Branch { get; set; }

        [ForeignKey("ClientId")]
        public virtual Client Client { get; set; }

        [ForeignKey("DriverId")]
        public virtual Driver Driver { get; set; }
    }
} 