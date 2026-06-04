using System;
using System.Windows.Input;

public class RelayCommand : ICommand
{
    private readonly Action _execute;

    public RelayCommand(Action execute)
    {
        _execute = execute;
    }

    public event EventHandler CanExecuteChanged;

    public bool CanExecute(object parameter)
    {
        return true; // mindig végrehajtható
    }

    public void Execute(object parameter)
    {
        _execute();
    }
}