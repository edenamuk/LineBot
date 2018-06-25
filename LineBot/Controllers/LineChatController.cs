using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace LineBot.Controllers
{
    public class LineChatController : ApiController
    {
        [Route("api/LineChat")]
        [HttpPost]
        public IHttpActionResult POST()
        {
            string ChannelAccessToken = "GD3FGHjJmIZVTT0lYEUb2znRG6oIhG5thKUB9MotItS1WyfNGPelF148SobaWZMGooCazVMZZLzl92/j6uddgRbMbkXy1Gfj8m1ojkMbs+Nr4rsRU3qz2SNVEj/zjaeYBhWa3IgjhXAfLrb9gaGZrQdB04t89/1O/w1cDnyilFU=";

            try
            {
                //取得 http Post RawData(should be JSON)
                string postData = Request.Content.ReadAsStringAsync().Result;
                //剖析JSON
                var ReceivedMessage = isRock.LineBot.Utility.Parsing(postData);
                //回覆訊息
                string Message;
                Message = "你說了:" + ReceivedMessage.events[0].message.text;
                //回覆用戶
                isRock.LineBot.Utility.ReplyMessage(ReceivedMessage.events[0].replyToken, Message, ChannelAccessToken);
                //回覆API OK
                return Ok();
            }
            catch (Exception ex)
            {
                return Ok();
            }
        }
    }
}
