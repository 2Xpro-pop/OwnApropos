using Avalonia;
using Avalonia.Controls;
using Avalonia.ReactiveUI;
using OwnApropos.ViewModels;
using System;

namespace OwnApropos.Views
{
    public partial class BudgetWindow : ReactiveWindow<BudgetWindowViewModel>
    {
        public BudgetWindow()
        {
            DataContext = new BudgetWindowViewModel();
            InitializeComponent();

            pickFillial.GetObservable(IdPickableView.IdProperty).Subscribe(id =>
            {
                ViewModel!.FillialId = id;
            });

            ViewModel!.Save.Subscribe(Close);
            ViewModel!.Close.Subscribe(Close);
        }
    }
}
