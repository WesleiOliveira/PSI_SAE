using System;
using System.Collections.Generic;
using System.Text;

namespace PUC.LDSI.Domain.Entities
{
    public class Aluno : Entity
    {
        public Aluno() { }
        public string Nome { get; set; }
        public Turma TurmaId { get; set; }
         public override string [] Validate()
        {
            throw new NotImplementedException();
        }
        
    }
}
