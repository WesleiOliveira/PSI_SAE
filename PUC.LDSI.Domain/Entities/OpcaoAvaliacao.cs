using System;
using System.Collections.Generic;
using System.Text;

namespace PUC.LDSI.Domain.Entities
{
    public class OpcaoAvaliacao : Entity
    {
        public OpcaoAvaliacao() { }
        public int QuestaoId { get; set; }
        public string Descricao { get; set; }
        public Boolean Verdadadeira { get; set; }
        public QuestaoAvaliacao QuestaoAvaliacao { get; set; }
        public List<OpcaoProva> opcaoProvas { get; set; }
        public override string[] Validate()
        {
            var erros = new List<string>();

            if (QuestaoId == 0)
                erros.Add("A Questão Precisa ser informado");
            if (string.IsNullOrEmpty(Descricao))
                erros.Add("A Descricao precisa ser informado");
            return erros.ToArray();
        }
    }

}
