using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace PUC.LDSI.MVC.Controllers
{
    public class OpcaoAvaliacaoController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}