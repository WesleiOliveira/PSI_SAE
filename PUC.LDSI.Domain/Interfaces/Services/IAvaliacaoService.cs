using PUC.LDSI.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PUC.LDSI.Domain.Interfaces.Services
{
    public interface IAvaliacaoService
    {
        List<Avaliacao> ListarAvaliacoes();
        Task<int> AdicionarAvaliacaoAsync(int professorId, string disciplina, string materia, string descricao);
        Task<int> AdicionarQuestaoAvaliacaoAsync(int avaliacaoId, int tipo, string enunciado);
        Task<int> AdicionarOpcaoAvaliacaoAsync(int questaoId, string descricao, bool verdadeira);
        Task<int> AlterarAvaliacaoAsync(int id, string disciplina, string materia, string descricao);
        Task<int> AlterarQuestaoAvaliacaoAsync(int id, int tipo, string enunciado);
        Task<int> AlterarOpcaoAvaliacaoAsync(int id, string descricao, bool verdadeira);
        Task ExcluirAvaliacaoAsync(int id);
        Task<int> ExcluirQuestaoAvaliacaoAsync(int id);
        Task<int> ExcluirOpcaoAvaliacaoAsync(int id);
        Task<int> AdicionarPublicacaoAsync(int professorId, int avaliacaoId, int turmaId, DateTime dataInicio, DateTime dataFim, int valorProva);
        Task<int> AlterarPublicacaoAsync(int professorId, int id, DateTime dataInicio, DateTime dataFim, int valorProva);
        Task<int> ExcluirPublicacaoAsync(int professorId, int id);
    }
}
