using System;
using System.Collections.Generic;
using System.Text;

namespace PUC.LDSI.Domain.Entities
{
    public class Professor : Entity
    {
        public Professor() { }
     
        public string Nome { get; set; }

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
