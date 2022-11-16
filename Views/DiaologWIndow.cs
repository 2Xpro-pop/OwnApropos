using Avalonia;
using Avalonia.Controls;
using ReactiveUI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive;
using System.Text;
using System.Threading.Tasks;

namespace OwnApropos.Views
{
    public class DiaologWindow: SimpleDialogWindow
    {
        public string? Field { get; set; }

        public ReactiveCommand<Unit, string?> Save { get; }
        public ReactiveCommand<Unit, string> CloseCommand { get; }
        public DiaologWindow(string description) : base()
        {
            textBlock.Text = description;

            textBox.GetObservable(TextBlock.TextProperty).Subscribe(x =>
            {
                Field = x;
            });

            Save = ReactiveCommand.Create(() =>
            {
                return Field;
            });

            CloseCommand = ReactiveCommand.Create(() =>
            {
                return string.Empty;
            });

            Save.Subscribe(Close);
            CloseCommand.Subscribe(Close);

            save.Command = Save;
            close.Command = CloseCommand;
        }

        public static Task<string> Result(string description)
        {
            var dialog = new DiaologWindow(description);

            return dialog.ShowDialog<string>(App.Current.MainWindow);

        }
    }
}
