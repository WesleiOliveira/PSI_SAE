using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PUC.LDSI.Domain.Entities;
using PUC.LDSI.Domain.Interfaces.Repository;


namespace PUC.LDSI.DataBase.Repository
{
    public class QuestaoAvaliacaoRepository : Repository<QuestaoAvaliacao>, IQuestaoAvaliacaoRepository
    {
        private readonly AppDbContext _context;

        public QuestaoAvaliacaoRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }

        public override async Task<QuestaoAvaliacao> ObterAsync(int id)
        {
            var avaliacao = await _context.QuestaoAvaliacao
                    .Include(x => x.Avaliacao)
                    .Include(x => x.QuestoesProva)
                    .Include(x => x.Opcoes)
                    .Where(x => x.Id == id).FirstOrDefaultAsync();
            return avaliacao;
        }
    }
}
