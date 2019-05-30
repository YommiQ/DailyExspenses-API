using DailyExpenses.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace DailyExpenses.DataLayer
{
    public class DailyExpensesContext : DbContext
    {
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<ExpensesTemplate> ExpensesTemplates { get; set; }
        public virtual DbSet<ExpensesTemplateDetail> ExpensesTemplateDetails { get; set; }

        public DailyExpensesContext(DbContextOptions options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
        }
    }
}
