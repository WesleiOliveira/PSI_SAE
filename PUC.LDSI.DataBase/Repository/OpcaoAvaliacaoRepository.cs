using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PUC.LDSI.Domain.Entities;
using PUC.LDSI.Domain.Interfaces.Repository;


namespace PUC.LDSI.DataBase.Repository
{
    public class OpcaoAvaliacaoRepository : Repository<OpcaoAvaliacao>, IOpcaoAvaliacaoRepository
    {
        private readonly AppDbContext _context;

        public OpcaoAvaliacaoRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }

        public override async Task<OpcaoAvaliacao> ObterAsync(int id)
        {
            var opcaoAvaliacao = await _context.OpcaoAvaliacao
                    .Include(x => x.OpcoesProva)
                    .Where(x => x.Id == id).FirstOrDefaultAsync();
            return opcaoAvaliacao;
        }
    }
}
}
