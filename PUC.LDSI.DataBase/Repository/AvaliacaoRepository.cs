using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PUC.LDSI.Domain.Entities;
using PUC.LDSI.Domain.Interfaces.Repository;

namespace PUC.LDSI.DataBase.Repository
{
    public class AvaliacaoRepository : Repository<Avaliacao>, IAvaliacaoRepository
    {
        private readonly AppDbContext _context;

        public AvaliacaoRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }

        public override async Task<Avaliacao> ObterAsync(int id)
        {
            var avaliacao = await _context.Avaliacao
                                                .Include(x => x.Professor)
                                                .Include(x => x.Questoes)
                                                    .ThenInclude(x => x.Opcoes)
                                                .Include(x => x.Publicacoes)
                                                .Where(x => x.Id == id).FirstOrDefaultAsync();
            return avaliacao;
        }
    }
}
