using ReactiveUI;
using System;

namespace OwnApropos.ViewModels
{
    public class NavButtonViewModel : ViewModelBase, IRoutableViewModel
    {
        public string? UrlPathSegment => Guid.NewGuid().ToString().Substring(0, 5);

        public IScreen HostScreen { get; }

        public NavButtonViewModel(IScreen screen)
        {
            HostScreen = screen;
        }

        public NavButtonViewModel() { }
    }
}