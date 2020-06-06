using PUC.LDSI.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PUC.LDSI.Domain.Interfaces.Repository

{
    public interface IQuestaoProvaRepository : IRepository<QuestaoProva>
    {
        Task<List<QuestaoProva>> ObterPorQuestaoProvaAsync(int idQuestaoProva, int idAluno);
    }
}
