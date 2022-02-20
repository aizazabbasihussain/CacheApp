using CacheApp.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CacheApp.Store
{
    public static class UserValidate
    {
        public static async Task<UserModel> Login(string username, string password)
        {
            bool isValid = string.Equals(username, "admin", StringComparison.InvariantCultureIgnoreCase) && password.Equals("admin123");

            // return null if user not valid
            if (isValid)
                return new UserModel() { UserName = username };
            else
                return null;
        }
    }
}
