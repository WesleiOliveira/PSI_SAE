using PUC.LDSI.Domain.Entities;
using PUC.LDSI.Domain.Exception;
using PUC.LDSI.Domain.Interfaces.Repository;
using PUC.LDSI.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PUC.LDSI.Domain.Services
{
    public class ProvaService : IProvaService
    {
        private readonly IProvaRepository _provaRepository;
        public ProvaService(IProvaRepository provaRepository)
        {
            _provaRepository = provaRepository;
        }
        public async Task<int> ConcluirProvaAsync(int provaId)
        {
            var prova = await _provaRepository.ObterAsync(provaId);
            
            if(prova == null)
                throw new DomainException("A prova informada não foi encontrada!");
            //if (prova.QuestoesProva.Where(x => x.OpcoesProva == ).Where(x => x.OpcoesProva.Count > 1).Any())
              //  throw new DomainException("Existem questões inconsistentes na prova!");
            if(prova.DataProva != null)
                throw new DomainException("A prova já foi concluída em " + prova.DataProva + "!");
            prova.DataProva = System.DateTime.Today;
            _provaRepository.SaveChanges();
            return prova.Id;
        }

        public async Task GravarQuestaoProvaAsync(int questaoId, List<OpcaoProva> respostas)
        {
            throw new NotImplementedException();
        }

        public async Task<int> IniciarRealizacaoDaProvaAsync(int avaliacaoId, int alunoId)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Publicacao>> ListarProvasPublicadasDoAlunoAsync(int alunoId)
        {
            throw new NotImplementedException();
        }
    }
}
