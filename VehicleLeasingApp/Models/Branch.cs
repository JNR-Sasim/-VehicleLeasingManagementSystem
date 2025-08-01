using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VehicleLeasingApp.Models
{
    public class Branch
    {
        public Branch()
        {
            Vehicles = new HashSet<Vehicle>();
        }

        [Key]
        public int BranchId { get; set; }

        [Required]
        [StringLength(100)]
        [Display(Name = "Branch Name")]
        public string Name { get; set; }

        [Required]
        [StringLength(200)]
        [Display(Name = "Address")]
        public string Address { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "City")]
        public string City { get; set; }

        [Required]
        [StringLength(20)]
        [Display(Name = "State/Province")]
        public string State { get; set; }

        [Required]
        [StringLength(10)]
        [Display(Name = "Postal Code")]
        public string PostalCode { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "Country")]
        public string Country { get; set; }

        [Required]
        [StringLength(20)]
        [Display(Name = "Phone")]
        [DataType(DataType.PhoneNumber)]
        public string Phone { get; set; }

        [StringLength(100)]
        [Display(Name = "Email")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [StringLength(50)]
        [Display(Name = "Manager")]
        public string Manager { get; set; }

        [Display(Name = "Opening Hours")]
        [StringLength(100)]
        public string OpeningHours { get; set; }

        [Display(Name = "Branch Code")]
        [StringLength(10)]
        public string BranchCode { get; set; }

        [Display(Name = "Establishment Date")]
        [DataType(DataType.Date)]
        public DateTime EstablishmentDate { get; set; } = DateTime.Now;

        [Display(Name = "Active")]
        public bool IsActive { get; set; } = true;

        [StringLength(500)]
        [Display(Name = "Description")]
        [DataType(DataType.MultilineText)]
        public string Description { get; set; }

        // Navigation Property
        public virtual ICollection<Vehicle> Vehicles { get; set; }
    }
} 