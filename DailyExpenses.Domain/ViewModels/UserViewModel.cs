using System;

namespace DailyExpenses.Domain.ViewModels
{
    public class UserViewModel
    {
        public Guid Id { get; set; }
        public string Email { get; set; }
        public string Token { get; set; }

    }
}
