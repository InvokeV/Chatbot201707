using System;
using System.Threading.Tasks;
using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Connector;

namespace Chatbot201707.Dialogs
{
    [Serializable]
    public class HelloDialog : IDialog<object>
    {
        public string userName;
        public string userPlace;
        public Task StartAsync(IDialogContext context)
        {
            context.Wait(HelloMessage);
            return Task.CompletedTask;
        }

        private async Task HelloMessage(IDialogContext context, IAwaitable<object> result)
        {
            var activity = await result as Activity;
            await context.PostAsync("こんにちは！\r\n\r\nお名前は？");
            context.Wait(NameMessage);
        }

        private async Task NameMessage(IDialogContext context, IAwaitable<object> result)
        {
            var activity = await result as Activity;
            userName = activity.Text;
            await context.PostAsync($"{userName}さん、お住まいはどちらですか？");
            context.Wait(PlaceMessage);
        }

        private async Task PlaceMessage(IDialogContext context, IAwaitable<object> result)
        {
            var activity = await result as Activity;
            userPlace = activity.Text;
            await context.PostAsync($"ようこそチャットボットへ！　{userPlace}にお住いの{userName}さん");
            context.Done<object>(null);
        }
    }
}