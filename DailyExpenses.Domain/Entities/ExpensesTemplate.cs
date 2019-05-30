using System.Collections.Generic;

namespace DailyExpenses.Domain.Entities
{
    public class ExpensesTemplate
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public decimal TotalSum { get; set; }

        public User User { get; set; }
        public ICollection<ExpensesTemplateDetail> ExpensesTemplateDetails { get; set;}
    }
}
