using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PUC.LDSI.Domain.Entities;

namespace PUC.LDSI.DataBase.EntityConfig
{
    public class ProvaConfiguration : IEntityTypeConfiguration<Prova>
    {
        public void Configure(EntityTypeBuilder<Prova> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).UseSqlServerIdentityColumn();
            builder.Property(x => x.DataCriacao).IsRequired().HasColumnType("datetime");

            builder.Property(x => x.DataProva).IsRequired(); // Campo NOT NULL
            builder.Property(x => x.DataProva).HasColumnType("datetime"); // Tipo de dados e precisão

            builder.Property(x => x.NotaObtida).IsRequired(); // Campo NOT NULL
            builder.Property(x => x.NotaObtida).HasColumnType("decimal(4,2)"); // Tipo de dados e precisão

            builder.HasOne(x => x.Aluno).WithMany(x => x.Provas).HasForeignKey(x => x.AlunoId); // FK
            builder.HasOne(x => x.Avaliacao).WithMany(x => x.Provas).HasForeignKey(x => x.AvaliacaoId); // FK
            new ProvaConfiguration(); 
        }
    }
}
