using Avalonia;
using Avalonia.Controls;
using Avalonia.ReactiveUI;
using OwnApropos.ViewModels;
using System;

namespace OwnApropos.Views
{
    public partial class InventoryWindow : ReactiveWindow<InventoriWindowViewModel>
    {
        public InventoryWindow()
        {
            DataContext = new InventoriWindowViewModel();
            InitializeComponent();

            pickFillial.GetObservable(IdPickableView.IdProperty).Subscribe(x => ViewModel!.FillialId = x);

            ViewModel!.Save.Subscribe(Close);
            ViewModel!.Close.Subscribe(Close);
        }
    }
}
