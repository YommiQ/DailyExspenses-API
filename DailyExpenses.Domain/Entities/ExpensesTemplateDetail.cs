namespace DailyExpenses.Domain.Entities
{
    public class ExpensesTemplateDetail
    {
        public string Title { get; set; }
        public string Price { get; set; }

        public ExpensesTemplate ExpensesTemplate { get; set; }
    }
}
