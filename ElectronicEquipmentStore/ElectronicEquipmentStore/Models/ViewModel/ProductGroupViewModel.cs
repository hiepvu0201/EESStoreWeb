using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ElectronicEquipmentStore.Models.ViewModel
{
    public class ProductGroupViewModel
    {
        public ProductGroup ProductGroup { get; set; }
        public IEnumerable<Category> Categories { get; set; }
    }
}
