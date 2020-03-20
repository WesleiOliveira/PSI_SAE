using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PUC.LDSI.Domain.Entities;

namespace PUC.LDSI.DataBase.EntityConfig
{
    public class PublicacaoConfiguration : IEntityTypeConfiguration<Publicacao>
    {
        public void Configure(EntityTypeBuilder<Publicacao> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).UseSqlServerIdentityColumn();
            builder.Property(x => x.DataCriacao).IsRequired().HasColumnType("datetime");

            builder.Property(x => x.DataInicio).IsRequired(); // Campo NOT NULL
            builder.Property(x => x.DataInicio).HasColumnType("datetime"); // Tipo de dados e precisão

            builder.Property(x => x.DataFim).IsRequired(); // Campo NOT NULL
            builder.Property(x => x.DataFim).HasColumnType("datetime"); // Tipo de dados e precisão

            builder.Property(x => x.ValorProva).IsRequired(); // Campo NOT NULL
            builder.Property(x => x.ValorProva).HasColumnType("int"); // Tipo de dados e precisão

            builder.HasOne(x => x.Turma).WithMany(x => x.Publicacoes).HasForeignKey(x => x.TurmaId); // FK
            builder.HasOne(x => x.Avaliacao).WithMany(x => x.Publicacoes).HasForeignKey(x => x.AvaliacaoId); // FK
            new PublicacaoConfiguration(); 
        }
    }
}

