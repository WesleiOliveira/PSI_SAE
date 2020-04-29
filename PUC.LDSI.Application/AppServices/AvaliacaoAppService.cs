using PUC.LDSI.Application.Interfaces;
using PUC.LDSI.Domain.Entities;
using PUC.LDSI.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PUC.LDSI.Application.AppServices
{
    public class AvaliacaoAppService : IAvaliacaoAppService
    {
        private readonly IAvaliacaoService _avaliacaoService;
        private readonly IQuestaoAvaliacao _questaoAvaliacao;
        private readonly IOpcaoAvaliacao _opcaoAvaliacao;

        public AvaliacaoAppService(IAvaliacaoService avaliacaoService, IQuestaoAvaliacao questaoAvaliacao, IOpcaoAvaliacao opcaoAvaliacao)
        {
            _avaliacaoService = avaliacaoService;
            _questaoAvaliacao = questaoAvaliacao;
            _opcaoAvaliacao = opcaoAvaliacao;
        }

        public async Task<DataResult<int>> AdicionarAvaliacaoAsync(int professorId, string disciplina, string materia, string descricao)
        {
            try
            {
                var retorno = await _avaliacaoService.AdicionarAvaliacaoAsync(professorId, disciplina, materia, descricao);

                return new DataResult<int>(retorno);
            }
            catch (Exception ex)
            {
                return new DataResult<int>(ex);
            }
        }

        public async Task<DataResult<int>> AdicionarQuestaoAvaliacaoAsync(int avaliacaoId, int tipo, string enunciado)
        {
            try
            {
                var retorno = await _questaoAvaliacao.AdicionarQuestaoAvaliacaoAsync(avaliacaoId,tipo,enunciado);
                return new DataResult<int>(retorno);
            }
            catch (Exception ex)
            {
                return new DataResult<int>(ex);
            }
        }

        public async Task<DataResult<int>> AdicionarOpcaoAvaliacaoAsync(int questaoId, string descricao, bool verdadeira)
        {
            try
            {
                var retorno = await _opcaoAvaliacao.AdicionarOpcaoAvaliacaoAsync(questaoId, descricao, verdadeira);
                return new DataResult<int>(retorno);
            }
            catch (Exception ex)
            {
                return new DataResult<int>(ex);
            }
        }

        public async Task<DataResult<int>> AlterarAvaliacaoAsync(int id, string disciplina, string materia, string descricao)
        {
            try
            {
                var retorno = await _avaliacaoService.AlterarAvaliacaoAsync(id, disciplina, materia, descricao);
                return new DataResult<int>(retorno);
            }
            catch (Exception ex)
            {
                return new DataResult<int>(ex);
            }

        }

        public Task<DataResult<int>> AlterarQuestaoAvaliacaoAsync(int id, int tipo, string enunciado)
        {
            throw new NotImplementedException();
        }

        public async Task<DataResult<int>> AlterarOpcaoAvaliacaoAsync(int id, string descricao, bool verdadeira)
        {
            try
            {
                var retorno = await _opcaoAvaliacao.AlterarOpcaoAvaliacaoAsync(id,descricao,verdadeira);
                return new DataResult<int>(retorno);
            }
            catch (Exception ex)
            {
                return new DataResult<int>(ex);
            }
        }

        public async Task<DataResult<int>> ExcluirAvaliacaoAsync(int id)
        {
            try
            {
                await _avaliacaoService.ExcluirAvaliacaoAsync(id);

                return new DataResult<int>(1);
            }
            catch (Exception ex)
            {
                return new DataResult<int>(ex);
            }
        }

        public async Task<DataResult<int>> ExcluirQuestaoAvaliacaoAsync(int id)
        {
            try
            {
                await _questaoAvaliacao.ExcluirAsync(id);

                return new DataResult<int>(1);
            }
            catch (Exception ex)
            {
                return new DataResult<int>(ex);
            }
        }

        public async Task<DataResult<int>> ExcluirOpcaoAvaliacaoAsync(int id)
        {
            try
            {
                await _opcaoAvaliacao.ExcluirAsync(id);

                return new DataResult<int>(1);
            }
            catch (Exception ex)
            {
                return new DataResult<int>(ex);
            }
        }

        
    }
}
