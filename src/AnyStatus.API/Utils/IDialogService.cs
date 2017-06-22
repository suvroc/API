using System.Windows;

namespace AnyStatus.API
{
    public interface IDialogService
    {
        MessageBoxResult Show(string text, string title, MessageBoxButton button, MessageBoxImage image);

        void ShowWarning(string v1, string v2);
    }
}