using DailyExpenses.Domain.ViewModels;

namespace DailyExpenses.Domain
{
    public interface IUserService
    {
        void Create(string email, string password, string passwordConfirm);
        UserViewModel Authenticate(string email, string password);
    }
}
