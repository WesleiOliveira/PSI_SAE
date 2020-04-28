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
    public class TurmaController : Controller
    {
        private readonly ITurmaAppService _turmaAppService;
        private readonly ITurmaRepository _turmaRepository;


        public TurmaController(UserManager<Usuario> user,
                       ITurmaAppService turmaAppService,
                       ITurmaRepository turmaRepository) : base()
        {
            _turmaAppService = turmaAppService;
            _turmaRepository = turmaRepository;
        }

        // GET: Turma
        public async Task<IActionResult> Index()
        {
            var result = _turmaRepository.ObterTodos();

            var turmas = Mapper.Map<List<TurmaViewModel>>(result.ToList());

            return View(turmas);
        }

        // GET: Turma/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Turma/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Nome,Id")] TurmaViewModel turma)
        {
            if (ModelState.IsValid)
            {
                var result = await _turmaAppService.AdicionarTurmaAsync(turma.Nome);

                if (result.Success)
                    return RedirectToAction(nameof(Index));
                else
                    throw result.Exception;
            }
            return View(turma);
        }

        // GET: Turma/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var turma = await _turmaRepository.ObterAsync(id.Value);

            if (turma == null)
            {
                return NotFound();
            }

            var viewModel = Mapper.Map<TurmaViewModel>(turma);

            return View(viewModel);
        }

        // POST: Turma/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Nome,Id")] TurmaViewModel turma)
        {
            if (id != turma.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                var result = await _turmaAppService.AlterarTurmaAsync(turma.Id, turma.Nome);

                if (result.Success)
                    return RedirectToAction(nameof(Index));
                else
                    throw result.Exception;
            }
            return View(turma);
        }

        // GET: Turma/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var turma = await _turmaRepository.ObterAsync(id.Value);

            if (turma == null)
            {
                return NotFound();
            }

            var viewModel = Mapper.Map<TurmaViewModel>(turma);

            return View(viewModel);
        }

        // POST: Turma/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var result = await _turmaAppService.ExcluirAsync(id);

            if (result.Success)
                return RedirectToAction(nameof(Index));
            else
                throw result.Exception;
        }
    }
}