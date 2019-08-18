using BlackJack.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace BlackJack
{
    public class MvcApplication : System.Web.HttpApplication
    {
        public static List<Card> CardList { get; set; }
        public static List<Card> DealerCardList { get; set; }
        public static List<Card> PlayerCardList { get; set; }

        public static Game Game { get; set; } 

        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
    }
}
