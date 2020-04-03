using System;
using System.Collections.Generic;
using System.Text;

namespace PUC.LDSI.Domain.Entities
{
    public class QuestaoAvaliacao : Entity
    {
        public int AvaliacaoId { get; set; }
        public int Tipo { get; set; }
        public string Enunciado { get; set; }
        public Avaliacao Avaliacao { get; set; }
        public List<OpcaoAvaliacao> Opcoes { get; set; }
        public List<QuestaoProva> QuestoesProva { get; set; }
        public override string[] Validate()
        {
            var erros = new List<string>();
            if (AvaliacaoId == 0)
                erros.Add("A Avaliação deve ser informada");
            if (Tipo == 0)
                erros.Add("O Tipo deve ser informado");
            if (string.IsNullOrEmpty(Enunciado))
                erros.Add("O Enunciado precisa ser informado");
            return erros.ToArray();
        }
    }
}
