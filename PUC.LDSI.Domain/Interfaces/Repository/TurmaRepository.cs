using PUC.LDSI.Domain.Entities;
using PUC.LDSI.Domain.Interfaces.Repository;

namespace PUC.LDSI.Domain.Interfaces.Repository
{
    public class TurmaRepository : Repository<Turma>, ITurmaRepository
    {
        private readonly AppDbContext _context;

        public TurmaRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }
    }
}
