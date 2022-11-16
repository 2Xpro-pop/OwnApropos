using OwnApropos.Models;
using ReactiveUI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive;
using System.Reactive.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OwnApropos.ViewModels
{
    public class InventoriWindowViewModel: ViewModelBase
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

        public string Name
        {
            get => _name;
            set => this.RaiseAndSetIfChanged(ref _name, value);
        }
        private string _name;

        public IEnumerable<IIdPickable> IdPickables { get; }

        public ReactiveCommand<Unit, Inventory> Save { get; }
        public ReactiveCommand<Unit, Inventory?> Close { get; }

        public InventoriWindowViewModel()
        {
            using var db = new MementoMoriContext();

            IdPickables = db.Fillials.ToArray();
            _name = "Описание действия";

            Save = ReactiveCommand.Create(() =>
            {
                var budget = new BudgetHistory
                {
                    FillialId = FillialId,
                    Action = -Action,
                    Description = $"Куплен предмет {Name}",
                };
                var inventory = new Inventory
                {
                    FillialId = FillialId,
                    Name = Name
                };

                using (var db = new MementoMoriContext())
                {
                    var fillial = db.Fillials.Where(f => f.Id == FillialId).First();

                    db.BudgetHistories.Add(budget);
                    db.Inventories.Add(inventory);

                    fillial.Budget += -Action;

                    db.Fillials.Update(fillial);

                    db.SaveChanges();
                }
                return inventory;
            },
            this.WhenAnyValue(vm => vm.FillialId).Select(id => IdPickables.Any(pickable => pickable.Id == id)));

            Close = ReactiveCommand.Create<Inventory?>(() =>
            {
                return null;
            });
        }
    }
}
