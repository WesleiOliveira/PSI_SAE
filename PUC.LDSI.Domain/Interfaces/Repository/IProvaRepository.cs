using PUC.LDSI.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PUC.LDSI.Domain.Interfaces.Repository

{
    public interface IProvaRepository : IRepository<Prova>
    {
        Task<List<Prova>> ObterPorAvaliacaoAlunoAsync(int idAvaliacao, int idAluno);
        Task ListarAvaliacoesDoProfessorAsync(int integrationUserId);
    }
}
