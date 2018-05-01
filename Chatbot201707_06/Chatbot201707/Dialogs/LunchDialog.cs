using System;
using System.Threading.Tasks;
using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Connector;
using System.Collections.Generic;

namespace Chatbot201707.Dialogs
{
    [Serializable]
    public class LunchDialog : IDialog<string>
    {
        private List<string> menuList = new List<string>() { "A:チキン南蛮定食", "B:サバの塩焼定食", "C:本日のバスタセット(サラダ・スープ付き)" };
        public Task StartAsync(IDialogContext context)
        {
            PromptDialog.Choice(context, this.SelectDialog, this.menuList, "ランチコースをお選びください。");
            return Task.CompletedTask;
        }

        private async Task SelectDialog(IDialogContext context, IAwaitable<object> result)
        {
            var selectedMenu = await result;
            context.Done(selectedMenu);            
        }
    }
}