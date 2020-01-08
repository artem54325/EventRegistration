using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using EventRegistration.Models;
using Newtonsoft.Json.Linq;

namespace EventRegistration.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationContext applicationContext;

        public HomeController (ApplicationContext application)
        {
            applicationContext = application;
        }

        public IActionResult Index()
        {
            //Проверить пользователя на регистрацию по куки, если она уже была то перекинуть, а если не была, то на сайт для регистрации
            return View();
        }

        [HttpPost]
        public async Task<JObject> UserRegistrationAsync(UserEventRegistration user)
        {
            JObject j = new JObject();

            applicationContext.Add(user);

            await applicationContext.SaveChangesAsync();

            return j;
        }

    }
}
