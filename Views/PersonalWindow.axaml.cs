using Avalonia;
using Avalonia.Controls;
using Avalonia.ReactiveUI;
using OwnApropos.ViewModels;
using System;

namespace OwnApropos.Views
{
    public partial class PersonalWindow : ReactiveWindow<PersonalWindowViewModel>
    {
        public PersonalWindow()
        {
            DataContext = new PersonalWindowViewModel();
            InitializeComponent();

            pickFillial.GetObservable(IdPickableView.IdProperty).Subscribe(x => ViewModel!.FillialId = x);

            ViewModel!.Save.Subscribe(Close);
            ViewModel!.Close.Subscribe(Close);
        }
    }
}
