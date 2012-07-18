[assembly: WebActivator.PreApplicationStartMethod(typeof(MilkPlant.WebUi.App_Start.Combres), "PreStart")]
namespace MilkPlant.WebUi.App_Start {
	using System.Web.Routing;
	using global::Combres;
	
    public static class Combres {
        public static void PreStart() {
            RouteTable.Routes.AddCombresRoute("Combres");
        }
    }
}