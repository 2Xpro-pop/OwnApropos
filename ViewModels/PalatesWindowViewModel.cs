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
    public class PalatesWindowViewModel: ViewModelBase
    {
        public int FillialId
        {
            get => _fillialiId;
            set => this.RaiseAndSetIfChanged(ref _fillialiId, value);
        }
        private int _fillialiId;

        public int Seats
        {
            get => _seats;
            set => this.RaiseAndSetIfChanged(ref _seats, value);
        }
        private int _seats;

        public string Name
        {
            get => _name;
            set => this.RaiseAndSetIfChanged(ref _name, value);
        }
        private string _name;

        public IEnumerable<IIdPickable> IdPickables { get; }

        public ReactiveCommand<Unit, Palate> Save { get; }
        public ReactiveCommand<Unit, Palate?> Close { get; }

        public PalatesWindowViewModel()
        {
            using var db = new MementoMoriContext();

            IdPickables = db.Fillials.ToArray();
            _name = "имя палаты";

            Save = ReactiveCommand.Create(() =>
            {
                var palate = new Palate
                {
                    FillialId = FillialId,
                    Seats = Seats,
                    Name = Name,
                };
                using (var db = new MementoMoriContext())
                {

                    db.Palates.Add(palate);

                    db.SaveChanges();
                }
                return palate;
            },
            this.WhenAnyValue(vm => vm.FillialId).Select(id => IdPickables.Any(pickable => pickable.Id == id)));

            Close = ReactiveCommand.Create<Palate?>(() =>
            {
                return null;
            });
        }
    }
}
