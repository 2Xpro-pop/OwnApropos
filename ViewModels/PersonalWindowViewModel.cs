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
    public class PersonalWindowViewModel:ViewModelBase
    {
        public int FillialId
        {
            get => _fillialiId;
            set => this.RaiseAndSetIfChanged(ref _fillialiId, value);
        }
        private int _fillialiId;

        public double Salary
        {
            get => __alary;
            set => this.RaiseAndSetIfChanged(ref __alary, value);
        }
        private double __alary;

        public string Fio
        {
            get => _fio;
            set => this.RaiseAndSetIfChanged(ref _fio, value);
        }
        private string _fio;

        public string TelefonNumber
        {
            get => _TelefonNumber;
            set => this.RaiseAndSetIfChanged(ref _TelefonNumber, value);
        }
        private string _TelefonNumber;

        public string Address
        {
            get => _Address;
            set => this.RaiseAndSetIfChanged(ref _Address, value);
        }
        private string _Address;

        public string Email
        {
            get => _Email;
            set => this.RaiseAndSetIfChanged(ref _Email, value);
        }
        private string _Email;

        public IEnumerable<IIdPickable> IdPickables { get; }

        public ReactiveCommand<Unit, Personal> Save { get; }
        public ReactiveCommand<Unit, Personal?> Close { get; }

        public PersonalWindowViewModel()
        {
            using var db = new MementoMoriContext();

            IdPickables = db.Fillials.ToArray();
            _fio = "Описание действия";

            Save = ReactiveCommand.Create(() =>
            {
                var personal = new Personal
                {
                    FillialId = FillialId,
                    Salary = Salary,
                    Fio = Fio,
                    Address = Address,
                    Email = Email,
                    TelefonNumber = TelefonNumber
                };
                using (var db = new MementoMoriContext())
                {
                    var fillial = db.Fillials.Where(f => f.Id == FillialId).First();

                    db.Personals.Add(personal);

                    db.Fillials.Update(fillial);

                    db.SaveChanges();
                }
                return personal;
            },
            this.WhenAnyValue(vm => vm.FillialId).Select(id => IdPickables.Any(pickable => pickable.Id == id)));

            Close = ReactiveCommand.Create<Personal?>(() =>
            {
                return null;
            });
        }
    }
}
