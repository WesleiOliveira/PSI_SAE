using PUC.LDSI.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PUC.LDSI.Domain.Interfaces.Repository

{
    public interface IOpcaoProvaRepository : IRepository<OpcaoProva>
    {
        Task<List<OpcaoProva>> ObterPorOpcaoProvaAsync(int idProva, int idAluno);

    }
}
