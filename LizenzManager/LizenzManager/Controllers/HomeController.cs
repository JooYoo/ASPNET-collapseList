using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LizenzManager.Models;

namespace LizenzManager.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(Credentials inputCredentials)
        {

            return LogIn(inputCredentials);
        }

        public ActionResult LogInSucceeded()
        {
            List<License> allLicenses = new List<License>
            {
                new License("License1" , "key1234", new Seat("Seat1"), new DateTime(2018,12,30)),
                new License("License2" , "key12345", new Seat("Seat2"), new DateTime(2018,12,25), "Note 123"),
                new License("License3" , "key123456", new Seat("Seat3"), new DateTime(2018,12,20)),
                new License("License4" , "key1234567", new Seat("Seat4"), new DateTime(2018,12,15))
            };
            return View(allLicenses);
        }

        public ActionResult LogInUnAuthorized()
        {
            return View();
        }

        public ActionResult LogInFailed()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public RedirectResult LogIn(Credentials inputCredentials)
        {
            List<Credentials> dataBase = new List<Credentials>
            {
                new Credentials("Test", "1234", true),
                new Credentials("Bob", "123", false)
            };

            bool login = true;
            bool authorized = true;

            foreach (var credential in dataBase)
            {
                if (inputCredentials.Username != credential.Username || inputCredentials.Password != credential.Password)
                {
                    login = false;
                }
                else
                {
                    if (!credential.Authorized)
                    {
                        login = true;
                        authorized = false;
                    }
                    else
                    {
                        login = true;
                        authorized = true;
                        break;
                    }
                }

            }

            if (login && authorized)
            {
                return Redirect("/Home/LogInSucceeded");
            }
            else if (login && !authorized)
            {
                return Redirect("/Home/LogInUnAuthorized");
            }
            else
            {
                return Redirect("/Home/LogInFailed");
            }
        }
    }
}