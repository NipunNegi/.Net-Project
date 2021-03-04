using BO;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Threading.Tasks;
using System.Web;

namespace BL
{
    public class UserBL
    {

        public string Login(string email, string password)
        {
            email = email.ToLower();
            string userPassword = CreateMD5(password);
            string userName = new UserDAL().Login(email, userPassword);
            if (userName !=""||userName != null)
                 return userName;
            
            else
                 return "";
        }
        public String AddUser(UserModel userObj)
        {
            userObj.Password = CreateMD5(userObj.Password);
            var response= new UserDAL().AddUser(userObj);
            return response;
        }
        public static string CreateMD5(string input)
        {
            // Use input string to calculate MD5 hash
            using (System.Security.Cryptography.MD5 md5 = System.Security.Cryptography.MD5.Create())
            {
                byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(input);
                byte[] hashBytes = md5.ComputeHash(inputBytes);

                // Convert the byte array to hexadecimal string
                StringBuilder sb = new StringBuilder();
                for (int i = 0; i < hashBytes.Length; i++)
                {
                    sb.Append(hashBytes[i].ToString("X2"));
                }
                return sb.ToString();
            }
        }
    }
}
