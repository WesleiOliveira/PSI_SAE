using PUC.LDSI.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PUC.LDSI.Domain.Interfaces.Services
{
    public interface IAvaliacaoService
    {
        Task<int> AdicionarAvaliacaoAsync(string descricao);
        Task<int> AlterarAvaliacaoAsync(int id, string descricao);
        List<Avaliacao> ListarAvaliacoes();
        Task<Avaliacao> ObterAsync(int id);
        Task ExcluirAsync(int id);
    }
}
