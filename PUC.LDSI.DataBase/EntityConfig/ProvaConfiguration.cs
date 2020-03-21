using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PUC.LDSI.Domain.Entities;

namespace PUC.LDSI.DataBase.EntityConfig
{
    public class ProvaConfiguration : IEntityTypeConfiguration<Prova>
    {
        public void Configure(EntityTypeBuilder<Prova> builder)
        {
            builder.Property(x => x.DataProva).IsRequired().HasColumnType("datetime");
            builder.Property(x => x.NotaObtida).IsRequired().HasColumnType("decimal");
            builder.HasOne(x => x.Avaliacao).WithMany(x => x.Provas).HasForeignKey(x => x.AvaliacaoId);
            builder.HasOne(x => x.Aluno).WithMany(x => x.Provas).HasForeignKey(x => x.AlunoId);
        }
    }
}
