using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Markup.Xaml;
using OwnApropos.Models;
using OwnApropos.ViewModels;
using OwnApropos.Views;
using System.Linq;

namespace OwnApropos
{
    public partial class App : Application
    {
        public static App Current { get; private set; }
        public Window MainWindow { get; set; }
        public override void Initialize()
        {
            Fillial[] fillials;
            using (var db = new MementoMoriContext()) fillials = db.Fillials.ToArray();
            AvaloniaXamlLoader.Load(this);
        }

        public override void OnFrameworkInitializationCompleted()
        {
            Current = this;
            if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
            {
                desktop.MainWindow = new MainWindow
                {
                    DataContext = new MainWindowViewModel(),
                };
                MainWindow = desktop.MainWindow;
            }

            base.OnFrameworkInitializationCompleted();
        }
    }
}
