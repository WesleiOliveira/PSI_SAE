using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PUC.LDSI.DataBase;
using PUC.LDSI.Domain.Entities;
using PUC.LDSI.Domain.Interfaces.Repository;
using PUC.LDSI.Identity.Entities;
using PUC.LDSI.MVC.Models;

namespace PUC.LDSI.MVC.Controllers
{
    public class ProvaController : BaseController
    {
        private readonly IPublicacaoRepository _publicacaoRepository;

        public ProvaController(UserManager<Usuario> user,
            IPublicacaoRepository publicacaoRepository) : base(user)
        {
            _publicacaoRepository = publicacaoRepository;
        }

        public async Task<IActionResult> Index()
        {
            var result = await _publicacaoRepository.ListarPublicacoesDoAlunoAsync(UsuarioLogado.IntegrationId);
            var provas = Mapper.Map<List<ProvaPublicadaViewModel>>(result);
            return View(provas);
        }
    }
}
