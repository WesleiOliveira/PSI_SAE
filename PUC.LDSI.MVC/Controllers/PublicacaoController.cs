using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions.Impl;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PUC.LDSI.Application.Interfaces;
using PUC.LDSI.DataBase;
using PUC.LDSI.Domain.Entities;
using PUC.LDSI.Domain.Interfaces.Repository;
using PUC.LDSI.Identity.Entities;
using PUC.LDSI.MVC.Models;

namespace PUC.LDSI.MVC.Controllers
{
    public class PublicacaoController : BaseController
    {
        private readonly IAvaliacaoAppService _avaliacaoAppService;
        private readonly ITurmaAppService _turmaAppService;
        private readonly IPublicacaoRepository _publicacaoRepository;

        public PublicacaoController(UserManager<Usuario> user,
            ITurmaAppService turmaAppService,
            IAvaliacaoAppService avaliacaoAppService,
            IPublicacaoRepository publicacaoRepository) : base(user)
        {
            _turmaAppService = turmaAppService;
            _avaliacaoAppService = avaliacaoAppService;
            _publicacaoRepository = publicacaoRepository;;
        }

        public async Task<IActionResult> Index()
        {
            var result = _publicacaoRepository.ListarPublicacoesDoProfessorAsync(UsuarioLogado.IntegrationId);
            var publicacoes = Mapper.Map<List<PublicacaoViewModel>>(result.Result);
            return View(publicacoes);
        }

        public IActionResult Create()
        {
            var turmas = _turmaAppService.ListarTurmas();
            var avaliacoes = _avaliacaoAppService.ListarAvaliacoes();

            List<SelectListItem> ObterTurmas()
            {
                var lista = new List<SelectListItem>();
                turmas.Data.ForEach(x => {
                    lista.Add( new SelectListItem { Text = x.Nome, Value = x.Id.ToString(), Selected = false } );
                });
                return lista;
            }

            List<SelectListItem> ObterAvaliacoes()
            {
                var lista = new List<SelectListItem>();
                avaliacoes.Data.ForEach(x =>
                {
                    lista.Add(new SelectListItem { Text = x.Descricao, Value = x.Id.ToString(), Selected = false });
                });
                return lista;
            }

            ViewData["Turmas"] = ObterTurmas();
            ViewData["Avaliacoes"] = ObterAvaliacoes();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("AvaliacaoId, TurmaId, DataInicio, DataFim, ValorProva")] Publicacao publicacao)
        {
            
            if (ModelState.IsValid)
            {
                var result = await _avaliacaoAppService.AdicionarPublicacaoAsync(UsuarioLogado.IntegrationId, publicacao.AvaliacaoId, publicacao.TurmaId, publicacao.DataInicio, publicacao.DataFim, publicacao.ValorProva);
                _publicacaoRepository.SaveChanges();

                if (result.Success)
                    return RedirectToAction(nameof(Index));
                else
                    throw result.Exception;
            }
            return View(publicacao);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var avaliacao = await _publicacaoRepository.ObterAsync(id.Value);

            if (avaliacao == null)
            {
                return NotFound();
            }

            var viewModel = Mapper.Map<AvaliacaoViewModel>(avaliacao);

            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public async Task<IActionResult> Edit(int id, [Bind("professorId, id, dataInicio, dataFim, valorProva")] Publicacao publicacao)
        {
            if (id != publicacao.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                var result = await _avaliacaoAppService.AlterarPublicacaoAsync(UsuarioLogado.IntegrationId, publicacao.Id, publicacao.DataInicio, publicacao.DataFim, publicacao.ValorProva);

                if (result.Success)
                    return RedirectToAction(nameof(Index));
                else
                    throw result.Exception;
            }
            return View(publicacao);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var publicacao = await _publicacaoRepository.ObterAsync(id.Value);

            if (publicacao == null)
            {
                return NotFound();
            }

            var viewModel = Mapper.Map<PublicacaoViewModel>(publicacao);

            return View(viewModel);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id, Publicacao publicacao)
        {
            var result = await _avaliacaoAppService.ExcluirPublicacaoAsync(UsuarioLogado.IntegrationId, publicacao.Id);

            if (result.Success)
                return RedirectToAction(nameof(Index));
            else
                throw result.Exception;
        }
    }
}