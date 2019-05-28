using DailyExpenses.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace DailyExpenses.DataLayer
{
    public class DailyExpensesContext : DbContext
    {
        public virtual DbSet<User> Users { get; set; }

        public DailyExpensesContext(DbContextOptions options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
        }
    }
}
