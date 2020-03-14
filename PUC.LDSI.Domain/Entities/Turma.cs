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
            var erros = new List<string>();
            if (string.IsNullOrEmpty(Nome))
                erros.Add("O Nome deve ser informada");
            return erros.ToArray();
        }

    }
}
