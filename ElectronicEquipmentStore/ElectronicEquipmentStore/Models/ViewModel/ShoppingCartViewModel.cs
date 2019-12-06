﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ElectronicEquipmentStore.Models.ViewModel
{
    public class ShoppingCartViewModel
    {
        public List<Product> Products { get; set; }
        public Receipt Receipt { get; set; }
    }
}
