using System.Web.Mvc;
using MilkPlant.Interfaces;

namespace MilkPlant.WebUi.Controllers
{
    public class ProductsController : Controller
    {
        private readonly IProductAnalytics analytics;

        public ProductsController(IProductAnalytics analytics)
        {
            this.analytics = analytics;
        }

        public ActionResult BestSellers()
        {
            return View(analytics.GetBestSellers(10));
        }
    }
}