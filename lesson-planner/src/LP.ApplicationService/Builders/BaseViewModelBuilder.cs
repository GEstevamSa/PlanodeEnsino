using System;
using System.Collections.Generic;
using System.Linq;
using LP.ApplicationService.InterfacesBuilder;

namespace LP.ApplicationService.Builders
{
    public abstract class BaseViewModelBuilder<TModel, TViewModel> : IBuilder<TModel, TViewModel>
    {
        public abstract TModel Build(TViewModel viewModel, Guid stmtId);
        public abstract TModel Build(TViewModel viewModel);

        public IEnumerable<TModel> Build(IEnumerable<TViewModel> viewModels, Guid stmtId)
        {
            return viewModels.Select(item => Build(item, stmtId));
        }

        public IEnumerable<TModel> Build(IEnumerable<TViewModel> viewModels)
        {
            return viewModels.Select(Build);
        }
    }
}
