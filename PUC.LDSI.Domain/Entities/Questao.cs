using System;
using System.Collections.Generic;
using System.Text;

namespace PUC.LDSI.Domain.Entities
{
    public class Questao : Entity
    {
        public Questao() { }
       

        public int Id { get; set; }
        public DateTime DataCriacao { get; set; }
        public string Nome { get; set; }

        public override string[] Validate()
        {

            throw new NotImplementedException();
        }
    }
}
