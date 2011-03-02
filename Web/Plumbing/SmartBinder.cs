namespace Web.Plumbing
{
    using System.Web.Mvc;

    public class SmartBinder : DefaultModelBinder
    {
        private readonly IFilteredModelBinder[] _filteredModelBinders;

        public SmartBinder(params IFilteredModelBinder[] filteredModelBinders)
        {
            this._filteredModelBinders = filteredModelBinders;
        }

        public override object BindModel(ControllerContext controllerContext,ModelBindingContext bindingContext)
        {
            foreach (IFilteredModelBinder modelBinder in this._filteredModelBinders)
            {
                if (modelBinder.IsMatch(bindingContext.ModelType))
                {
                    return modelBinder.BindModel(
                        controllerContext,
                        bindingContext);
                }
            }
            return base.BindModel(controllerContext, bindingContext);
        }
    }
}