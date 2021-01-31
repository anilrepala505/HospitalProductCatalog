using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalProductCatalog.ViewModels
{
    public class ProductResource
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public int QuantityInPackage { get; set; }
        public string UnitOfMeasurement { get; set; }
        public DateTime ExiprationDate { get; set; }
        public CategoryResource Category { get; set; }
        public IList<BarcodeResource> Barcodes { get; set; } = new List<BarcodeResource>();
    }
}
