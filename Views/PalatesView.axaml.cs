using Avalonia.Controls;
using Avalonia.ReactiveUI;
using OwnApropos.ViewModels;

namespace OwnApropos.Views
{
    public partial class PalatesView : ReactiveUserControl<PalatesViewModel>
    {
        public PalatesView()
        {
            InitializeComponent();
        }
    }
}
