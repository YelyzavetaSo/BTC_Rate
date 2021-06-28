using System;
using System.Web.Mvc;
using BTC_Rate.Models;

namespace BTC_Rate.Controllers
{
    public class CreateController : Controller
    {
        //POST: updates existing record
        public void PostUser(string email, string pass)
        {
            UserService service = new UserService();
            User u = new User { Email = email, Pass = pass };
            try
            {
                if (!service.isContain(email))//in case DB does not contain such 
                {
                    service.Add(u);
                }
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }
        }
    }
}