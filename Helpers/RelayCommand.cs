using System;
using System.Windows.Input;
//11. létrehozom a RelayCommand osztályt, amely megvalósítja az ICommand interfészt
//: ICommand megörököltük az ott lévő metódusokat
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