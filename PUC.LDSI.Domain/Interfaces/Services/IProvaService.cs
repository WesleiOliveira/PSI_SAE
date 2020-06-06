using PUC.LDSI.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PUC.LDSI.Domain.Interfaces.Services
{
    public interface IProvaService
    {
        Task<int> IniciarRealizacaoDaProvaAsync(int avaliacaoId, int alunoId);
        Task GravarQuestaoProvaAsync(int questaoId, List<OpcaoProva> respostas);
        Task<int> ConcluirProvaAsync(int provaId);
        Task<List<Publicacao>> ListarProvasPublicadasDoAlunoAsync(int alunoId);
    }
}
