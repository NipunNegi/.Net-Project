using BO;
using System.Web;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class UserDAL
    {
        private readonly HotelDBMSEntities DatabaseEntity;

        public UserDAL()
        {

            DatabaseEntity = new HotelDBMSEntities();
        }

        public String Login(string email, string password)
        {
            using (var ctx = new HotelDBMSEntities())
            {
                var user = (from s in ctx.Users
                            where s.UserEmail == email && s.Password == password
                            select s.UserName).ToList();
                if (user.Any())
                {
                    return user.FirstOrDefault();
                }
                return "";
            };
        }

        public String AddUser(UserModel userObj)
        {
            using (var ctx = new HotelDBMSEntities())
            {
                var userCheck = (from s in ctx.Users
                            where s.UserEmail == userObj.UserEmail
                            select s.UserName).ToList();
                if (!userCheck.Any())
                {
                    User user = new User()
                    {
                        UserName = userObj.UserName,
                        UserEmail = userObj.UserEmail.ToLower(),
                        UserAddress = userObj.UserAddress,
                        PhoneNum = userObj.PhoneNumber,
                        Password = userObj.Password,
                    };
                    DatabaseEntity.Users.Add(user);
                    var result = DatabaseEntity.SaveChanges();
                    if (result > 0)
                        return "Done";
                    return "Fail";
                }
                else
                return "Exist";
            };

        }
        //public UserModel CheckUser(String email, String password)
        //{
        //    using (var ctx = new HotelDBMSEntities())
        //    {
        //        var userd = ctx.Users.FirstOrDefault(S => S.UserEmail == email && S.Password == password);
        //        if(user)
        //        return 
        //}
        

    }
}
