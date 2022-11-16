using Microsoft.EntityFrameworkCore;
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
    public class PacientsViewModel : ViewModelBase, IRoutableViewModel
    {
        public string? UrlPathSegment => "/fillials";

        public IScreen HostScreen { get; }

        public ObservableCollection<Palate> Palates { get; }
        public Palate SelectedItem
        {
            get => palate;
            set => this.RaiseAndSetIfChanged(ref palate, value);
        }
        Palate palate;

        public ReactiveCommand<Unit, Unit> Remove { get; }
        public ReactiveCommand<Unit, Unit> Save { get; }
        public ReactiveCommand<Unit, Task> Add { get; }

        public PacientsViewModel(IScreen screen)
        {
            HostScreen = screen;

            using var db = new MementoMoriContext();

            Palates = new(db.Palates.Include(p => p.Fillial));

            Remove = ReactiveCommand.Create(() =>
            {
                using var db = new MementoMoriContext();

                db.Palates.Remove(SelectedItem!);
                db.SaveChanges();

                Palates.Remove(SelectedItem!);
            },
            this.WhenAnyValue(vm => vm.SelectedItem).Select(selected => selected != null));

            Add = ReactiveCommand.Create(async () =>
            {
                var dialog = new InventoryWindow();

                var result = await dialog.ShowDialog<Palate>(App.Current.MainWindow);

                if (result == null) return;

                Palates.Add(result);

            });


            Save = ReactiveCommand.Create(() =>
            {
                using var db = new MementoMoriContext();

                db.Palates.UpdateRange(Palates);
                db.SaveChanges();

            });
        }
    }
}
