using OwnApropos.Models;
using ReactiveUI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive;
using System.Reactive.Linq;
using System.Reactive.Subjects;
using System.Text;
using System.Threading.Tasks;

namespace OwnApropos.ViewModels
{
    public class BudgetWindowViewModel : ViewModelBase
    {
        public int FillialId
        {
            get => _fillialiId;
            set => this.RaiseAndSetIfChanged(ref _fillialiId, value);
        }
        private int _fillialiId;

        public double Action 
        {
            get => _action;
            set => this.RaiseAndSetIfChanged(ref _action, value);
        }
        private double _action;

        public string Description
        {
            get => _description;
            set => this.RaiseAndSetIfChanged(ref _description, value);
        }
        private string _description;

        public IEnumerable<IIdPickable> IdPickables { get; }

        public ReactiveCommand<Unit, BudgetHistory> Save { get; }
        public ReactiveCommand<Unit, BudgetHistory?> Close { get; }

        public BudgetWindowViewModel()
        {
            using var db = new MementoMoriContext();

            IdPickables = db.Fillials.ToArray();
            _description = "Описание действия";

            Save = ReactiveCommand.Create(() =>
            {
                var budget = new BudgetHistory
                {
                    FillialId = FillialId,
                    Action = Action,
                    Description = Description,
                };
                using (var db = new MementoMoriContext())
                {
                    var fillial = db.Fillials.Where(f => f.Id == FillialId).First();

                    db.BudgetHistories.Add(budget);

                    fillial.Budget += Action;

                    db.Fillials.Update(fillial);

                    db.SaveChanges();
                }
                return budget;
            }, 
            this.WhenAnyValue(vm => vm.FillialId).Select(id => IdPickables.Any(pickable => pickable.Id == id)));

            Close = ReactiveCommand.Create<BudgetHistory?>( () =>
            {
                return null;
            });
        }
  
    }
}
