using System.Collections.Generic;
using BTC_Rate.Models;
using System.Web.Mvc;

namespace BTC_Rate.Controllers
{
    public class LoginController : Controller
    {
        // GET: cheking emai & pass
        public bool GetUser(string email, string pass)
        {
            UserService service = new UserService();
            List<User> users = new List<User>(service.GetUsers());
            if (service.isContain(email))
            {
                foreach (User u in users)
                {
                    if (u.Email == email)
                    {
                        if (u.Pass == pass)
                        {
                            return true;
                        }
                    }
                }
            }
            return false;
        }
    }
}