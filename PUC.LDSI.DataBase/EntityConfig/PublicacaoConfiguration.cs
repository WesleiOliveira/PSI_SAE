using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PUC.LDSI.Domain.Entities;

namespace PUC.LDSI.DataBase.EntityConfig
{
    public class PublicacaoConfiguration : IEntityTypeConfiguration<Publicacao>
    {
        public void Configure(EntityTypeBuilder<Publicacao> builder)
        {
            builder.Property(x => x.DataInicio).IsRequired().HasColumnType("datetime");
            builder.Property(x => x.DataFim).IsRequired().HasColumnType("datetime");
            builder.Property(x => x.ValorProva).IsRequired().HasColumnType("int");
            builder.HasOne(x => x.Avaliacao).WithMany(x => x.Publicacoes).HasForeignKey(x => x.AvaliacaoId);
            builder.HasOne(x => x.Turma).WithMany(x => x.Publicacoes).HasForeignKey(x => x.TurmaId);
        }
    }
}

