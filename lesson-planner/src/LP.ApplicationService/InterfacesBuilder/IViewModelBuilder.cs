using System.Collections.Generic;

namespace LP.ApplicationService.InterfacesBuilder
{
    public interface IViewModelBuilder<TOutputViewModel, TInputModel>
    {
        TOutputViewModel Build(TInputModel model);
        IEnumerable<TOutputViewModel> Build(IEnumerable<TInputModel> models);
    }
}
