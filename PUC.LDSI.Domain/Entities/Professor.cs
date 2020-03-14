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
                
            if (string.IsNullOrEmpty(Nome))
                erros.Add("O nome do professor precisa ser informado!");

            return erros.ToArray();
        }
    }
}
