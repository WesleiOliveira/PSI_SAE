using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using PUC.LDSI.Identity.Entities;

namespace PUC.LDSI.MVC.Controllers
{
    public class OpcaoAvaliacaoController : BaseController
    {
        public OpcaoAvaliacaoController(UserManager<Usuario> user) : base(user)
        {
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}