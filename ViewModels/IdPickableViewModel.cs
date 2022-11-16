using OwnApropos.Models;
using ReactiveUI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OwnApropos.ViewModels
{
    public class IdPickableViewModel: ViewModelBase
    {

        public IEnumerable<IIdPickable> IdPickables
        {
            get => _idPickables;
            set => this.RaiseAndSetIfChanged(ref _idPickables, value);
        }
        private IEnumerable<IIdPickable> _idPickables;

        private IIdPickable Selected
        {
            get => _selected;
            set => this.RaiseAndSetIfChanged(ref _selected, value);
        }
        private IIdPickable _selected;

        public int Id
        {
            get => _id;
            set => this.RaiseAndSetIfChanged(ref _id, value);
        }
        private int _id;

        public IdPickableViewModel()
        {
            this.WhenAnyValue(vm => vm.Selected).Subscribe(_ =>
            {
                var a = Id;
                if (Selected != null && Id != Selected.Id) Id = Selected.Id;
            });

            this.WhenAnyValue(vm => vm.Id).Subscribe(_ =>
            {
                var a = Id;
                /*if (IdPickables != null && Id != Selected.Id) Selected = IdPickables.FirstOrDefault(x => x.Id == Id);*/
            });

            this.WhenAnyValue(vm => vm.IdPickables).Subscribe(_ =>
            {
                /*if(IdPickables != null)
                {
                    Selected = IdPickables.FirstOrDefault(x => x.Id == Id);
                }*/
            });

            this.WhenAnyValue(vm => vm.Id, vm => vm.IdPickables).Subscribe(_ =>
            {
                /*if (IdPickables != null)
                {
                    Selected = IdPickables.FirstOrDefault(x => x.Id == Id);
                }*/
            });
        }
    }
}
