using System;
using System.Collections.Generic;
using System.Text;

namespace PUC.LDSI.Domain.Entities
{
    public class Turma : Entity
    {
        public Turma() { }
        public string Nome { get; set; }

        public override string[] Validate()
        {
            throw new NotImplementedException();
        }

    }
}
