using System;
using System.Windows;

namespace AnyStatus.API
{
    public interface IDialogService
    {
        DialogResult ShowDialog(IDialog dialog);

        [Obsolete]
        MessageBoxResult Show(string text, string title, MessageBoxButton button, MessageBoxImage image);

        [Obsolete]
        void ShowWarning(string v1, string v2);

        [Obsolete]
        bool? ShowSaveFileDialog(string filter, out string fileName);

        [Obsolete]
        bool? ShowOpenFileDialog(string filter, out string fileName);
    }
}