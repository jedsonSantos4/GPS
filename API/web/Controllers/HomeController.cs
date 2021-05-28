using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using web.Models;
using Web.Model.Models;

namespace web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        private ActionResult RedirectViewErro()
        {            
            return RedirectToAction("Login", "Home");
        }
        //public IActionResult Index()
        //{
        //    var userInfo = JsonConvert.DeserializeObject<LogadoModel>
        //       (HttpContext.Session.GetString("SessioLogado"));


        //    return View();
        //}

        public IActionResult Privacy()
        {

            var viewDataVariavel = TempData["logado"] as LogadoModel;

            if (string.IsNullOrEmpty(HttpContext.Session.GetString("SessioLogado")))
            {
                return RedirectViewErro();
            }

            return View();
        }
        public IActionResult Login()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
