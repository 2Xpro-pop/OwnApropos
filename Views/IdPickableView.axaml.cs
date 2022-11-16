using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.Primitives;
using Avalonia.Data;
using Avalonia.Media.TextFormatting;
using Avalonia.ReactiveUI;
using OwnApropos.Models;
using OwnApropos.ViewModels;
using System.Collections.Generic;
using System.Reactive;
using ReactiveUI;
using System;
using System.Linq;

namespace OwnApropos.Views
{
    public partial class IdPickableView : ReactiveUserControl<IdPickableViewModel>
    {
        public static readonly DirectProperty<IdPickableView,int> IdProperty = AvaloniaProperty.RegisterDirect<IdPickableView, int>(
            nameof(Id),
            o => o.GetId(), 
            (o, v) => o.SetId(v),
            defaultBindingMode: BindingMode.TwoWay
        );

        public static readonly DirectProperty<IdPickableView, IEnumerable<IIdPickable>> IdPickablesProperty =
            AvaloniaProperty.RegisterDirect<IdPickableView, IEnumerable<IIdPickable>>(
                nameof(IdPickables),
                o => o.IdPickables,
                (o,v) => o.IdPickables = v
            );



        public IEnumerable<IIdPickable> IdPickables
        {
            get => _idPickables;
            set
            {
                SetAndRaise(IdPickablesProperty, ref _idPickables, value);            
            }
        }
        private IEnumerable<IIdPickable> _idPickables;

        public int Id 
        {
            get => GetId();
            set => SetId(value);
        }
        private int _id;

        public IdPickableView()
        {
            InitializeComponent();

            comboBox[!ComboBox.ItemsProperty] = this[!IdPickablesProperty];

            this.GetObservable(IdProperty).Subscribe(id =>
            {
                comboBox.SelectedItem = IdPickables?.FirstOrDefault(idPickable => idPickable.Id == id);
            });

            this.GetObservable(IdPickablesProperty).Subscribe(pickables =>
            {
                var idPickable = (IIdPickable?)comboBox.SelectedItem;

                if (idPickable?.Id != Id)
                {
                    comboBox.SelectedItem = pickables?.First(idPickable => idPickable.Id == _id);
                }
            });

            comboBox.GetObservable(ComboBox.SelectedItemProperty).Subscribe(selected =>
            {
                if (selected == null) return;

                var idPickable = (IIdPickable)selected;

                if (idPickable.Id != Id)
                {
                    Id = idPickable.Id;
                }
            });
        }

        protected override void OnApplyTemplate(TemplateAppliedEventArgs e)
        {
            base.OnApplyTemplate(e);
        }

        private void SetId(int value)
        {
            SetAndRaise(IdProperty, ref _id, value);
        }

        private int GetId() => _id;
    }
}
