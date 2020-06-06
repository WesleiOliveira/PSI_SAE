using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PUC.LDSI.Domain.Interfaces.Services
{
    public interface IProvaService
    {
        Task<int> IniciarRealizacaoDaProvaAsync(int avaliacaoId, int alunoId);
        Task GravarQuestaoProvaAsync(int questaoId, List<Entities.OpcaoProva> respostas);
        Task<int> ConcluirProvaAsync(int provaId);
        Task<List<Entities.Publicacao>> ListarProvasPublicadasDoAlunoAsync(int alunoId);
    }
}
