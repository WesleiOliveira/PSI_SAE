using System;
using System.Collections.Generic;
using System.Text;

namespace PUC.LDSI.Domain.Entities
{
    public class Aluno : Entity
    {
        public Aluno() { }
        public override string [] Validate()
        {
            throw new NotImplementedException();
        }
       
        public int Id { get; set; }
        public DateTime DataCriacao { get; set; }
        public varchar Nome { get; set; }
        public int Turma { get; set; }
        

    }
}
