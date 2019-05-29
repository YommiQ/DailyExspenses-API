using System;
using System.ComponentModel.DataAnnotations;
using System.Security.Cryptography;
using System.Text;
using DailyExpenses.Domain.Entities;
using DailyExpenses.Domain.IRepositories;
using DailyExpenses.Domain.ModelMappers;
using DailyExpenses.Domain.ViewModels;

namespace DailyExpenses.Domain.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _repository;

        public UserService(IUserRepository repository)
        {
            _repository = repository;
        }

        public void Create(string email, string password, string passwordConfirm)
        {
            if (!password.Equals(passwordConfirm))
            {
                throw new ValidationException("Passwords are not equal.");
            }

            if (IsExists(email))
            {
                throw new ValidationException("Email is already exists.");
            }

            CreatePasswordHash(password, out var passwordHash, out var passwordSalt);

            _repository.Create(new User
            {
                Id = new Guid(),
                Email = email,
                IsActive = false,
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt
            });
        }

        public UserViewModel Authenticate(string email, string password)
        {
            var user = _repository.GetByLoginOrEmail(email);
            if (user == null)
            {
                throw new ArgumentNullException(nameof(user), "User is not found.");
            }

            if (!VerifyPasswordHash(password, user.PasswordHash, user.PasswordSalt))
            {
                throw new ValidationException("Password is incorrect.");
            }

            return user.GetViewModel();
        }

        #region Private

        private bool IsExists(string email)
        {
            var user = _repository.GetByLoginOrEmail(email);

            return user != null;
        }

        private void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            if (string.IsNullOrWhiteSpace(password))
            {
                throw new ArgumentException("Value cannot be empty or whitespace only string.", nameof(password));
            }

            using (var hmac = new HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
            }
        }

        private bool VerifyPasswordHash(string password, byte[] storedHash, byte[] storedSalt)
        {
            if (string.IsNullOrWhiteSpace(password))
            {
                throw new ArgumentException("Value cannot be empty or whitespace only string.", nameof(password));
            }

            if (storedHash.Length != 64)
            {
                throw new ArgumentException("Invalid length of password hash (64 bytes expected).", nameof(storedHash));
            }

            if (storedSalt.Length != 128)
            {
                throw new ArgumentException("Invalid length of password salt (128 bytes expected).", nameof(storedSalt));
            }

            using (var hmac = new HMACSHA512(storedSalt))
            {
                var computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
                for (var i = 0; i < computedHash.Length; i++)
                {
                    if (computedHash[i] != storedHash[i])
                        return false;
                }
            }

            return true;
        }

        #endregion
    }
}
