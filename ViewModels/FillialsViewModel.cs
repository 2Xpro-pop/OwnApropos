using Avalonia;
using Avalonia.Collections;
using Avalonia.Controls;
using DynamicData;
using OwnApropos.Models;
using OwnApropos.Views;
using ReactiveUI;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reactive;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace OwnApropos.ViewModels
{
    public class FillialsViewModel : ViewModelBase, IRoutableViewModel
    {
        public string? UrlPathSegment => Guid.NewGuid().ToString().Substring(0, 5);

        public IScreen HostScreen { get; }

        public ObservableCollection<Fillial> Fillials
        {
            get => _fillials;
            set => this.RaiseAndSetIfChanged(ref _fillials, value);

        }
        private ObservableCollection<Fillial> _fillials = new();


        public BudgetHistory[] BudgetHistories { get; }

        public ObservableCollection<BudgetHistoryVm> BudgetHistorieVms { get;  }
        public Fillial? SelectedFillial
        {
            get => _selectedFillial;
            set => this.RaiseAndSetIfChanged(ref _selectedFillial, value);
        }
        private Fillial? _selectedFillial;

        public ReactiveCommand<Unit, bool> Save { get; }
        public ICommand Add { get; }
        public ReactiveCommand<Unit, Task> AddBudget { get; }

        public FillialsViewModel(IScreen screen)
        {
            HostScreen = screen;

            using(var db = new MementoMoriContext())
            {
                _fillials.AddRange(db.Fillials);
                BudgetHistories = db.BudgetHistories.ToArray();
            }

            BudgetHistorieVms = new(BudgetHistories.Select(
                budget => new BudgetHistoryVm
                {
                    Fillial = budget.Fillial.Name,
                    Description = budget.Description,
                    Currency = budget.Action
                }
            ));

            Save = ReactiveCommand.Create(() =>
            {
                using var db = new MementoMoriContext();

                db.Fillials.UpdateRange(_fillials);
                db.SaveChanges();


                return true;
            });

            Add = ReactiveCommand.Create(async () =>
            {
                var dialog = new FillialWindow();

                var result = await dialog.ShowDialog<Fillial>(App.Current.MainWindow);

                if(result == null)
                {
                    return;
                }

                _fillials.Add(result);
                SelectedFillial = result;
            });

            AddBudget = ReactiveCommand.Create(async () =>
            {
                var dialog = new BudgetWindow();

                var result = await dialog.ShowDialog<BudgetHistory>(App.Current.MainWindow);

                if(result == null)
                {
                    return;
                }

                var fillial = _fillials.First(f => f.Id == result.FillialId);
                fillial.Budget += result.Action;

                BudgetHistorieVms.Add(new BudgetHistoryVm
                {
                    Currency = result.Action,
                    Fillial = fillial.Name,
                    Description = result.Description
                });
            });
        }

        public class BudgetHistoryVm
        {
            public string Fillial { get; set; } = null!;
            public string Description { get; set; } = null!;
            public double Currency { get; set; }
        }

    }
}
