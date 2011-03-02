namespace Web.Plumbing
{
    using System;
    using System.ComponentModel;
    using System.Web.Mvc;

    using Domain;

    using Repositories;

    public class SmartBinder : DefaultModelBinder
    {
        private readonly IFilteredModelBinder[] _filteredModelBinders;

        public SmartBinder(params IFilteredModelBinder[] filteredModelBinders)
        {
            this._filteredModelBinders = filteredModelBinders;
        }

//        public override object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
//        {
//            foreach (IFilteredModelBinder modelBinder in this._filteredModelBinders)
//            {
//                if (modelBinder.IsMatch(bindingContext.ModelType))
//                {
//                    return modelBinder.BindModel(
//                        controllerContext,
//                        bindingContext);
//                }
//            }
//            return base.BindModel(controllerContext, bindingContext);
//        }

        protected override void SetProperty(
            ControllerContext controllerContext,
            ModelBindingContext bindingContext,
            PropertyDescriptor propertyDescriptor,
            object value)
        {
            var resultValue = value;
            if (typeof(EntityBase).IsAssignableFrom(propertyDescriptor.PropertyType))
            {
                Type repositoryType = typeof(IRepository<>).MakeGenericType(bindingContext.ModelType);
                var repository = (IRepository)DependencyResolver.Current.GetService(repositoryType);
                var model = (EntityBase)value;
                resultValue = repository.Find(model.Id);
            }

            base.SetProperty(controllerContext, bindingContext, propertyDescriptor, resultValue);
        }
    }
}