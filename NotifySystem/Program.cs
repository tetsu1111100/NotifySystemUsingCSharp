using NotifySystem.Dtos;
using NotifySystem.Services;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace NotifySystem
{
    class Program
    {
        static void Main(string[] args)
        {
            SendLineMsg();
            Console.ReadLine();
        }

        /// <summary>
        /// 發送Line訊息
        /// </summary>
        public static void SendLineMsg()
        {
            //Line 設定檔
            string jsonPath = "app.json";
            string jsonContent = File.ReadAllText(jsonPath);
            SysConfigDto config = JsonSerializer.Deserialize<SysConfigDto>(jsonContent);

            //Line service
            //這裡的Line ID (TargetLindId) 非一般使用者交換LINE時所使用的ID，需要額外特透一些方式取得
            LineService lineService = new LineService();
            lineService.SendMessage(config.ChannelAccessToken, config?.TargetLindId, "hi, I'm line message.");
        }
    }
}
