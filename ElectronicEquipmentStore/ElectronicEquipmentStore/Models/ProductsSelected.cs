using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ElectronicEquipmentStore.Models
{
    public class ProductsSelected
    {
        public int Id { get; set; }

        public int ReceiptId { get; set; }

        [ForeignKey("ReceiptId")]
        public virtual Receipt Receipt { get; set; }

        public string ProductId { get; set; }

        [ForeignKey("ProductId")]
        public virtual Product Product { get; set; }
    }
}
