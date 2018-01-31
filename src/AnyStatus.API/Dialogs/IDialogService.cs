namespace AnyStatus.API
{
    public interface IDialogService
    {
        DialogResult ShowDialog(IDialog dialog);
        DialogResult ShowDialog(ConfirmationDialog dialog);
        DialogResult ShowDialog(ErrorDialog dialog);
        DialogResult ShowDialog(InfoDialog dialog);
        DialogResult ShowDialog(OpenFileDialog dialog);
        DialogResult ShowDialog(SaveFileDialog dialog);
        DialogResult ShowDialog(WarningDialog dialog);
    }
}