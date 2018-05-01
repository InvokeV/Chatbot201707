using System;
using System.Threading.Tasks;
using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Connector;
using System.Collections.Generic;

namespace Chatbot201707.Dialogs
{
    [Serializable]
    public class DessertDialog : IDialog<string>
    {
        private List<string> menuList = new List<string>() { "季節のフルーツ", "アイスクリーム", "プリン" };
        public Task StartAsync(IDialogContext context)
        {
            PromptDialog.Choice(context, this.SelectDialog, this.menuList, "デザートをお選びください。");
            return Task.CompletedTask;
        }

        private async Task SelectDialog(IDialogContext context, IAwaitable<object> result)
        {
            var selectedMenu = await result;
            context.Done(selectedMenu);
        }
    }
}