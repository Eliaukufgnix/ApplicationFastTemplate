using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using System;
using System.Security.Cryptography;

namespace Common.Utils
{
    public class Encrypt
    {
        /// <summary>
        /// 生成随机盐值
        /// </summary>
        /// <returns></returns>
        private static string GenerateSalt()
        {
            // 生成一个随机的盐值，长度为 128 位
            byte[] salt = new byte[128 / 8];
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(salt);
            }
            // 将盐值转换为 Base64 字符串并返回
            return Convert.ToBase64String(salt);
        }

        /// <summary>
        /// 对密码进行哈希处理并返回哈希值和盐值
        /// </summary>
        /// <param name="password">密码</param>
        /// <param name="salt">盐值</param>
        /// <returns></returns>
        public (string hash, string salt) Hash(string password, string salt = null)
        {
            // 如果未提供盐值，则生成一个随机的盐值
            salt = salt != null ? salt : GenerateSalt();

            // 使用 PBKDF2 算法对密码进行哈希处理
            byte[] data = KeyDerivation.Pbkdf2(
                password: password,// 要哈希处理的密码
                salt: Convert.FromBase64String(salt),// 盐值
                prf: KeyDerivationPrf.HMACSHA1,// 哈希算法
                iterationCount: 10000,// 迭代次数
                numBytesRequested: 256 / 8);// 期望的哈希值长度

            // 将哈希值转换为 Base64 字符串并返回哈希值和盐值的元组
            var hash = Convert.ToBase64String(data);
            return (hash, salt);
        }

        /// <summary>
        /// 验证密码是否与给定的哈希值匹配
        /// </summary>
        /// <param name="password">输入的密码</param>
        /// <param name="hash">哈希值(数据库的密码)</param>
        /// <param name="salt">盐值</param>
        /// <returns></returns>
        public bool Verify(string password, string hash, string salt)
        {
            // 重新计算给定密码的哈希值，并与给定的哈希值进行比较
            return Hash(password, salt).hash.Equals(hash);
        }
    }
}
