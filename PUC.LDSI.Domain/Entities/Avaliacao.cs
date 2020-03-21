using System;
using System.Collections.Generic;
using System.Text;

namespace PUC.LDSI.Domain.Entities
{
    public class Avaliacao : Entity
    {
        public Avaliacao() { }
        public int ProfessorId { get; set; }
        public string Disciplina { get; set; }
        public string Materia { get; set; }
        public string Descricao { get; set; }
        public Professor Professor { get; set; }
        public List<Prova> Provas { get; set; }
        public List<Publicacao> Publicacoes { get; set; }
        public List<Questao> Questaos { get; set; }

        public override string[] Validate()
        {
            var erros = new List<string>();

            if (ProfessorId == 0)
                erros.Add("O Professor Precisa ser informado");
            if (string.IsNullOrEmpty(Disciplina))
                erros.Add("A Disciplina precisa ser informado");
            if (string.IsNullOrEmpty(Materia))
                erros.Add("A Materia precisa ser informado");
            if (string.IsNullOrEmpty(Descricao))
                erros.Add("A Descricao precisa ser informado");
            return erros.ToArray();
        }
    }

}
