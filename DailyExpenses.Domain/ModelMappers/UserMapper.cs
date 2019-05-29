using DailyExpenses.Domain.Entities;
using DailyExpenses.Domain.ViewModels;

namespace DailyExpenses.Domain.ModelMappers
{
    public static class UserMapper
    {
        public static UserViewModel GetViewModel(this User model)
        {
            return new UserViewModel
            {
                Id = model.Id,
                Email = model.Email
            };
        }
    }
}
