using System.Windows;
using ujablak.Services;
using ujablak.ViewModels;
using System.Linq;

namespace ujablak
{
    public partial class App : Application
    {
        //1. itt átmegyek a MainViewModel osztályra, mert egy olyat hozok létre
        //létrejön egy MainVM nevű property, amely a MainViewModel típusú objektumot tárolja.
        public MainViewModel MainVM { get; set; }
        //felülírom az eredeti OnStartup metódust, amely a program indításakor fut le. 
        protected override void OnStartup(StartupEventArgs e)
        {
            //először meghívom az eredeti OnStartup metódust, hogy a program alapértelmezett indítási logikája is végrehajtódjon.
            base.OnStartup(e);
            //ezután létrehozok egy új MainViewModel objektumot, amelyet a MainVM property-hez rendelünk.
            MainVM = new MainViewModel();
        }
        //felülírom az eredeti OnExit metódust, amely a program bezárásakor fut le.
        protected override void OnExit(ExitEventArgs e)
        {
            //először meghívom az eredeti OnExit metódust, hogy a program alapértelmezett bezárási logikája is végrehajtódjon.
            base.OnExit(e);
            //mentem az adatokat a DataService segítségével, mielőtt a program bezárulna.
            //Meghívom a DataService osztály Save metódusát, és átadom neki a MainVM.Customers listáját.
            //a Save() metódusban: public static void Save(IEnumerable<Customer> customers) 
            // MainViewModel-ben: public ObservableCollection<Customer> Customers { get; set; }
            DataService.Save(MainVM.Customers);
        }
    }
}
