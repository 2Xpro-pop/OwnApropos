using Avalonia.Controls;
using Avalonia.ReactiveUI;
using OwnApropos.ViewModels;
using System;

namespace OwnApropos.Views
{
    public partial class FillialWindow : ReactiveWindow<FillialWindwowViewModel>
    {
        public FillialWindow()
        {
            DataContext = new FillialWindwowViewModel();
            InitializeComponent();

            ViewModel!.Save.Subscribe(Close);
            ViewModel!.Close.Subscribe(Close);
        }
    }
}
