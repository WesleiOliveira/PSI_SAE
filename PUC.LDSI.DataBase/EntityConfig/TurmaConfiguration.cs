using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PUC.LDSI.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace PUC.LDSI.DataBase.EntityConfig
{
    public class TurmaConfiguration : IEntityTypeConfiguration<Turma>
    {
        public void Configure(EntityTypeBuilder<Turma> builder)
        {
            builder.Property(x => x.Nome).IsRequired(); // Campo NOT NULL
            builder.Property(x => x.Nome).HasColumnType("varchar(100)"); // Tipo de dados e precisão
            new EntityConfig(); // Aplica as configurações dos atributos
        }
    }
}
