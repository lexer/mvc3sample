namespace Web.Plumbing
{
    using System;
    using System.Web.Mvc;

    using Domain;

    using FluentNHibernate.Data;

    using Repositories;

    public class EntityModelBinder : IFilteredModelBinder
    {
        public bool IsMatch(Type modelType)
        {
            return typeof(EntityBase).IsAssignableFrom(modelType);
        }

        public object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {
            ValueProviderResult value = bindingContext.ValueProvider.GetValue(bindingContext.ModelName);
            if (value == null)
            {
                return null;
            }

            if (string.IsNullOrEmpty(value.AttemptedValue))
            {
                return null;
            }

            int entityId;

            if (!int.TryParse(value.AttemptedValue, out entityId))
            {
                return null;
            }

            Type repositoryType = typeof(IRepository<>).MakeGenericType(bindingContext.ModelType);
            var repository = (IRepository)DependencyResolver.Current.GetService(repositoryType);
            EntityBase entity = repository.Find(entityId);
            return entity;
        }
     
         
    }
}