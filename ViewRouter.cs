using OwnApropos.ViewModels;
using OwnApropos.Views;
using ReactiveUI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OwnApropos
{
    public class ViewRouter : IViewLocator
    {
        public IViewFor? ResolveView<T>(T viewModel, string? contract = null)
        {
            return viewModel switch
            {
                FillialsViewModel vm => new FillialsView { ViewModel = vm, DataContext = vm },
                _ => throw new ArgumentOutOfRangeException(nameof(viewModel))
            };
        }
    }
}
