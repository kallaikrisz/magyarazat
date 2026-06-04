using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;
using ujablak.Helpers;
using ujablak.Models;

namespace ujablak.ViewModels
{
    public class DeleteViewModel
    {
        private MainViewModel _mainVM;

        public ObservableCollection<Customer> Customers => _mainVM.Customers;

        public Customer SelectedCustomer
        {
            get => _mainVM.SelectedCustomer;
            set => _mainVM.SelectedCustomer = value;
        }

        public ICommand DeleteCommand { get; }

        public DeleteViewModel(MainViewModel mainVM)
        {
            _mainVM = mainVM;

            DeleteCommand = new RelayCommand(Delete);
        }

        private void Delete()
        {
            if (_mainVM.SelectedCustomer != null)
            {
                _mainVM.Customers.Remove(_mainVM.SelectedCustomer);
            }
            MessageBox.Show("Sikeres törlés!");
        }
    }
}
