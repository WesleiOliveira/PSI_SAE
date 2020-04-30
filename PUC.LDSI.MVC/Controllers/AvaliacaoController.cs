using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PUC.LDSI.DataBase;
using PUC.LDSI.Domain.Entities;
using PUC.LDSI.Domain.Interfaces.Repository;
using PUC.LDSI.Application.Interfaces;
using AutoMapper;
using PUC.LDSI.MVC.Models;
using Microsoft.AspNetCore.Identity;
using PUC.LDSI.Identity.Entities;

namespace PUC.LDSI.MVC.Controllers
{
    public class AvaliacaoController : BaseController
    {
        private readonly IAvaliacaoAppService _avalicaoAppService;
        private readonly IAvaliacaoRepository _avaliacaoRepository;

        public AvaliacaoController(UserManager<Usuario> user,
                        IAvaliacaoAppService avalicaoAppService,
                        IAvaliacaoRepository avalicaoRepository) : base(user)
        {
            _avalicaoAppService = avalicaoAppService;
            _avaliacaoRepository = avalicaoRepository;
        }

        //public TurmaController(UserManager<Usuario> user,
        //               ITurmaAppService turmaAppService,
        //               ITurmaRepository turmaRepository) : base(user)
        //{
        //    _turmaAppService = turmaAppService;
        //    _turmaRepository = turmaRepository;
        //}

        public async Task<IActionResult> Index()
        {
            var result = _avaliacaoRepository.ObterTodos();

            var avaliacoes = Mapper.Map<List<AvaliacaoViewModel>>(result.ToList());

            return View(avaliacoes);
        }

        // GET: Turma/Create
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Disciplina,Materia,Descricao,Id")] AvaliacaoViewModel avaliacao)
        {
            if (ModelState.IsValid)
            {
                var result = await _avalicaoAppService.AdicionarAvaliacaoAsync(1, avaliacao.Disciplina, avaliacao.Materia, avaliacao.Descricao);

                if (result.Success)
                    return RedirectToAction(nameof(Index));
                else
                    throw result.Exception;
            }
            return View(avaliacao);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var opcao = await _avaliacaoRepository.ObterAsync(id.Value);

            if (opcao == null)
            {
                return NotFound();
            }

            var viewModel = Mapper.Map<AvaliacaoViewModel>(opcao);

            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Disciplina,Materia,Descricao,Id")] AvaliacaoViewModel avaliacao)
        {
            if (id != avaliacao.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                var result = await _avalicaoAppService.AlterarAvaliacaoAsync(avaliacao.Id, avaliacao.Disciplina, avaliacao.Materia, avaliacao.Descricao);

                if (result.Success)
                    return RedirectToAction(nameof(Index));
                else
                    throw result.Exception;
            }
            return View(avaliacao);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var avaliacao = await _avaliacaoRepository.ObterAsync(id.Value);

            if (avaliacao == null)
            {
                return NotFound();
            }

            var viewModel = Mapper.Map<AvaliacaoViewModel>(avaliacao);

            return View(viewModel);
        }

        // POST: Turma/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var result = await _avalicaoAppService.ExcluirAvaliacaoAsync(id);

            if (result.Success)
                return RedirectToAction(nameof(Index));
            else
                throw result.Exception;
        }
    }
}