using System;
using System.Collections.Generic;
using System.Text;

namespace PUC.LDSI.Domain.Entities
{
    public class Aluno : Entity
    {
        public Aluno() { }
        public string Nome { get; set; }
        public int TurmaId { get; set; }
         public override string [] Validate()
        {
            var erros = new List<string>();

            if (TurmaId == 0)
                erros.Add("A turma precisa ser informada!");
            if (string.IsNullOrEmpty(Nome))
                erros.Add("O nome do aluno precisa ser informado!");
            return erros.ToArray();
        }
        
    }
}
