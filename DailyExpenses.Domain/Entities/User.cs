using System;
using System.Collections.Generic;
using System.Text;

namespace DailyExpenses.Domain.Entities
{
    public class User
    {
        public string Email { get; set; }
        public string Login { get; set; }
        public bool IsActive { get; set; }

        public byte[] PasswordSalt { get; set; }
        public byte[] PasswordHash { get; set; }
    }
}
