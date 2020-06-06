using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PUC.LDSI.Domain.Entities;

namespace PUC.LDSI.DataBase.EntityConfig
{
    public class AlunoConfiguration : IEntityTypeConfiguration<Aluno>
    {
        public void Configure(EntityTypeBuilder<Aluno> builder)
        {
            builder.Property(x => x.Nome).IsRequired();
            builder.Property(x => x.Nome).HasColumnType("varchar(100)");
            builder.HasOne(x => x.Turma).WithMany(x => x.Alunos).HasForeignKey(x => x.TurmaId);
            new EntityConfiguration();
        }
    }
}
