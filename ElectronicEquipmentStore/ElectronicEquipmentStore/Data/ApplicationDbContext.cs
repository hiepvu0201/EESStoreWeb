using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ElectronicEquipmentStore.Models;

namespace ElectronicEquipmentStore.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<ElectronicEquipmentStore.Models.Category> Category { get; set; }
        public DbSet<ElectronicEquipmentStore.Models.ProductGroup> ProductGroup { get; set; }
        public DbSet<ElectronicEquipmentStore.Models.Product> Product { get; set; }
        public DbSet<ElectronicEquipmentStore.Models.Customer> Customer { get; set; }
        public DbSet<ElectronicEquipmentStore.Models.Receipt> Receipt { get; set; }
        public DbSet<ElectronicEquipmentStore.Models.PurchaseHistory> PurchaseHistory { get; set; }
    }
}
