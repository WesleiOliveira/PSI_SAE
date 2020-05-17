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



        public override async Task<Publicacao> ObterAsync(int id)
        {
            return await _context.Publicacao.Include(x => x.Avaliacao).ThenInclude(y => y.Provas).FirstOrDefaultAsync(z => z.Id == id);
        }




        public async Task<List<Publicacao>> ListarPublicacoesDoProfessorAsync(int id)
        {
            return await _context.Publicacao.Include(x => x.Avaliacao).Include(x => x.Turma).Where(x => x.Id == id).ToListAsync();
        }
    }
}
