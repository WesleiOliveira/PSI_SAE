using System;
using System.Collections.Generic;
using System.Text;

namespace PUC.LDSI.Domain.Entities
{
    public class Professor : Entity
    {
        public string Nome { get; set; }
        public List<Avaliacao> Avaliacoes { get; set; }
        public override string[] Validate()
        {
            var erros = new List<string>();
            if (string.IsNullOrEmpty(Nome))
                erros.Add("O Nome precisa ser informado");
            return erros.ToArray();
        }
    }
}
