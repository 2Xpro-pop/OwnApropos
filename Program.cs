using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.ReactiveUI;
using Avalonia.Svg.Skia;
using OwnApropos.ViewModels;
using OwnApropos.Views;
using ReactiveUI;
using Splat;
using System;
using System.Linq;

namespace OwnApropos
{
    internal class Program
    {
        [STAThread]
        public static void Main(string[] args) => BuildAvaloniaApp()
            .StartWithClassicDesktopLifetime(args);

        public static AppBuilder BuildAvaloniaApp()
        {
            Locator.CurrentMutable.Register(() => new FillialsView(), typeof(IViewFor<FillialsViewModel>));
            Locator.CurrentMutable.Register(() => new PersonalView(), typeof(IViewFor<PersonalViewModel>));
            Locator.CurrentMutable.Register(() => new InventariesView(), typeof(IViewFor<InventariesViewModel>));
            Locator.CurrentMutable.Register(() => new PalatesView(), typeof(IViewFor<PalatesViewModel>));

            using(var db = new MementoMoriContext())
            {
                db.Pacients.Add(new Models.Pacient()
                {
                    Name = $"Arnold {Random.Shared.Next(0, 100)}",
                    HasPalate = true,
                    Palate = db.Palates.First(),
                    Personal = db.Personals.First()
                });
                db.SaveChanges();
            }

            GC.KeepAlive(typeof(SvgImageExtension).Assembly);
            GC.KeepAlive(typeof(Avalonia.Svg.Skia.Svg).Assembly);
            return AppBuilder.Configure<App>()
                        .UseReactiveUI()
                        .UsePlatformDetect()
                        .LogToTrace();
        }
    }
}
