using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using System.IO;
using NotifySystem.Dtos;
using System.Net.Http;

namespace NotifySystem.Services
{
    class LineService
    {
        /// <summary>
        /// 發送Line訊息
        /// </summary>
        /// <param name="channelToken">Line Channel Token</param>
        /// <param name="userId">Line ID</param>
        /// <param name="message">訊息</param>        
        public void SendMessage(string channelToken, string userId, string message)
        {
            var httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Add("Authorization", $"Bearer {channelToken}");

            var messageData = new
            {
                to = userId,
                messages = new[]
                {
                    new
                    {
                        type = "text",
                        text = message
                    }
                }
            };

            var json = JsonSerializer.Serialize(messageData);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = httpClient.PostAsync("https://api.line.me/v2/bot/message/push", content).Result;
            if (response.IsSuccessStatusCode)
            {
                Console.WriteLine("Message sent successfully!");
            }
            else
            {
                Console.WriteLine("Error sending message.");
                var responseBody = response.Content.ReadAsStringAsync().Result;
                Console.WriteLine(responseBody);
            }
        }
    }
}
