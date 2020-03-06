using System;
using System.Collections.Generic;
using System.Text;

namespace PUC.LDSI.Domain.Entities
{
    public class Professor : Entity
    {
        public Professor() { }
        public override string[] Validate()
        {
            throw new NotImplementedException();
        }

        public int Id { get; set; }
        public DateTime DataCriacao { get; set; }
        public string Nome { get; set; }

    }
}
