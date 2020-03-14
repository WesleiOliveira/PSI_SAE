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

        public override string[] Validate()
        {
            var erros = new List<string>();

            if (ProfessorId == 0)
                erros.Add("O professor precisa ser informado!");
            if (string.IsNullOrEmpty(Disciplina))
                erros.Add("A disciplina precisa ser informada!");
            if (string.IsNullOrEmpty(Materia))
                erros.Add("A materia precisa ser informada!");
            if (string.IsNullOrEmpty(Descricao))
                erros.Add("A descricao precisa ser informada!");

            return erros.ToArray();
        }
    }

}
