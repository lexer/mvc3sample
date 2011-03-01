using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Web.Controllers
{
    using System.Web.Mvc;

    using Domain;

    using Repositories;

    public class ProductsController : Controller
    {
        private readonly IProductRepository productRepository;

        private readonly ICategoryRepository categoryRepository;

        public ProductsController(IProductRepository productRepository, ICategoryRepository categoryRepository)
        {
            this.productRepository = productRepository;
            this.categoryRepository = categoryRepository;
        }

        public ActionResult Index()
        {
            ViewBag.Products = productRepository.GetAll();
            return this.View();
        }

        public ActionResult New()
        {
            ViewBag.Categories = categoryRepository.GetAll() ?? new List<Category>();
            return this.View( new Product());
        }

        [HttpPost]
        public ActionResult Create(Product product)
        {   
            productRepository.Save(product);
            return this.RedirectToAction("Index");
        }

//        public ActionResult Edit(int id)
//        {
//             
//        }
    }
}