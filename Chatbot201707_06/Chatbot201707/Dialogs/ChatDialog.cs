using System;
using System.Threading.Tasks;
using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Builder.Luis;
using Microsoft.Bot.Builder.Luis.Models;

namespace Chatbot201707.Dialogs
{
    [LuisModel("", "")]
    [Serializable]
    public class ChatDialog : LuisDialog<string>
    {
        [LuisIntent("")]
        public async Task None(IDialogContext context, LuisResult result)
        {
            await context.PostAsync($"申し訳ありません注文内容がわかりません。");
            context.Wait(MessageReceived);
        }

        [LuisIntent("Order")]
        public async Task GetOrder(IDialogContext context, LuisResult result)
        {
            EntityRecommendation entity = result.Entities[0];
            string order = entity.Entity;
            context.Done(order);
        }
    }
}