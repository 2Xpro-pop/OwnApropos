using Avalonia.Controls;
using Avalonia.ReactiveUI;
using OwnApropos.ViewModels;

namespace OwnApropos.Views
{
    public partial class MainWindow : ReactiveWindow<MainWindowViewModel>
    {
        public MainWindow()
        {
            InitializeComponent();
        }
    }
}
