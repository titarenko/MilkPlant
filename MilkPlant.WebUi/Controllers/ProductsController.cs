﻿using System.Web.Mvc;
using MilkPlant.Interfaces;
using MilkPlant.Interfaces.Models;

namespace MilkPlant.WebUi.Controllers
{
    public class ProductsController : Controller
    {
        private readonly IProductAnalytics analytics;
        private readonly IRepository repository;

        public ProductsController(IProductAnalytics analytics, IRepository repository)
        {
            this.analytics = analytics;
            this.repository = repository;
        }

        public ActionResult BestSellers()
        {
            return View(analytics.GetBestSellers(10));
        }

        #region REST API

        [ActionName("Index"), HttpPost, HttpPut]
        public void Save(Product product)
        {
            repository.Save(product);
        }

        #endregion
    }
}