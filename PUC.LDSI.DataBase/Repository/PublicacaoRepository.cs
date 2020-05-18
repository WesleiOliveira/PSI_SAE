using Microsoft.EntityFrameworkCore;
using PUC.LDSI.Domain.Entities;
using PUC.LDSI.Domain.Interfaces.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PUC.LDSI.DataBase.Repository
{
    public class PublicacaoRepository : Repository<Publicacao>, IPublicacaoRepository
    {
        private readonly AppDbContext _context;

        public PublicacaoRepository(AppDbContext context) : base(context) 
        {
            _context = context;
        }

        public async Task<List<Publicacao>> ListarPublicacoesDoProfessorAsync(int id)
        {
            return await _context.Publicacao.Include(x => x.Avaliacao).Include(x => x.Turma).Where(x => x.Id == id).ToListAsync();
        }

        public Task<List<Publicacao>> ListarPublicacoesDoAlunoAsync(int id)
        {
            var publicacao = _context.Publicacao.Include(x => x.Avaliacao).ThenInclude(x => x.Provas).Include(x => x.Turma).ThenInclude(x => x.Alunos)
                .Where(x => x.Turma.Alunos.Any(z => z.Id == id)).ToListAsync();

            return publicacao;
        }
    }
}
