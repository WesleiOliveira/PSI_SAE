using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PUC.LDSI.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace PUC.LDSI.DataBase.EntityConfig
{
    public class OpcaoAvaliacaoConfiguration : IEntityTypeConfiguration<OpcaoAvaliacao>
    {
        public void Configure(EntityTypeBuilder<OpcaoAvaliacao> builder)
        {
            builder.Property(x => x.Descricao).IsRequired(); // Campo NOT NULL
            builder.Property(x => x.Descricao).HasColumnType("varchar(100)"); // Tipo de dados e precisão

            builder.Property(x => x.Verdadeira).IsRequired(); // Campo NOT NULL
            builder.Property(x => x.Verdadeira).HasColumnType("bool"); // Tipo de dados e precisão

            builder.HasOne(x => x.Questao).WithMany(x => x.OpcaoAvaliacao).HasForeignKey(x => x.QuestaoId); // FK
            new EntityConfig(); // Aplica as configurações dos atributos
        }
    }
}
