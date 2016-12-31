using EmoPlatzi.web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web.Http;

namespace EmotionPlatzi.web
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
            config.Formatters.JsonFormatter.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
            config.Formatters.JsonFormatter.SerializerSettings.PreserveReferencesHandling = Newtonsoft.Json.PreserveReferencesHandling.None;

            //Serializador de XML
            //config.Formatters.XmlFormatter.MaxDepth = 2;
            //config.Formatters.XmlFormatter.UseXmlSerializer = true;
            //var xml = GlobalConfiguration.Configuration.Formatters.XmlFormatter;
            //var dcs = new DataContractSerializer(typeof(EmoPicture), null, int.MaxValue,
            //    false, /* preserveObjectReferences: */ false, null);
            //xml.SetSerializer<EmoPicture>(dcs);
            //var dcs1 = new DataContractSerializer(typeof(EmoFace), null, int.MaxValue,
            //   false, /* preserveObjectReferences: */ false, null);
            //xml.SetSerializer<EmoFace>(dcs1);
            //var dcs2 = new DataContractSerializer(typeof(EmoEmotion), null, int.MaxValue,
            //   false, /* preserveObjectReferences: */ false, null);
            //xml.SetSerializer<EmoEmotion>(dcs2);
        }
    }
}
