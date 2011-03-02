namespace Web.Controllers
{
    using System.Collections.Generic;
    using System.Web.Mvc;

    using AutoMapper;

    using Domain;

    using Models;

    using Repositories;

    public class ProductsController : Controller
    {
        private readonly IProductRepository productRepository;

        private readonly ICategoryRepository categoryRepository;

        public ProductsController(IProductRepository productRepository,
            ICategoryRepository categoryRepository)
        {
            this.productRepository = productRepository;
            this.categoryRepository = categoryRepository;
        }

        public ActionResult Index()
        {
            this.ViewBag.Products = this.productRepository.AllWithCategory();
            return this.View();
        }

        public ActionResult New()
        {
            this.ViewBag.Categories = this.categoryRepository.All();
            return this.View(new ProductInput());
        }

        [HttpPost]
        public ActionResult Create(ProductInput product)
        {
            if (this.ModelState.IsValid)
            {
                this.productRepository.Save(Mapper.Map(product, new Product()));
                return this.RedirectToAction("Index"); 
            }
            return this.View("New", product); 
        }

        public ActionResult Edit(int id)
        {
            this.ViewBag.Categories = this.categoryRepository.All();
            return this.View( Mapper.Map(this.productRepository.Find(id), new ProductInput()));
        }

        [HttpPost]
        public ActionResult Update(ProductInput model)
        {
            if (this.ModelState.IsValid)
            {
                var product = productRepository.Find(model.Id);
                this.productRepository.Update(Mapper.Map(model, product));
                return this.RedirectToAction("Index");
            }

            return this.View("Edit",model); 
        }

        public ActionResult Delete(int id)
        {
            var model = productRepository.Find(id);
            productRepository.Delete(model);
            return this.RedirectToAction("Index");
        }
    }
}