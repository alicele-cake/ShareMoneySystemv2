using Microsoft.EntityFrameworkCore;
using MVC_crud.Models.Entities;
namespace MVC_crud.Data
{
    public class MVCDBContext : DbContext
    {
        public MVCDBContext(DbContextOptions<MVCDBContext> options) : base(options)
        {
        }

        public DbSet<Account> Accounts { get; set; }
        public DbSet<Bill> Bills { get; set; }
        public DbSet<Bill_Detail> Bill_Details { get; set; }
        public DbSet<BillTable> BillTables { get; set; }
        public DbSet<Friends> Friendss { get; set; }
        public DbSet<CheckFriends> CheckFriendss { get; set; }
    }
}
