using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PUC.LDSI.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace PUC.LDSI.DataBase.EntityConfig
{
    public class OpcaoProvaConfiguration : IEntityTypeConfiguration<OpcaoProva>
    {
        public void Configure(EntityTypeBuilder<OpcaoProva> builder)
        {
            builder.Property(x => x.Resposta).IsRequired(); // Campo NOT NULL
            builder.Property(x => x.Resposta).HasColumnType("bool"); // Tipo de dados e precisão

            builder.HasOne(x => x.OpcaoAvaliacao).WithMany(x => x.OpcaoProva).HasForeignKey(x => x.OpcaoAvaliacaoId); // FK
            builder.HasOne(x => x.QuestaoProva).WithMany(x => x.OpcaoProva).HasForeignKey(x => x.QuestaoProvaId); // FK
            new EntityConfig(); // Aplica as configurações dos atributos
        }
    }
}

