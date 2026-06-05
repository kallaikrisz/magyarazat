using System;
using System.Windows.Input;
//11. létrehozom a RelayCommand osztályt, amely megvalósítja az ICommand interfészt
//: ICommand megörököltük az ott lévő metódusokat
public class RelayCommand : ICommand
{
    //belső változó az Action típusú _execute, amely a végrehajtandó műveletet tárolja.
    private readonly Action _execute;
    //konstruktor a RelayCommand osztályhoz, amely egy Action típusú paramétert vár
    //amit kap, azt eltárolja a _execute változóban
    public RelayCommand(Action execute)
    {
        _execute = execute;
    }
    //Az ICommand interfész kötelezően előírja ennek az eseménynek a létezését.
    public event EventHandler CanExecuteChanged;
    //kattintható e?
    //Ha true-t ad vissza, a gomb aktív (kattintható) lesz.
    public bool CanExecute(object parameter)
    {
        return true;
    }
    //Az Execute metódus (A tényleges futás)
    //Amikor a gomb megnyomásra kerül, meghívja a _execute-ben tárolt műveletet.
    public void Execute(object parameter)
    {
        _execute();
    }
}
//vissza a MainViewModel 12. pontra