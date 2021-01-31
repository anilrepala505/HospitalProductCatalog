using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalProductCatalog.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public short QuantityInPackage { get; set; }
        public UnitOfMeasurement UnitOfMeasurement { get; set; }
        public DateTime ExiprationDate { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }
        public IList<BarcodeList> Barcodes { get; set; } = new List<BarcodeList>();
    }
}
