using Reward.Utils.FileSystem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UnityTest.Web.Entities;
using UnityTest.Web.Services;

namespace UnityTest.Web.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            this._productService = productService;
        }

        // GET: Product
        public ActionResult Index()
        {
            var model = this._productService.GetProducts();
            if(model.Count == 0)
            {
                this.CreateProducts();
                model = this._productService.GetProducts();
            }

            return View(this._productService.GetProducts());
        }

        private void CreateProducts()
        {
            for (var i = 1; i < 10; i++)
                this._productService.AddProduct(new Product(string.Format("Product - {0}", i), new Random().Next(100, 564654)));
        }
    }
}