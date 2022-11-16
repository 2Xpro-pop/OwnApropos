using Avalonia.Controls;
using Avalonia.ReactiveUI;
using OwnApropos.ViewModels;

namespace OwnApropos.Views
{
    public partial class InventariesView : ReactiveUserControl<InventariesViewModel>
    {
        public InventariesView()
        {
            InitializeComponent();
        }
    }
}
