using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Web.Models
{
    using AutoMapper;

    using Domain;

    using Repositories;

    public class ProductProfile : Profile
    {
        private readonly ICategoryRepository categoryRepository;

        public ProductProfile(ICategoryRepository categoryRepository)
        {
            this.categoryRepository = categoryRepository;
        }
        
        protected override void Configure()
        {
            
            Mapper.CreateMap<ProductInput, Product>()
                .ForMember(r => r.Category, act => act.MapFrom(r => categoryRepository.Find(r.CategoryId)));

            Mapper.CreateMap<Product, ProductInput>();
        }
    }
}