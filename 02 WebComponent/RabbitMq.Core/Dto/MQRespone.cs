using RabbitMq.Core.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace RabbitMq.Core.Dto
{
    /// <summary>
    /// 消息回调响应类
    /// </summary>
    public class MQRespone
    {
        /// <summary>
        /// 响应状态
        /// </summary>
        public ResponeStatusEnum ResponeStatusEnum { get; set; }
        /// <summary>
        /// 消息正文
        /// </summary>
        public Body Body { get; set; }
        /// <summary>
        /// 消息序列号
        /// </summary>
        public string SerialNumber { get; set; }
    }
}
