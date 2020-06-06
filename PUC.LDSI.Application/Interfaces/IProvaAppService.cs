using PUC.LDSI.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PUC.LDSI.Application.Interfaces
{
    public interface IProvaAppService
    {
        Task<DataResult<int>> IniciarRealizacaoDaProvaAsync(int avaliacaoId, int alunoId);
        Task GravarQuestaoProvaAsync(int questaoId, List<OpcaoProva> respostas);
        Task<DataResult<int>> ConcluirProvaAsync(int provaId);
        Task<DataResult<List<Publicacao>>> ListarProvasPublicadasDoAlunoAsync(int alunoId);
    }
}
