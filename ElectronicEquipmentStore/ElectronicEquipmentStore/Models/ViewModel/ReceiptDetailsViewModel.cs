using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ElectronicEquipmentStore.Models.ViewModel
{
    public class ReceiptDetailsViewModel
    {
        public Receipt Receipt { get; set; }
        public List<ApplicationUser> SalePerson { get; set; }
        public List<Product> Products { get; set; }
    }
}
