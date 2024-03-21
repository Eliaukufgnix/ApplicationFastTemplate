using Models;

namespace Repository
{
    public class SysUserRepository : BaseRepository<SysUser>, ISysUserRepository
    {
        public SysUserRepository(ApplicationDBContext db) : base(db)
        {
        }
    }
}
