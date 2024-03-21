using Models;

namespace Service
{
    public interface ISysUserService : IBaseService<SysUser>
    {
        /// <summary>
        /// 登录验证
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        SysUser LoginVerify(LoginVerifyDTO data);
    }
}
