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
            throw new NotImplementedException();
        }

        

    }
}
