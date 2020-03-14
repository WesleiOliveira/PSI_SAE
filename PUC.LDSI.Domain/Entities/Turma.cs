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
            if (string.IsNullOrEmpty(Nome))
                erros.Add("O nome da turma precisa ser informado!");
        }

    }
}
