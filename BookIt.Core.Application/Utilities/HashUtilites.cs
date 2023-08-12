using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace BookIt.Core.Application.Utilities
{
    public static class HashUtilites
    {
        public static string HashString(string str, string secretKey)
        {
            // convert str and secretKey to byte arrays (Because you can only hash byte arrays)
            byte[] strBytes = Encoding.UTF8.GetBytes(str);
            byte[] secretKeyBytes = Encoding.UTF8.GetBytes(secretKey);

            // Hash byte array
            using(var hmac = new HMACSHA512(secretKeyBytes))
            {
                byte[] hashedBytes = hmac.ComputeHash(strBytes);

               // return hashed byte array as string
                return Convert.ToBase64String(hashedBytes).Replace("-", "");
            }
        }
    }
}
