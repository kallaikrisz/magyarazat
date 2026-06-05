using System.Collections.ObjectModel;
using ujablak.Models;

namespace ujablak.ViewModels
{
    //17. létrehozom a ListViewModel osztályt
    public class ListViewModel
    {
        private MainViewModel _mainVM;

        public ObservableCollection<Customer> Customers => _mainVM.Customers;

        public Customer SelectedCustomer
        {
            get => _mainVM.SelectedCustomer;
            set => _mainVM.SelectedCustomer = value;
        }

        public ListViewModel(MainViewModel mainVM)
        {
            _mainVM = mainVM;
        }
    }
}
