using System;
using System.Collections.Generic;
using System.Text;

namespace PUC.LDSI.Domain.Entities
{
    public class Prova : Entity
    {
        public Prova() { }
        public int AvaliacaoId { get; set; }
        public int AlunoId { get; set; }
        public DateTime DataProva { get; set; }
        public Decimal NotaObtida { get; set; }

        public override string[] Validate()
        {
            throw new NotImplementedException();
        }
    }
}
