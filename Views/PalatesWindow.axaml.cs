using Avalonia;
using Avalonia.Controls;
using Avalonia.ReactiveUI;
using OwnApropos.ViewModels;
using System;

namespace OwnApropos.Views
{
    public partial class PalatesWindow : ReactiveWindow<PalatesWindowViewModel>
    {
        public PalatesWindow()
        {
            DataContext = new PalatesWindowViewModel();
            InitializeComponent();

            pickFillial.GetObservable(IdPickableView.IdProperty).Subscribe(x => ViewModel!.FillialId = x);

            ViewModel!.Save.Subscribe(Close);
            ViewModel!.Close.Subscribe(Close);
        }
    }
}
