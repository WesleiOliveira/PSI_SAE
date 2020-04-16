using PUC.LDSI.Domain.Entities;
using System.Threading.Tasks;

namespace PUC.LDSI.Domain.Interfaces.Repository
{
    public interface IAvaliacaoRepository : IRepository<Avaliacao>
    {
        Task AdicionarAsync(QuestaoAvaliacao questaoAvaliacao);
        Task AdicionarAsync(OpcaoAvaliacao opcaoAvaliacao);
    }
}
