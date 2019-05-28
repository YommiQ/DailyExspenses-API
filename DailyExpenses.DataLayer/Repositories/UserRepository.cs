using System;
using System.Linq;
using DailyExpenses.Domain.Entities;
using DailyExpenses.Domain.IRepositories;

namespace DailyExpenses.DataLayer.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly DailyExpensesContext _context;

        public UserRepository(DailyExpensesContext context)
        {
            this._context = context;
        }

        public void Create(User entity)
        {
            _context.Users.Add(entity);
            _context.SaveChanges();
        }

        public User GetById(Guid id)
        {
            return _context.Users.Find(id);
        }

        public User GetByLoginOrEmail(string value)
        {
            return _context.Users.FirstOrDefault(u => u.Email.Equals(value, StringComparison.OrdinalIgnoreCase) 
                                                   || u.Login.Equals(value, StringComparison.OrdinalIgnoreCase));
        }
    }
}
