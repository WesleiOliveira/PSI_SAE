using System;
using System.Collections.Generic;
using System.Text;

namespace PUC.LDSI.Domain.Entities
{
    public class OpcaoProva : Entitity
    {
        public OpcaoProva() { }

        public int Id { get; set; }
        public DateTime DataCriacao { get; set; }
        public int OpcaoAvaliacao { get; set; }
        public int QuestaoProvaId { get; set; }
        public bool Resposta { get; set; }

        public override string[] Validate()
        {
            throw new NotImplementedException();
        }
    }

}
