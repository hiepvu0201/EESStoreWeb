using ElectronicEquipmentStore.Models;
using ElectronicEquipmentStore.Utility;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ElectronicEquipmentStore.Data
{
    public class DbInitializer:IDbInitializer
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public DbInitializer(ApplicationDbContext context, UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            _context = context;
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public async void Initialize()
        {
            if(_context.Database.GetPendingMigrations().Count()>0)
            {
                _context.Database.Migrate();
            }
            

            if (_context.Roles.Any(r => r.Name == SD.SuperAdminEndUser)) return;

            _roleManager.CreateAsync(new IdentityRole(SD.AdminEndUser)).GetAwaiter().GetResult();
            _roleManager.CreateAsync(new IdentityRole(SD.SuperAdminEndUser)).GetAwaiter().GetResult();

            _userManager.CreateAsync(new ApplicationUser
            {
                UserName="admin@gmail.com",
                Email="admin@gmail.com",
                Name="Admin dep trai",
                EmailConfirmed=true
            },"Admin123*").GetAwaiter().GetResult();

            IdentityUser user = await _context.Users.Where(u => u.Email == "admin@gmail.com").FirstOrDefaultAsync();

            await _userManager.AddToRoleAsync(user,SD.SuperAdminEndUser);
        }
    }
}
 