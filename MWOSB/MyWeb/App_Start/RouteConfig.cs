using MyWeb.RouteConstraint;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace MyWeb
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");


            routes.MapRoute(
          name: "Contact",
          url: "iletisim",
          defaults: new { controller = "Contact", action = "Index", id = "0" }
          );

            routes.MapRoute(
          name: "WhatIDo",
          url: "neler-yapiyorum",
          defaults: new { controller = "WhatIDo", action = "Index", id = "0" }
          );

            routes.MapRoute(
           name: "Files",
           url: "dosyalar",
           defaults: new { controller = "Files", action = "Index", id = "0" }
           );

            routes.MapRoute(
           name: "Article",
           url: "makaleler",
           defaults: new { controller = "Articles", action = "Index", id = "0" }
           );

            routes.MapRoute(
           name: "Home",
           url: "anasayfa",
           defaults: new { controller = "Home", action = "Index", id = "0" }
           );


            routes.MapRoute(
           name: "Comment",
           url: "yorumekle",
           defaults: new { controller = "ContentDetail", action = "CommentAdd", id = "0" }
           );

            routes.MapRoute(
          name: "Search",
          url: "ara",
          defaults: new { controller = "Search", action = "Index", id = "0" }
          );


            routes.MapRoute(
  name: "WhatIDoDetail//{title}",
  url: "neler-yapiyorum/{title}",
  defaults: new { controller = "ContentDetail", action = "WhatIDoDetail", id = "0" }
  );

            routes.MapRoute(
 name: "Message//{title}",
 url: "send",
 defaults: new { controller = "Contact", action = "SendMessage" }
 );

            routes.MapRoute(
    name: "FileDetail//{title}",
    url: "dosyalar/{title}",
    defaults: new { controller = "ContentDetail", action = "FileDetail", id = "0" }
    );

            routes.MapRoute(
     name: "ArticleDetail//{title}",
     url: "makaleler/{title}",
     defaults: new { controller = "ContentDetail", action = "Index", id = "0" }
     );


            routes.MapRoute(
     name: "Tags//{title}",
     url: "etiketler/{title}",
     defaults: new { controller = "Tags", action = "Index", id = "0" }
     );

            routes.MapRoute(
             name: "NotFound",
             url: "{*.}",
             defaults: new { controller = "Error", action = "Index" },
             constraints: new { notFound = new NotFoundConstraint() }
             );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = "0" },
                namespaces: new[] { "MyWeb.Controllers" }
            );
        }
    }
}