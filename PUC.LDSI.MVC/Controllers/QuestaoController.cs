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

namespace PUC.LDSI.MVC.Controllers
{
    public class questaoController : Controller
    {
        private readonly IquestaoAppService _questaoAppService;
        private readonly IquestaoRepository _questaoRepository;

        public questaoController(IquestaoAppService questaoAppService, IquestaoRepository questaoRepository)
        {
            _questaoAppService = questaoAppService;
            _questaoRepository = questaoRepository;
        }

        // GET: questao
        public async Task<IActionResult> Index()
        {
            var result = _questaoRepository.ObterTodos();

            var questaos = Mapper.Map<List<questaoViewModel>>(result.ToList());

            return View(questaos);
        }

        // GET: questao/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: questao/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Nome,Id")] questaoViewModel questao)
        {
            if (ModelState.IsValid)
            {
                var result = await _questaoAppService.AdicionarquestaoAsync(questao.Nome);

                if (result.Success)
                    return RedirectToAction(nameof(Index));
                else
                    throw result.Exception;
            }
            return View(questao);
        }

        // GET: questao/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var questao = await _questaoRepository.ObterAsync(id.Value);

            if (questao == null)
            {
                return NotFound();
            }

            var viewModel = Mapper.Map<questaoViewModel>(questao);

            return View(viewModel);
        }

        // POST: questao/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Nome,Id")] questaoViewModel questao)
        {
            if (id != questao.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                var result = await _questaoAppService.AlterarquestaoAsync(questao.Id, questao.Nome);

                if (result.Success)
                    return RedirectToAction(nameof(Index));
                else
                    throw result.Exception;
            }
            return View(questao);
        }

        // GET: questao/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var questao = await _questaoRepository.ObterAsync(id.Value);

            if (questao == null)
            {
                return NotFound();
            }

            var viewModel = Mapper.Map<questaoViewModel>(questao);

            return View(viewModel);
        }

        // POST: questao/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var result = await _questaoAppService.ExcluirAsync(id);

            if (result.Success)
                return RedirectToAction(nameof(Index));
            else
                throw result.Exception;
        }
    }
}