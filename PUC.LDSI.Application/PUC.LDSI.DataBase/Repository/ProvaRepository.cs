using PUC.LDSI.Domain.Entities;
using PUC.LDSI.Domain.Interfaces.Repository;

namespace PUC.LDSI.DataBase.Repository
{
    public class ProvaRepository : Repository<Prova>, IProvaRepository
    {
        public ProvaRepository(AppDbContext context) : base(context) { }
    }
}