using PUC.LDSI.Domain.Entities;
using PUC.LDSI.Domain.Interfaces.Repository;

namespace PUC.LDSI.DataBase.Repository
{
    public class QuestaoProvaRepository : Repository<QuestaoProva>, IQuestaoProvaRepository
    {
        public QuestaoProvaRepository(AppDbContext context) : base(context) { }
    }
}