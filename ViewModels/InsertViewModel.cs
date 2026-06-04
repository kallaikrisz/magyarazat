using System.Windows;
using System.Windows.Input;
using ujablak.Helpers;
using ujablak.Models;

namespace ujablak.ViewModels
{
    public class InsertViewModel : BindableBase
    {
        private MainViewModel _mainVM;

        private string _name;
        public string Name
        {
            get => _name;
            set
            {
                _name = value;
                OnPropertyChanged();
            }
        }

        private string _email;
        public string Email
        {
            get => _email;
            set
            {
                _email = value;
                OnPropertyChanged();
            }
        }

        public ICommand SaveCommand { get; }

        public InsertViewModel(MainViewModel mainVM)
        {
            _mainVM = mainVM;

            SaveCommand = new RelayCommand(Save);
        }

        private void Save()
        {
            _mainVM.Customers.Add(new Customer
            {
                Name = Name,
                Email = Email
            });

            // mezők ürítése
            Name = "";
            Email = "";
            MessageBox.Show("Sikeres mentés!");
        }
    }
}