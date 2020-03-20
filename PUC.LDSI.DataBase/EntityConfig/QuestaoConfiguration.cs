using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PUC.LDSI.Domain.Entities;

namespace PUC.LDSI.DataBase.EntityConfig
{
    public class QuestaoConfiguration : IEntityTypeConfiguration<Questao>
    {
        public void Configure(EntityTypeBuilder<Questao> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).UseSqlServerIdentityColumn();
            builder.Property(x => x.DataCriacao).IsRequired().HasColumnType("datetime");

            builder.Property(x => x.Tipo).IsRequired(); // Campo NOT NULL
            builder.Property(x => x.Tipo).HasColumnType("int"); // Tipo de dados e precisão

            builder.Property(x => x.Enunciado).IsRequired(); // Campo NOT NULL
            builder.Property(x => x.Enunciado).HasColumnType("varchar(500)"); // Tipo de dados e precisão

            builder.HasOne(x => x.Avaliacao).WithMany(x => x.Questoes).HasForeignKey(x => x.AvaliacaoId); // FK
            new QuestaoConfiguration(); 
        }
    }
}
