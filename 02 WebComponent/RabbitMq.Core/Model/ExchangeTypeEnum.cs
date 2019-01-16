using System;
using System.Collections.Generic;
using System.Text;

namespace RabbitMq.Core.Model
{
    /// <summary>
    /// 交换机枚举类型
    /// </summary>
    public enum ExchangeTypeEnum
    {
        fanout = 1,

        direct = 2,

        topic = 3,

        header = 4
    }
}
