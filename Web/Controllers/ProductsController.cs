namespace Web.Controllers
{
    using System.Web.Mvc;

    using AutoMapper;

    using Domain;

    using Models;

    using Repositories;

    #region Nested type: ProductsController

    public class ProductsController : Controller
    {
        private readonly ICategoryRepository categoryRepository;

        private readonly IProductRepository productRepository;

        public ProductsController(
            IProductRepository productRepository,
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
                return this.Json(new { Success = true });
            }
            this.ViewBag.Categories = this.categoryRepository.All();
            return this.Json(new { View = this.RenderPartialViewToString("New", product), Success = false });
        }

        public ActionResult Edit(int id)
        {
            this.ViewBag.Categories = this.categoryRepository.All();
            return this.View(Mapper.Map(this.productRepository.Find(id), new ProductInput()));
        }

        [HttpPost]
        public ActionResult Update(ProductInput model)
        {
            if (this.ModelState.IsValid)
            {
                Product product = this.productRepository.Find(model.Id);
                this.productRepository.Update(Mapper.Map(model, product));
                return this.Json(new { Success = true });
            }
            this.ViewBag.Categories = this.categoryRepository.All();
           
            return this.Json(new { View = this.RenderPartialViewToString("Edit", model), Success = false });
             
        }

        public ActionResult Delete(int id)
        {
            Product model = this.productRepository.Find(id);
            this.productRepository.Delete(model);
            return this.RedirectToAction("Index");
        }
    }

    #endregion
}

