using System;

namespace Common
{
    public class ResultModel<T>
    {
        public string code { get; set; }
        public string msg { get; set; }
        public int count { get; set; }
        public T data { get; set; }
        public string timestamp { get; }

        #region 无参构造私有化

        private ResultModel()
        {
            timestamp = DateTimeOffset.UtcNow.ToUnixTimeMilliseconds().ToString();
        }

        #endregion 无参构造私有化

        #region 请求成功

        public static ResultModel<T> Success()
        {
            return Result("0", "请求成功", default, 0);
        }

        public static ResultModel<T> Success(string msg)
        {
            return Result("0", msg, default, 0);
        }

        public static ResultModel<T> Success(string message, int count)
        {
            return Result("0", message, default, count);
        }

        public static ResultModel<T> Success(T data, int count)
        {
            return Result("0", "请求成功", data, count);
        }

        public static ResultModel<T> Success(string message, T data, int count)
        {
            return Result("0", message, data, count);
        }

        public static ResultModel<T> Success(string code, string message, T data, int count)
        {
            return Result(code, message, data, count);
        }

        #endregion 请求成功

        #region 请求失败

        public static ResultModel<T> Fail()
        {
            return Result("1", "请求失败", default, 0);
        }

        public static ResultModel<T> Fail(string message)
        {
            return Result("1", message, default, 0);
        }

        public static ResultModel<T> Fail(T data, int count)
        {
            return Result("1", "请求失败", data, count);
        }

        public static ResultModel<T> Fail(string message, T data, int count)
        {
            return Result("1", message, data, count);
        }

        public static ResultModel<T> Fail(string code, string message, T data, int count)
        {
            return Result(code, message, data, count);
        }

        #endregion 请求失败

        public static ResultModel<T> Result(string code, string msg, T data, int count)
        {
            return new ResultModel<T>()
            {
                code = code,
                msg = msg,
                data = data,
                count = count
            };
        }
    }
}