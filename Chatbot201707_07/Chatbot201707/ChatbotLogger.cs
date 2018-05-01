using System.Diagnostics;
using System.Threading.Tasks;
using Microsoft.Bot.Builder.History;
using Microsoft.Bot.Connector;
using System;
using System.Text;
using System.IO;
using System.Web;

namespace Chatbot201707
{
    public class ChatbotLogger : IActivityLogger
    {
        public async Task LogAsync(IActivity activity)
        {
            DateTime timeStamp = activity.Timestamp.Value;
            string localTimeStamp = (timeStamp + new TimeSpan(9, 00, 00)).ToString();
            string log = $"{localTimeStamp} {activity.From.Name} > {activity.Recipient.Name} : {activity.AsMessageActivity().Text}";

            Debug.WriteLine(log);

            var rootPath = HttpContext.Current.Server.MapPath("~");
            Encoding enc = Encoding.GetEncoding("utf-8");
            using (StreamWriter sw = new StreamWriter($"{rootPath}\\ChatLog.txt", true, enc))
            {
                sw.WriteLine(log);
            }
        }
    }
}