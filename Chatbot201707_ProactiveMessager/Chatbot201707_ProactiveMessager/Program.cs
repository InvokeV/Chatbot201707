using Microsoft.Bot.Connector;
using System;
using System.Collections.Generic;

namespace Chatbot201707_ProactiveMessager
{
    class Program
    {
        static void Main(string[] args)
        {
            var appId = "<Microsoft App ID>";
            var appPassword = "<Password>";

            //Emulator
            var fromId = "default - user";
            var recipientId = "95i2nkda1dd4";
            var serviceUrl = "http://localhost:64607";
            var conversationId = "g011b863i3j";

            //Facebook
            //var fromId = "1628934843893271";
            //var recipientId = "145452079480720";
            //var serviceUrl = "https://facebook.botframework.com";
            //var conversationId = "1628934843893271-145452079480720";

            //Skype
            //var fromId = "18Afm0cxtapI0G7r6uyqCtK3MDtt38YDR5O6_EHo6NVk";
            //var recipientId = "28:2595fdc3-27b1-4810-a040-efc3da267409";
            //var serviceUrl = "https://smba.trafficmanager.net/apis/";
            //var conversationId = "29:18Afm0cxtapI0G7r6uyqCtK3MDtt38YDR5O6_EHo6NVk";

            //WebChat
            //var fromId = "KEBORI0rmk6";
            //var recipientId = "Chatbot201707@dTuM__gWAS0";
            //var serviceUrl = "https://webchat.botframework.com/";
            //var conversationId = "fd8a04848c4744ddbbcce046f6086967";

            MicrosoftAppCredentials.TrustServiceUrl(serviceUrl);
            var connector = new ConnectorClient(new Uri(serviceUrl), appId, appPassword);
            var botAccount = new ChannelAccount(id: recipientId);
            var userAccount = new ChannelAccount(id: fromId);

            IMessageActivity message = Activity.CreateMessageActivity();
            message.Conversation = new ConversationAccount(id: conversationId);
            message.From = botAccount;
            message.Recipient = userAccount;            
            message.Locale = "ja-jp";
            message.Text = $@"Chatbotからのお知らせです。

本日のおすすめは、季節のフルーツとれたてのあまーいいちごです。";
            var cardImage = new CardImage { Url = "https://chatbot201707.azurewebsites.net/img/strawberry.jpg" };
            var heroCard = new HeroCard { Title = "季節のフルーツ", Images = new List<CardImage> { cardImage }};
            message.Attachments.Add(heroCard.ToAttachment());
            connector.Conversations.SendToConversation((Activity)message);
        }
    }
}