using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PUC.LDSI.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace PUC.LDSI.DataBase.EntityConfig
{
    public class QuestaoProvaConfiguration : IEntityTypeConfiguration<QuestaoProva>
    {
        public void Configure(EntityTypeBuilder<QuestaoProva> builder)
        {
            builder.Property(x => x.Nota).IsRequired(); // Campo NOT NULL
            builder.Property(x => x.Nota).HasColumnType("decimal(4,2)"); // Tipo de dados e precisão

            builder.HasOne(x => x.Questao).WithMany(x => x.QuestaoProva).HasForeignKey(x => x.QuestaoId); // FK
            builder.HasOne(x => x.Prova).WithMany(x => x.QuestaoProva).HasForeignKey(x => x.ProvaId); // FK
            new EntityConfig(); // Aplica as configurações dos atributos
        }
    }
}
