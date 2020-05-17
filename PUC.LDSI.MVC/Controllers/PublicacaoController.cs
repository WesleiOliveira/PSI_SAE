using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions.Impl;
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
            private readonly IPublicacaoRepository _publicacaoRepository;
            private readonly IAvaliacaoAppService _avaliacaoAppService;


            public PublicacaoController(UserManager<Usuario> user,
                           IAvaliacaoAppService avaliacaoAppService,
                           IPublicacaoRepository publicacaoRepository) : base(user)
            {
                _publicacaoRepository = publicacaoRepository;
                _avaliacaoAppService = avaliacaoAppService;
            }


            // GET: Publicacao
            public async Task<IActionResult> Index()
            {
                var result = _publicacaoRepository.ObterTodos();
                var publicacoes = Mapper.Map<List<PublicacaoViewModel>>(result.ToList());

                return View(publicacoes);
            }

            /*
            // GET: Publicacao/Details/5
            public async Task<IActionResult> Details(int? id)
            {
                if (id == null)
                {
                    return NotFound();
                }
                var publicacao = await _context.Publicacao
                    .Include(p => p.Avaliacao)
                    .Include(p => p.Turma)
                    .FirstOrDefaultAsync(m => m.Id == id);
                if (publicacao == null)
                {
                    return NotFound();
                }
                return View(publicacao);
            }
            */

            /*
            // GET: Publicacao/Create
            public IActionResult Create()
            {
                ViewData["AvaliacaoId"] = new SelectList(_context.Avaliacao, "Id", "Descricao");
                ViewData["TurmaId"] = new SelectList(_context.Turma, "Id", "Nome");
                return View();
            }
            */

            // POST: Publicacao/Create
            // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
            // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
            [HttpPost]
            [ValidateAntiForgeryToken]
            public async Task<IActionResult> Create([Bind("AvaliacaoId,TurmaId,DataInicio,DataFim,ValorProva,Id,DataCriacao")] Publicacao publicacao)
            {
                if (ModelState.IsValid)
                {
                    _context.Add(publicacao);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }

                ViewData["AvaliacaoId"] = new SelectList(_context.Avaliacao, "Id", "Descricao", publicacao.AvaliacaoId);
                ViewData["TurmaId"] = new SelectList(_context.Turma, "Id", "Nome", publicacao.TurmaId);
                return View(publicacao);
            }

            // GET: Publicacao/Edit/5
            public async Task<IActionResult> Edit(int? id)
            {
                if (id == null)
                {
                    return NotFound();
                }

                var publicacao = await _context.Publicacao.FindAsync(id);
                if (publicacao == null)
                {
                    return NotFound();
                }
                ViewData["AvaliacaoId"] = new SelectList(_context.Avaliacao, "Id", "Descricao", publicacao.AvaliacaoId);
                ViewData["TurmaId"] = new SelectList(_context.Turma, "Id", "Nome", publicacao.TurmaId);
                return View(publicacao);
            }

            // POST: Publicacao/Edit/5
            // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
            // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
            [HttpPost]
            [ValidateAntiForgeryToken]
            public async Task<IActionResult> Edit(int id, [Bind("AvaliacaoId,TurmaId,DataInicio,DataFim,ValorProva,Id,DataCriacao")] Publicacao publicacao)
            {
                if (id != publicacao.Id)
                {
                    return NotFound();
                }

                if (ModelState.IsValid)
                {
                    try
                    {
                        _context.Update(publicacao);
                        await _context.SaveChangesAsync();
                    }
                    catch (DbUpdateConcurrencyException)
                    {
                        if (!PublicacaoExists(publicacao.Id))
                        {
                            return NotFound();
                        }
                        else
                        {
                            throw;
                        }
                    }
                    return RedirectToAction(nameof(Index));
                }
                ViewData["AvaliacaoId"] = new SelectList(_context.Avaliacao, "Id", "Descricao", publicacao.AvaliacaoId);
                ViewData["TurmaId"] = new SelectList(_context.Turma, "Id", "Nome", publicacao.TurmaId);
                return View(publicacao);
            }

            // GET: Publicacao/Delete/5
            public async Task<IActionResult> Delete(int? id)
            {
                if (id == null)
                {
                    return NotFound();
                }

                var publicacao = await _context.Publicacao
                    .Include(p => p.Avaliacao)
                    .Include(p => p.Turma)
                    .FirstOrDefaultAsync(m => m.Id == id);
                if (publicacao == null)
                {
                    return NotFound();
                }

                return View(publicacao);
            }

            // POST: Publicacao/Delete/5
            [HttpPost, ActionName("Delete")]
            [ValidateAntiForgeryToken]
            public async Task<IActionResult> DeleteConfirmed(int id)
            {
                var publicacao = await _context.Publicacao.FindAsync(id);
                _context.Publicacao.Remove(publicacao);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            /*
            private bool PublicacaoExists(int id)
            {
                return _context.Publicacao.Any(e => e.Id == id);
            }
            */
        }
    }