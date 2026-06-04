using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;
using ujablak.Helpers;
using ujablak.Models;
using ujablak.Services;

namespace ujablak.ViewModels
{
    //2.itt átmegyek a BindableBase osztályra, mert onnét öröklök dolgokat
    // A MainViewModel osztály rendelkezik a BindableBase osztály funkcióival, mert megörökölte azokat (: BindableBase). Ez azt jelenti, hogy a MainViewModel képes értesítéseket küldeni, amikor egy property értéke megváltozik, így a UI elemek frissülhetnek.
    public class MainViewModel : BindableBase
    {
        //7. létrehozom a belső és külső tárolókat és propertyket
        //belső, igazi tárolója a CurrentView property-nek.
        private object _currentView;
        //kívülről elérhető property, de a belső tárolója a _currentView változó. 
        public object CurrentView
        {
            //get { return _currentView; } ugyanaz, mint a get => _currentView; 
            get => _currentView;       
            set
            {
                //A value egy beépített kulcsszó a C#-ban. Azt az új értéket jelöli. (Pl. CurrentView = NewProfileView;, akkor a value maga a NewProfileView lesz).
                _currentView = value;
                //8. Amikor a CurrentView property értéke megváltozik, meghívjuk az OnPropertyChanged() metódust BindableBase 6. pontjára ugrunk
                // Amikor a CurrentView property értéke megváltozik, meghívjuk az OnPropertyChanged() metódust, hogy értesítsük a UI-t a változásról.
                OnPropertyChanged();
            }
        }
        //9. létrehozom a Customer listát
        //ObservableCollection: Ez egy "okos" lista, amit kifejezetten a UI(felhasználói felület) számára találtak ki. Egy jelzőrendszerrel felszerelt lista.
        //A Propertyket INotifyPropertyChanged-del követjük le, a listákat pedig ObservableCollection-be tesszük!
        public ObservableCollection<Customer> Customers { get; set; }
        //itt is belső tárolót hozok létre mint korábban a 7. pontban
        private Customer _selectedCustomer;
        //itt is külső property, hogy máshonnét elérhető legyen mint korábban
        public Customer SelectedCustomer
        {
            // minden hasonlóan történik mint a CurrentView property-nél
            get => _selectedCustomer;
            set
            {
                _selectedCustomer = value;
                //mint a 8. pontban
                OnPropertyChanged();
            }
        }

        // --- PARANCSOK (GOMBOKHOZ) ---
        public ICommand ShowListCommand { get; }
        public ICommand ShowInsertCommand { get; }
        public ICommand ShowDeleteCommand { get; }

        // --- KONSTRUKTOR ---
        public MainViewModel()
        {
            // ideiglenes adatok (később TXT-ből jön majd)
            Customers = new ObservableCollection<Customer>(DataService.Load());

            ShowListCommand = new RelayCommand(ShowList);
            ShowInsertCommand = new RelayCommand(ShowInsert);
            ShowDeleteCommand = new RelayCommand(ShowDelete);

            // kezdő nézet
            CurrentView = new ListViewModel(this);
        }

        // --- NÉZET VÁLTÁSOK ---

        private void ShowList()
        {
            CurrentView = new ListViewModel(this);
        }

        private void ShowInsert()
        {
            CurrentView = new InsertViewModel(this);
        }

        private void ShowDelete()
        {
            CurrentView = new DeleteViewModel(this);
        }
    }
}