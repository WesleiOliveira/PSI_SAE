using PUC.LDSI.Domain.Entities;
using PUC.LDSI.Domain.Exception;
using PUC.LDSI.Domain.Interfaces.Repository;
using PUC.LDSI.Domain.Interfaces.Services;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PUC.LDSI.Domain.Services
{
    public class AvaliacaoService : IAvaliacaoService
    {
        private readonly IAvaliacaoRepository _avaliacaoRepository;

        public AvaliacaoService(IAvaliacaoRepository avaliacaoRepository)
        {
            _avaliacaoRepository = avaliacaoRepository;
        }

        public async Task<int> AdicionarAvaliacaoAsync(int professorId, string disciplina, string materia, string descricao)
        {
            var avaliacao = new Avaliacao() { ProfessorId = professorId, Disciplina = disciplina, Materia = materia, Descricao = descricao };

            var erros = avaliacao.Validate();

            if (erros.Length == 0)
            {
                await _avaliacaoRepository.AdicionarAsync(avaliacao);

                _avaliacaoRepository.SaveChanges();

                return avaliacao.Id;
            }
            else throw new DomainException(erros);
        }

        public async Task<int> AdicionarQuestaoAvaliacaoAsync(int avaliacaoId, int tipo, string enunciado)
        {
            var questaoAvaliacao = new QuestaoAvaliacao() { AvaliacaoId = avaliacaoId, Tipo = tipo, Enunciado = enunciado };

            var erros = questaoAvaliacao.Validate();

            if(erros.Length == 0)
            {
                await _avaliacaoRepository.AdicionarAsync(questaoAvaliacao);
                _avaliacaoRepository.SaveChanges();

                return questaoAvaliacao.Id;
            }
            else throw new DomainException(erros);
        }

        public async Task<int> AdicionarOpcaoAvaliacaoAsync(int questaoId, string descricao, bool verdadeira)
        {
            var opcaoAvaliacao = new OpcaoAvaliacao() { QuestaoId = questaoId, Descricao = descricao, Verdadeira = verdadeira };

            var erros = opcaoAvaliacao.Validate();

            if (erros.Length == 0)
            {
                await _avaliacaoRepository.AdicionarAsync(opcaoAvaliacao);
                _avaliacaoRepository.SaveChanges();

                return opcaoAvaliacao.Id;
            }
            else throw new DomainException(erros);
        }

        public async Task<int> AlterarAvaliacaoAsync(int id, string disciplina, string materia, string descricao)
        {
            var avaliacao = await _avaliacaoRepository.ObterAsync(id);

            avaliacao.Disciplina = disciplina;
            avaliacao.Materia = materia;
            avaliacao.Descricao = descricao;

            var erros = avaliacao.Validate();

            if (erros.Length == 0)
            {
                _avaliacaoRepository.Modificar(avaliacao);

                return _avaliacaoRepository.SaveChanges();
            }
            else throw new DomainException(erros);
        }

        public async Task<int> AlterarQuestaoAvaliacaoAsync(int id, int tipo, string enunciado)
        {
            var questaAvaliacao = await _avaliacaoRepository.ObterAsync(id);


        }
    }
}
