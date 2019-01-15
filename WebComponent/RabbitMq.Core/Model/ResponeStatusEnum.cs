using System;
using System.Collections.Generic;
using System.Text;

namespace RabbitMq.Core.Model
{
    /// <summary>
    /// 消息响应枚举
    /// </summary>
    public enum ResponeStatusEnum
    {
        /// <summary>
        /// 成功
        /// </summary>
        SUCCESS = 1000,
        /// <summary>
        /// 失败
        /// </summary>
        FAILED = 1001,
        /// <summary>
        /// 异常
        /// </summary>
        ERROR = 1003
    }
}
