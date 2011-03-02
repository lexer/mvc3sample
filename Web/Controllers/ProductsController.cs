namespace Web.Controllers
{
    using System.Collections.Generic;
    using System.Web.Mvc;

    using Domain;

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
            this.ViewBag.Products = this.productRepository.All();
            return this.View();
        }

        public ActionResult New()
        {
            this.ViewBag.Categories = this.categoryRepository.All();
            return this.View(new Product());
        }

        [HttpPost]
        public ActionResult Create(Product product)
        {
            if (this.ModelState.IsValid)
            {
                this.productRepository.Save(product);
                return this.RedirectToAction("Index"); 
            }
            return this.View("New", product); 
        }

        public ActionResult Edit(int id)
        {
            this.ViewBag.Categories = this.categoryRepository.All();
            return this.View(this.productRepository.Find(id));
        }

        [HttpPost]
        public ActionResult Update(Product model)
        {
            if (this.ModelState.IsValid)
            {
                var product = productRepository.Find(model.Id);
//                var category = categoryRepository.Find(model.Category.Id);
//                product.Category = category;
                this.UpdateModel(product);
                this.productRepository.Update(product);
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