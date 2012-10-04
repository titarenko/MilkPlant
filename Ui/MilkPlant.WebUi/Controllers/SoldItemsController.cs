using System.Web.Mvc;
using MilkPlant.Interfaces;

namespace MilkPlant.WebUi.Controllers
{
    public class SoldItemsController : Controller
    {
        private readonly IRepository repository;

        public SoldItemsController(IRepository repository)
        {
            this.repository = repository;
        }

        #region REST API

        [ActionName("Index"), HttpPost]
        public void Save(SoldItem item)
        {
            repository.Save(item);
        }

        #endregion
    }
}