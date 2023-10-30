using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using WearHouse.Models;

namespace WearHouse.Database
{
    public class WearHouseContext : IdentityDbContext
    {
        public WearHouseContext(DbContextOptions options) : base(options)
        {

        }

        public  DbSet<Category> Category { get; set; }
    }
}
