using System.Collections.Generic;
using LP.ApplicationService.InterfacesBuilder;

namespace LP.ApplicationService.Builders
{
    public abstract class
        ViewModelBaseBuilder<TOutputViewModel, TInputModel> : IViewModelBuilder<TOutputViewModel, TInputModel>
    {
        public abstract TOutputViewModel Build(TInputModel model);

        public IEnumerable<TOutputViewModel> Build(IEnumerable<TInputModel> models)
        {
            foreach (var model in models) yield return Build(model);
        }
    }
}
