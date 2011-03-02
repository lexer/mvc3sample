using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Web.Controllers
{
    using System.Web.Mvc;

    using Domain;

    using Repositories;

    public class CategoriesController : Controller
    {  
        private readonly ICategoryRepository categoryRepository;

        public CategoriesController(ICategoryRepository categoryRepository)
        {
            this.categoryRepository = categoryRepository;
        }

        public ActionResult Index()
        {
            this.ViewBag.Categories = this.categoryRepository.All();
            return this.View();
        }

        public ActionResult New()
        {
            this.ViewBag.Categories = this.categoryRepository.All();
            return this.View(new Category());
        }

        [HttpPost]
        public ActionResult Create(Category category)
        {
            if (this.ModelState.IsValid)
            {
                this.categoryRepository.Save(category);
                return this.RedirectToAction("Index"); 
            }
            return this.View("New", category); 
        }

        public ActionResult Edit(int id)
        {
            return this.View(this.categoryRepository.Find(id));
        }

        [HttpPost]
        public ActionResult Update(Category model)
        {
            if (this.ModelState.IsValid)
            {
                var category = categoryRepository.Find(model.Id);
                this.UpdateModel(category);

                this.categoryRepository.Update(category);
                return this.RedirectToAction("Index");
            }

            return this.View("Edit",model); 
        }

        public ActionResult Delete(int id)
        {
            var model = categoryRepository.Find(id);
            categoryRepository.Delete(model);
            return this.RedirectToAction("Index");
        }
    }
}