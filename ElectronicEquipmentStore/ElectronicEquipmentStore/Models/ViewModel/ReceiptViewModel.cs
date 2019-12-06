using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ElectronicEquipmentStore.Models.ViewModel
{
    public class ReceiptViewModel
    {
        public List<Receipt> Receipts { get; set; }
        public PagingInfo PagingInfo { get; set; }
    }
}
