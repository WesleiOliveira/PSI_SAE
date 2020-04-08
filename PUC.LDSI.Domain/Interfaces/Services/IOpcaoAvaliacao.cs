using PUC.LDSI.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PUC.LDSI.Domain.Interfaces.Services
{
    public interface IOpcaoAvaliacao
    {
        Task<int> AdicionarOpcaoAvaliacaoAsync(string descricao);
        Task<int> AlterarOpcaoAvaliacaoAsync(int id, string descricao);
        List<Avaliacao> ListarOpcoesavaliacao();
        Task<Avaliacao> ObterAsync(int id);
        Task ExcluirAsync(int id);
    }
}
