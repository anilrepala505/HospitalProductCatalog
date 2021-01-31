using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalProductCatalog.ViewModels
{
    public class SaveProductResource
    {
        [Required]
        [MaxLength(50)]
        public string Description { get; set; }

        [Required]
        [Range(0, 100)]
        public short QuantityInPackage { get; set; }

        [Required]
        [Range(1, 6)]
        public int UnitOfMeasurement { get; set; } // AutoMapper is going to cast it to the respective enum value

        [Required]
        public int CategoryId { get; set; }

        [Required]
        public DateTime ExiprationDate { get; set; }
    }
}
