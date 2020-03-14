using System;
using System.Collections.Generic;
using System.Text;

namespace PUC.LDSI.Domain.Entities
{
    public class OpcaoAvaliacao : Entity
    {
        public OpcaoAvaliacao() { }

        public int Id { get; set; }
        public DateTime DataCriacao { get; set; }
        public int QuestaoId { get; set; }
        public string Descricao { get; set; }
        public Boolean Verdadadeira { get; set; }

        public override string[] Validate()
        {
            throw new NotImplementedException();
        }
    }

}
