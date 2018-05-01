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
        public async Task StartAsync(IDialogContext context)
        {
            var message = context.MakeMessage();
            message.Text = "デザートをお選びください。";

            var menuCards = SetHeroCards();
            foreach (var card in menuCards)
            {
                message.Attachments.Add(card.ToAttachment());
            }
            message.AttachmentLayout = AttachmentLayoutTypes.Carousel;
            await context.PostAsync(message);
            context.Wait(MessageReceivedAsync);
        }

        public static HeroCard[] SetHeroCards()
        {
            var cards = new HeroCard[3];
            cards[0] = SetHeroCard("季節のフルーツ", "https://chatbot201707.azurewebsites.net/img/strawberry.jpg");
            cards[1] = SetHeroCard("アイスクリーム", "https://chatbot201707.azurewebsites.net/img/icecream.jpg");
            cards[2] = SetHeroCard("プリン", "https://chatbot201707.azurewebsites.net/img/pudding.jpg");
            return cards;
        }

        private static HeroCard SetHeroCard(string title, string imagePath)
        {
            var cardImage = new CardImage { Url = imagePath };
            var cardAction = new CardAction { Type = ActionTypes.ImBack, Title = "注文する", Value = title, Image = imagePath };
            var heroCard = new HeroCard { Title = title, Images = new List<CardImage> { cardImage }, Buttons = new List<CardAction> { cardAction }, Tap = cardAction };
            return heroCard;
        }

        private async Task MessageReceivedAsync(IDialogContext context, IAwaitable<object> result)
        {
            var activity = await result as Activity;
            context.Done(activity.Text);
        }
    }
}