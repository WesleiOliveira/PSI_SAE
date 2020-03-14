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
            var erros = new List<string>();
            if (QuestaoId == 0)
                erros.Add("A Questão deve ser informada");
            if (ProvaId == 0)
                erros.Add("A Prova deve ser informado");
            return erros.ToArray();
        }



    }
}
