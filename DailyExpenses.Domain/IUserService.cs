namespace DailyExpenses.Domain
{
    public interface IUserService
    {
        void Create(string email, string password, string passwordConfirm);
    }
}
