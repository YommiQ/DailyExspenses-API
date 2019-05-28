using DailyExpenses.Domain.Entities;
using System;

namespace DailyExpenses.Domain.IRepositories
{
    public interface IUserRepository
    {
        User GetById(Guid id);
        User GetByLoginOrEmail(string value);
        void Create(User entity);
    }
}
