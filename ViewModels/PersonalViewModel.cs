using OwnApropos.Models;
using OwnApropos.Views;
using ReactiveUI;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reactive;
using System.Reactive.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OwnApropos.ViewModels
{
    public class PersonalViewModel : ViewModelBase, IRoutableViewModel
    {
        public string? UrlPathSegment => "/personal";

        public IScreen HostScreen { get; }

        public ObservableCollection<IIdPickable> Fillials 
        {
            get => _fillials;
            set => this.RaiseAndSetIfChanged(ref _fillials, value);
        }
        private ObservableCollection<IIdPickable> _fillials;

        public ObservableCollection<Personal> Personals { get; }

        public Personal? SelectedItem 
        {
            get => _selectedItem;
            set => this.RaiseAndSetIfChanged(ref _selectedItem, value); 
        }
        private Personal? _selectedItem = null;

        public ReactiveCommand<Unit, Task> Add { get; } 
        public ReactiveCommand<Unit, Unit> Fire { get; }
        public ReactiveCommand<Unit, Task> AddPremia { get; }
        public ReactiveCommand<Unit, Unit> AddSalary { get; }
        public ReactiveCommand<Unit, Unit> Save { get; }

        public PersonalViewModel(IScreen hostScreen)
        {
            HostScreen = hostScreen;

            using var db = new MementoMoriContext();

            _fillials = new(db.Fillials);
            Personals = new(db.Personals);

            Add = ReactiveCommand.Create(async () =>
            {
                var dialog = new PersonalWindow();
                var result = await dialog.ShowDialog<Personal>(App.Current.MainWindow);

                if(result == null)
                {
                    return;
                }

                Personals.Add(result);
            });

            Fire = ReactiveCommand.Create(() =>
            {
                using var db = new MementoMoriContext();

                db.Personals.Remove(SelectedItem!);
                db.SaveChanges();

                Personals.Remove(SelectedItem!);
            },
            this.WhenAnyValue(vm => vm.SelectedItem).Select(selected => selected != null));

            AddPremia = ReactiveCommand.Create(async () =>
            {
                var premia = int.Parse(await DiaologWindow.Result("Введите сумму"));

                using var db = new MementoMoriContext();

                db.BudgetHistories.Add(new BudgetHistory
                {
                    FillialId = SelectedItem.FillialId,
                    Description = $"Выдана премия {SelectedItem.Fio}",
                    Action = -premia
                });

                var fillial = db.Fillials.First(f => f.Id == SelectedItem.FillialId);
                fillial.Budget -= premia;

                db.Fillials.Update(fillial);

                db.SaveChanges();

                Personals.Remove(SelectedItem!);
            },
            this.WhenAnyValue(vm => vm.SelectedItem).Select(selected => selected != null));

            AddSalary = ReactiveCommand.Create(() =>
            {
                var budgets = new List<BudgetHistory>(Personals.Count);
                
                foreach(var personal in Personals)
                {
                    budgets.Add(new BudgetHistory
                    {
                        FillialId = personal.FillialId,
                        Description = $"Выдана зарплата {personal.Fio}",
                        Action = -personal.Salary
                    });
                    _fillials.First(f => f.Id == personal.FillialId);
                }

                using var db = new MementoMoriContext();

                db.BudgetHistories.AddRange(budgets);
                db.Fillials.UpdateRange(Fillials.Cast<Fillial>());

                db.SaveChanges();
            });

            Save = ReactiveCommand.Create(() =>
            {
                using var db = new MementoMoriContext();

                db.Personals.UpdateRange(Personals);
                db.SaveChanges();

            });
        }
    }
}
