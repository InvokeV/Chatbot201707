using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Routing;
using Microsoft.Bot.Builder.Dialogs;
using Autofac;

namespace Chatbot201707
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            Conversation.UpdateContainer(containerBuilder =>
            {
                containerBuilder.RegisterType<ChatbotLogger>().AsImplementedInterfaces().InstancePerDependency();
            });

            GlobalConfiguration.Configure(WebApiConfig.Register);
        }
    }
}
