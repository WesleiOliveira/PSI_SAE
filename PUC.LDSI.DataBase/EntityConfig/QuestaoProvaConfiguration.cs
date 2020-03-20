using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PUC.LDSI.Domain.Entities;

namespace PUC.LDSI.DataBase.EntityConfig
{
    public class QuestaoProvaConfiguration : IEntityTypeConfiguration<QuestaoProva>
    {
        public void Configure(EntityTypeBuilder<QuestaoProva> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).UseSqlServerIdentityColumn();
            builder.Property(x => x.DataCriacao).IsRequired().HasColumnType("datetime");

            builder.Property(x => x.Nota).IsRequired(); // Campo NOT NULL
            builder.Property(x => x.Nota).HasColumnType("decimal(4,2)"); // Tipo de dados e precisão

            builder.HasOne(x => x.Questao).WithMany(x => x.QuestoesProva).HasForeignKey(x => x.QuestaoId); // FK
            builder.HasOne(x => x.Prova).WithMany(x => x.QuestoesProva).HasForeignKey(x => x.ProvaId); // FK
            new QuestaoProvaConfiguration(); 
        }
    }
}
