
using System.Collections.Generic;


namespace NotifySystem.Dtos
{
    class SysConfigDto
    {
        /// <summary>
        /// Line Channel token
        /// </summary>
        public string ChannelAccessToken { get; set; }

        /// <summary>
        /// 寄送訊息給特定Lind ID
        /// </summary>
        public string TargetLindId { get; set; }
    }
}
