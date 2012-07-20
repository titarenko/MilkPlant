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

        [ActionName("Index"), HttpPut, HttpPost]
        public void Save(Distributor distributor)
        {
            repository.Save(distributor);
        }

        #endregion
    }
}