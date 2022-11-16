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
    public class InventariesViewModel : ViewModelBase, IRoutableViewModel
    {
        public string? UrlPathSegment => "/fillials";

        public IScreen HostScreen { get; }

        public ObservableCollection<Inventory> Inventories { get; }
        public Inventory SelectedItem 
        {
            get => inventory;
            set => this.RaiseAndSetIfChanged(ref inventory, value);
        }
        Inventory inventory;

        public ReactiveCommand<Unit, Unit> Remove { get; }
        public ReactiveCommand<Unit, Unit> Save { get; }
        public ReactiveCommand<Unit, Task> Add { get; }

        public InventariesViewModel(IScreen screen)
        {
            HostScreen = screen;

            using var db = new MementoMoriContext();

            Inventories = new(db.Inventories);

            Remove = ReactiveCommand.Create(() =>
            {
                using var db = new MementoMoriContext();

                db.Inventories.Remove(SelectedItem!);
                db.SaveChanges();

                Inventories.Remove(SelectedItem!);
            },
            this.WhenAnyValue(vm => vm.SelectedItem).Select(selected => selected != null));

            Add = ReactiveCommand.Create(async () =>
            {
                var dialog = new InventoryWindow();

                var result = await dialog.ShowDialog<Inventory>(App.Current.MainWindow);

                if (result == null) return;

                Inventories.Add(result);

            });


            Save = ReactiveCommand.Create(() =>
            {
                using var db = new MementoMoriContext();

                db.Inventories.UpdateRange(Inventories);
                db.SaveChanges();

            });
        }


    }
}
