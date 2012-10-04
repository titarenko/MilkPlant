using System.Web.Mvc;
using MilkPlant.Interfaces;
using MilkPlant.Interfaces.Models;

namespace MilkPlant.WebUi.Controllers
{
    public class DistributorsController : Controller
    {
        private readonly IRepository repository;

        public DistributorsController(IRepository repository)
        {
            this.repository = repository;
        }

        #region REST API

        [ActionName("Index"), HttpGet]
        public JsonResult GetAll()
        {
            return Json(repository.GetAll<Distributor>(), JsonRequestBehavior.AllowGet);
        }

        [ActionName("Index"), HttpPost]
        public void Save(Distributor distributor)
        {
            repository.Save(distributor);
        }

        #endregion
    }
}