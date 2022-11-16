using Avalonia.Controls;
using Avalonia.Data;
using Avalonia.ReactiveUI;
using OwnApropos.ViewModels;
using ReactiveUI;
using System;

namespace OwnApropos.Views
{
    public partial class FillialsView : ReactiveUserControl<FillialsViewModel>
    {
        public FillialsView()
        {
            InitializeComponent();

            this.WhenActivated(disposables =>
            {
                ViewModel!.AddBudget.Subscribe( async x =>
                {
                    await x;
                    fillialsDataGrid.Items = null;
                    fillialsDataGrid.Items = ViewModel.Fillials;
                });
            });

            
        }
    }
}
