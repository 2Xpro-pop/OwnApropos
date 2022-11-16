using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.ReactiveUI;
using Avalonia.Svg.Skia;
using OwnApropos.ViewModels;
using OwnApropos.Views;
using ReactiveUI;
using Splat;
using System;

namespace OwnApropos
{
    internal class Program
    {
        // Initialization code. Don't use any Avalonia, third-party APIs or any
        // SynchronizationContext-reliant code before AppMain is called: things aren't initialized
        // yet and stuff might break.
        [STAThread]
        public static void Main(string[] args) => BuildAvaloniaApp()
            .StartWithClassicDesktopLifetime(args);

        // Avalonia configuration, don't remove; also used by visual designer.
        public static AppBuilder BuildAvaloniaApp()
        {
            Locator.CurrentMutable.Register(() => new FillialsView(), typeof(IViewFor<FillialsViewModel>));
            Locator.CurrentMutable.Register(() => new PersonalView(), typeof(IViewFor<PersonalViewModel>));
            Locator.CurrentMutable.Register(() => new InventariesView(), typeof(IViewFor<InventariesViewModel>));
            Locator.CurrentMutable.Register(() => new PalatesView(), typeof(IViewFor<PalatesViewModel>));

            using (var db = new MementoMoriContext()) ;

            GC.KeepAlive(typeof(SvgImageExtension).Assembly);
            GC.KeepAlive(typeof(Avalonia.Svg.Skia.Svg).Assembly);
            return AppBuilder.Configure<App>()
                        .UseReactiveUI()
                        .UsePlatformDetect()
                        .LogToTrace();
        }
    }
}
