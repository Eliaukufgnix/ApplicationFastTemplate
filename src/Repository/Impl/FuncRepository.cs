using Models;

namespace Repository
{
    public class FuncRepository : BaseRepository<Func>, IFuncRepository
    {
        public FuncRepository(ApplicationDBContext db) : base(db)
        {
        }
    }
}