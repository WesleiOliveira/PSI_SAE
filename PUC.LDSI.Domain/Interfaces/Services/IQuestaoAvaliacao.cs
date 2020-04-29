using PUC.LDSI.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PUC.LDSI.Domain.Interfaces.Services
{
    public interface IQuestaoAvaliacao
    {
        Task<int> AdicionarQuestaoAvaliacaoAsync(int avaliacaoId, int tipo, string enunciado);
        Task<int> AlterarQuestaoAvaliacaoAsync(int id, string descricao);
        List<Turma> ListarQuestoesAvaliacao();
        Task<Turma> ObterAsync(int id);
        Task ExcluirAsync(int id);
    }
}
