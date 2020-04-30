using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using PUC.LDSI.Application.Interfaces;
using PUC.LDSI.DataBase;
using PUC.LDSI.Domain.Interfaces.Repository;
using PUC.LDSI.Identity.Entities;
using PUC.LDSI.MVC.Models;

namespace PUC.LDSI.MVC.Controllers
{
    public class QuestaoAvaliacaoController : BaseController
    {
        private readonly IAvaliacaoAppService _avalicaoAppService;
        private readonly IAvaliacaoRepository _avaliacaoRepository;
        private readonly IQuestaoAvaliacaoRepository _questaoAvaliacaoRepository;
        private readonly IOpcaoAvaliacaoRepository _opcaoAvalicaoRepository;

        public QuestaoAvaliacaoController(UserManager<Usuario> user,
                        IAvaliacaoAppService avalicaoAppService,
                        IAvaliacaoRepository avalicaoRepository) : base(user)
        {
            _avalicaoAppService = avalicaoAppService;
            _avaliacaoRepository = avalicaoRepository;
        }

        public IActionResult Index()
        {
            var result = _avaliacaoRepository.ObterTodos();

            var questoes = Mapper.Map<List<QuestaoAvaliacaoViewModel>>(result.ToList());

            return View(questoes);
        }

        // GET: Turma/Create
        public IActionResult Create()
        {
            return View();
        }

        private List<SelectListItem> ObterOpcoesTipo(int tipoId = 0)
        {
            return new List<SelectListItem>() {
                new SelectListItem{ Text="Múltipla Escolha", Value = "1", Selected = tipoId == 1 },
                new SelectListItem{ Text="Verdadeiro ou Falso", Value = "2", Selected = tipoId == 2 }
            };
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Nome,Id")] QuestaoAvaliacaoViewModel questaoAvaliacao)
        {
            if (ModelState.IsValid)
            {
                var result = await _avalicaoAppService.AdicionarQuestaoAvaliacaoAsync(questaoAvaliacao.AvaliacaoId, questaoAvaliacao.Tipo, questaoAvaliacao.Enunciado);

                if (result.Success)
                    return RedirectToAction(nameof(Index));
                else
                    throw result.Exception;
            }
            return View(questaoAvaliacao);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var questao = await _questaoAvaliacaoRepository.ObterAsync(id.Value);

            if (questao == null)
            {
                return NotFound();
            }

            var viewModel = Mapper.Map<QuestaoAvaliacaoViewModel>(questao);

            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Nome,Id")] QuestaoAvaliacaoViewModel questao)
        {
            if (id != questao.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                var result = await _avalicaoAppService.AlterarQuestaoAvaliacaoAsync(questao.Id, questao.Tipo, questao.Enunciado);

                if (result.Success)
                    return RedirectToAction(nameof(Index));
                else
                    throw result.Exception;
            }
            return View(questao);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _avalicaoAppService.ExcluirQuestaoAvaliacaoAsync(id);

            if (result.Success)
                return RedirectToAction(nameof(Index));
            else
                throw result.Exception;
        }
    }
}