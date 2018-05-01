using System;
using System.Threading.Tasks;
using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Builder.FormFlow;
using System.Collections.Generic;

namespace Chatbot201707.Dialogs
{
    public enum CurryOptions { ビーフ, チキン, ポーク, ベジタブル };
    public enum RiceOptions { ライス, バターライス, ナン };
    public enum SizeOptions { 大, 中, 小 };
    public enum ToppingOptions { トンカツ, コーン, ゆで卵, チーズ, トマト, 辛さ増し, ハラペーニョ };

    [Serializable]
    public class CurryFormQuery
    {
        [Describe("カレー")]
        public CurryOptions? Curry;
        [Describe("ライス")]
        public RiceOptions? Rice;
        [Describe("サイズ")]
        public SizeOptions? Size;
        [Describe("トッピング")]
        public List<ToppingOptions> Topping;
    }

    [Serializable]
    public class CurryDialog : IDialog<CurryFormQuery>
    {
        public  Task StartAsync(IDialogContext context)
        {
            var newForm = FormDialog.FromForm(this.BuildForm, FormOptions.PromptInStart);
            context.Call(newForm, this.CurryResumeAfterDialog);
            return Task.CompletedTask;
        }

        private async Task CurryResumeAfterDialog(IDialogContext context, IAwaitable<CurryFormQuery> result)
        {
            var selectedMenu = await result;
            context.Done(selectedMenu);
        }        

        private IForm<CurryFormQuery> BuildForm()
        {
            return new FormBuilder<CurryFormQuery>()
                    .Message("カレーランチのご注文をお伺いいたします。")
                    //.AddRemainingFields()
//                    .Confirm(@"注文はこちらでよろしいでしょうか？ (1:はい 2:いいえ)

//{Curry}")
                    .Build();
        }
    }
}