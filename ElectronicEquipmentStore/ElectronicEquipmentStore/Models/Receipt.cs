using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ElectronicEquipmentStore.Models
{
    public class Receipt
    {
        public int Id { get; set; }

        [Display(Name="Nhân viên bán hàng")]
        public string SalePersonID { get; set; }

        [ForeignKey("SalePersonID")]
        public virtual ApplicationUser SalePerson { get; set; }

        public DateTime ngayMua { get; set; }

        public string tenKH { get; set; }

        public string sdtKH { get; set; }

        public string emailKH { get; set; }

        public bool daThanhToan { get; set; }
    }
}
