using Avalonia;
using Avalonia.Controls;
using Avalonia.Media;
using Avalonia.Media.Imaging;
using Avalonia.ReactiveUI;
using Avalonia.Styling;
using OwnApropos.ViewModels;
using ReactiveUI;
using System.Windows.Input;

namespace OwnApropos.Views
{
    public partial class NavButtonView : UserControl
    {
        public static readonly StyledProperty<ICommand> CommandProperty =
            AvaloniaProperty.Register<NavButtonView, ICommand>(nameof(Command));
        public IImage Image
        {
            get => image.Source;
            set => image.Source = value;
        }

        public string Text
        {
            get => text.Text;
            set => text.Text = value;
        }

        public IBrush Bg
        {
            get => button.Background;
            set => button.Background = value;
        }

        public ICommand Command
        {
            get => GetValue(CommandProperty);
            set
            {
                SetValue(CommandProperty, value);
            }
        }

        public NavButtonView()
        {
            InitializeComponent();

            button[!Button.CommandProperty] = this.GetObservable(CommandProperty).ToBinding();
        }

    }
}
