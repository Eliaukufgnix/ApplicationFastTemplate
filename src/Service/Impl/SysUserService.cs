using AutoMapper;
using Common.Utils;
using Models;
using Repository;
using System;
using System.Collections.Generic;

namespace Service
{
    public class SysUserService : BaseService<SysUser>, ISysUserService
    {
        private readonly IMapper mapper;
        public SysUserService(IBaseRepository<SysUser> repository, IMapper mapper) : base(repository)
        {
            this.mapper = mapper;
        }

        public SysUser LoginVerify(LoginVerifyDTO data)
        {
            // 实例化 Encrypt 类
            Encrypt encryptor = new Encrypt();

            // 从数据库中获取与提供的账号匹配的用户
            List<SysUser> sysUsers = repository.GetAllByWhere(x => x.Account == data.Account);

            // 如果找不到匹配的用户，抛出异常
            if (sysUsers.Count <= 0)
            {
                throw new Exception("账号或密码错误");
            }

            // 获取第一个匹配的用户对象
            SysUser user = sysUsers[0];

            // 使用 Encrypt 类的 Verify 方法验证用户提供的密码是否正确
            bool isPasswordCorrect = encryptor.Verify(data.PassWord, user.PassWord,user.Salt);

            // 如果密码不正确，抛出异常
            if (!isPasswordCorrect)
            {
                throw new Exception("账号或密码错误");
            }

            // 如果密码正确，返回 true
            return user;
        }
    }
}
