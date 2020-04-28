using PUC.LDSI.Domain.Entities;
using PUC.LDSI.Domain.Exception;
using PUC.LDSI.Domain.Interfaces.Repository;
using PUC.LDSI.Domain.Interfaces.Services;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PUC.LDSI.Domain.Services
{
    public class TurmaService : ITurmaService
    {
        private readonly ITurmaRepository _turmaRepository;
        private readonly IAlunoRepository _alunoRepository;
        private readonly IProfessorRepository _professorRepository;

        public TurmaService(ITurmaRepository turmaRepository)
        {
            _turmaRepository = turmaRepository;
        }

        public async Task<int> AdicionarTurmaAsync(string descricao)
        {
            var turma = new Turma() { Nome = descricao };

            var erros = turma.Validate();

            if (erros.Length == 0)
            {
                await _turmaRepository.AdicionarAsync(turma);

                _turmaRepository.SaveChanges();

                return turma.Id;
            }
            else throw new DomainException(erros);
        }

        public async Task<int> AlterarTurmaAsync(int id, string descricao)
        {
            var turma = await _turmaRepository.ObterAsync(id);

            turma.Nome = descricao;

            var erros = turma.Validate();

            if (erros.Length == 0)
            {
                _turmaRepository.Modificar(turma);

                return _turmaRepository.SaveChanges();
            }
            else throw new DomainException(erros);
        }

        public async Task ExcluirAsync(int id)
        {
            var turma = await _turmaRepository.ObterAsync(id);

            if (turma.Alunos?.Count > 0)
                throw new DomainException("Não é possível excluir uma turma que possui alunos matriculados!");

            _turmaRepository.Excluir(id);

            _turmaRepository.SaveChanges();
        }

        public List<Turma> ListarTurmas()
        {
            var lista = _turmaRepository.ObterTodos().ToList();

            return lista;
        }

        public async Task<Turma> ObterAsync(int id)
        {
            var turma = await _turmaRepository.ObterAsync(id);

            return turma;
        }

        public async Task<int> IncluirAlunoAsync(int turmaId, string nomeAluno)
        {
            var aluno = new Aluno() { Nome = nomeAluno, TurmaId = turmaId};

            var erros = aluno.Validate();

            if (erros.Length == 0)
            {
                await _alunoRepository.AdicionarAsync(aluno);

                _alunoRepository.SaveChanges();

                return aluno.Id;
            }
            else throw new DomainException(erros);
        }

        public async Task<int> IncluirProfessorAsync(string nome)
        {
            var professor = new Professor() { Nome = nome };

            var erros = professor.Validate();

            if (erros.Length == 0)
            {
                await _professorRepository.AdicionarAsync(professor);

                _professorRepository.SaveChanges();

                return professor.Id;
            }
            else throw new DomainException(erros);
        }
    }
}
