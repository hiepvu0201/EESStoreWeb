﻿using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ElectronicEquipmentStore.Models
{
    public class ApplicationUser:IdentityUser
    {
        [Display(Name="Nhân viên")]
        public  string Name { get; set; }

        [NotMapped]
        public bool IsSuperAdmin { get; set; }
    }
}
