using System;
using System.Security.Cryptography;
using System.Text;
using Domain.Entities;

namespace Domain.Services
{
    public static class PasswordEncryptionService
    {
        public static bool CheckPassword(User user, string password)
        {
            SHA512 hashtool = SHA512.Create();
            byte[] pass1 = hashtool.ComputeHash(Encoding.UTF8.GetBytes(password));
            string pass = BitConverter.ToString(pass1);
            byte[] pass2 = hashtool.ComputeHash(Encoding.UTF8.GetBytes(pass.Replace("-", "") + user.Salt));
            string passFinal = BitConverter.ToString(pass2).Replace("-", "");
            if (user.Password.Equals(passFinal))
                return true;
            else
                return false;
        }

        public static void Encrypt(User account)
        {
            SHA512 hashtool = SHA512.Create();
            byte[] pass1 = hashtool.ComputeHash(Encoding.UTF8.GetBytes(account.Password));
            string pass = BitConverter.ToString(pass1);
            byte[] salt1 = hashtool.ComputeHash(Encoding.UTF8.GetBytes(account.Email + account.Name));
            string salt = BitConverter.ToString(salt1);
            byte[] pass2 = hashtool.ComputeHash(Encoding.UTF8.GetBytes(pass.Replace("-", "") + salt.Replace("-", "")));
            string passFinal = BitConverter.ToString(pass2);
            account.Password = passFinal.Replace("-", "");
            account.Salt = salt.Replace("-", "");
        }
    }
}
