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
    public class FillialWindwowViewModel: ViewModelBase
    {

        public string Name
        {
            get => _name;
            set => this.RaiseAndSetIfChanged(ref _name, value);
        }
        private string _name;

        public string Address
        {
            get => _address;
            set => this.RaiseAndSetIfChanged(ref _address, value);
        }
        private string _address;

        public ReactiveCommand<Unit, Fillial> Save { get; }
        public ReactiveCommand<Unit, Fillial?> Close { get; }

        public FillialWindwowViewModel()
        {
            using var db = new MementoMoriContext();

            _name = "Bvz";
            _address = "адрес";

            Save = ReactiveCommand.Create(() =>
            {
                var fillial = new Fillial
                {
                    Name = Name,
                    Address = Address
                };

                using (var db = new MementoMoriContext())
                {
                    db.Fillials.Add(fillial);

                    db.SaveChanges();
                }
                return fillial;
            });

            Close = ReactiveCommand.Create<Fillial?>( () =>
            {
                return null;
            });
        }
  
    }
}
