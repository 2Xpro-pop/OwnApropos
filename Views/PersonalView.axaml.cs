using Avalonia.Controls;
using Avalonia.ReactiveUI;
using OwnApropos.ViewModels;

namespace OwnApropos.Views
{
    public partial class PersonalView : ReactiveUserControl<PersonalViewModel>
    {
        public PersonalView()
        {
            InitializeComponent();
        }
    }
}
