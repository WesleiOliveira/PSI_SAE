using PUC.LDSI.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PUC.LDSI.Application.Interfaces
{
    public interface IAvaliacaoAppService
    {
        Task<DataResult<int>> AdicionarAvaliacaoAsync(int professorId, string disciplina, string materia, string descricao);
        Task<DataResult<int>> AdicionarQuestaoAvaliacaoAsync(int avaliacaoId, int tipo, string enunciado);
        Task<DataResult<int>> AdicionarOpcaoAvaliacaoAsync(int questaoId, string descricao, bool verdadeira);
        Task<DataResult<int>> AlterarAvaliacaoAsync(int id, string disciplina, string materia, string descricao);
        Task<DataResult<int>> AlterarQuestaoAvaliacaoAsync(int id, int tipo, string enunciado);
        Task<DataResult<int>> AlterarOpcaoAvaliacaoAsync(int id, string descricao, bool verdadeira);
        Task<DataResult<int>> ExcluirAvaliacaoAsync(int id);
        Task<DataResult<int>> ExcluirQuestaoAvaliacaoAsync(int id);
        Task<DataResult<int>> ExcluirOpcaoAvaliacaoAsync(int id);
    }
}
