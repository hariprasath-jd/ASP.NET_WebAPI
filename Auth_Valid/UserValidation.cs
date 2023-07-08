using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Web;
using WebAPI_Main.Models;

namespace WebAPI_Main.Auth_Valid
{
    public class UserValidation
    {
        
        public static bool Login(string username, string password)
        {
            //try
            //{
                Models.AppContext appContext = new Models.AppContext();
                return appContext.LoginDatas.Any(user => user.Username.Equals(username) && user.Password.Equals(password));
               
            //    if (data.Username == username)
            //    {
            //        if (data.Password == password)
            //        {

            //            return true;
            //        }
            //        else
            //        {
            //            return false;
            //        }
            //    }
            //    else
            //    {
            //        return false;
            //    }
            //}
            //catch(Exception)
            //{
            //    return false;
            //}
        }

        public static LoginData UserDetails(string username, string password)
        {
            Models.AppContext appContext = new Models.AppContext();
            return appContext.LoginDatas.Where(user => user.Username.Equals(username) && user.Password.Equals(password)).FirstOrDefault();
        }
    }
}