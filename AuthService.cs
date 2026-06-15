using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using LoginSystem.Context;
using LoginSystem.Models;
using Microsoft.EntityFrameworkCore;


namespace LoginSystem
{
    public static class AuthService
    {
        public static string HashPassword(string plainPassword)
        {
            return BCrypt.Net.BCrypt.HashPassword(plainPassword);
        }
        public static bool VerifyPassword(string plainPassword, string hashedPassword)
        {
            return BCrypt.Net.BCrypt.Verify(plainPassword, hashedPassword);
        }
        public static User Authenticate(string username, string password)
        {
            using var db = new AppDBcontext();
            var user = db.Users
                         .Include(u => u.UserRoles)
                         .ThenInclude(u => u.Role)
                         .FirstOrDefault(u => u.Username == username);
            if (user == null)
                return null;
            bool valid = VerifyPassword(password, user.PasswordHash);
            return valid ? user : null;
        }
        public static bool registerUser(string username, string email, string password, string rolename = "User")
        {
            using var db = new AppDBcontext();
            if (db.Users.Any(u => u.Username == username || u.Email == email))
                return false;

            var role = db.Roles.FirstOrDefault(r => r.Name == rolename);
            if (role == null) role = db.Roles.First(r => r.Name == "User");

            var user = new User
            {
                Username = username,
                Email = email,
                PasswordHash = HashPassword(password)
            };
            db.Users.Add(user);
            db.SaveChanges();

            db.UserRoles.Add(new Models.UserRole  {UserId = user.Id, RoleId = role.Id });
            db.SaveChanges();
            return true;
        }
        public static bool IsInRole(User user, string roleName)
        {
            return user.UserRoles.Any(ur => ur.Role.Name == roleName);
        }
    }
}
