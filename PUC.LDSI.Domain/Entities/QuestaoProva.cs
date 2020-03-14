using System;
using System.Collections.Generic;
using System.Text;

namespace PUC.LDSI.Domain.Entities
{
    public class QuestaoProva : Entity
    {
        public QuestaoProva() { }
        public int QuestaoId { get; set; }
        public int ProvaId { get; set; }
        public Decimal Nota { get; set; }

        public override string[] Validate()
        {
            if (ProvaId == 0)
                erros.Add("A prova precisa ser informada!");

            if (QuestaoId == 0)
                erros.Add("A questão precisa ser informada!");

        }



    }
}
