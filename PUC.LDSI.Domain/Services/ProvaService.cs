using PUC.LDSI.Domain.Entities;
using PUC.LDSI.Domain.Exception;
using PUC.LDSI.Domain.Interfaces.Repository;
using PUC.LDSI.Domain.Interfaces.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PUC.LDSI.Domain.Services
{
    public class ProvaService : IProvaService
    {
        public async Task<int> IniciarRealizacaoDaProvaAsync(int avaliacaoId, int alunoId)
        {
            throw new System.NotImplementedException();
        }

        public async Task<int> ConcluirProvaAsync(int provaId)
        {
            throw new System.NotImplementedException();
        }

        public async Task GravarQuestaoProvaAsync(int questaoId, List<OpcaoProva> respostas)
        {
            throw new System.NotImplementedException();
        }

        
        public async Task<List<Publicacao>> ListarProvasPublicadasDoAlunoAsync(int alunoId)
        {
            throw new System.NotImplementedException();
        }
    }
}
