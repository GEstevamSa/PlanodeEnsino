using System;
using System.Collections.Generic;

namespace LP.ApplicationService.InterfacesBuilder
{
    public interface IBuilder<TModel, TViewModel>
    {
        TModel Build(TViewModel viewModel, Guid stmtId);
        TModel Build(TViewModel viewModel);

        IEnumerable<TModel> Build(IEnumerable<TViewModel> viewModels, Guid stmtId);
        IEnumerable<TModel> Build(IEnumerable<TViewModel> viewModels);
    }
}
