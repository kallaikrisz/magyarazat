using System.Collections.Generic;
using System.IO;
using System.Windows;
using ujablak.Models;

namespace ujablak.Services
{
    public static class DataService
    {
        //projektben bin/Debug/net10.0/customers.txt 
        private static string path = "customers.txt";
        //15. pont a Load függvény
        //A Load visszaad egy List<Customer> listát
        //a static kulcsszó miatt nem kell példányosítani a DataService osztályt
        //nem kell pl.: var data = new DataService(); var customers = data.Load();
        //hanem egyszerűen: var customers = DataService.Load();
        public static List<Customer> Load()
        {
            //ezt adja majd vissza a return utasítás, ide gyűjtjük ki a fájlból beolvasott adatokat.
            var customers = new List<Customer>();
            //ha nincs ilyen fájl, akkor csak egy üres listát adunk vissza
            if (!File.Exists(path)) return customers;

            //string[] lines = File.ReadAllLines(path); a string sorokat tömbbe teszi ki
            var lines = File.ReadAllLines(path);
            //minden sort feldarabolunk
            foreach (var line in lines)
            {
                var parts = line.Split(';');
                //ha 2 darabra sikerült szétvágni akkor a customers.Add()-al beletesszük a listába
                if (parts.Length == 2)
                {
                    customers.Add(new Customer
                    {
                        Name = parts[0],
                        Email = parts[1]
                    });
                    /*
                    ugyanaz kicsit hosszabban:
                    var aktualis = new Customer();
                    aktualis.Name = parts[0];
                    aktualis.Email = parts[1];
                    customers.Add(aktualis);
                    */
                }
            }
            //visszaadjuk a listát oda ahol ezt meghívták. vissza a MainViewModels 16. pontjára
            return customers;
        }
        //Az IEnumerable jelentése nagyjából: "Bármi, ami sorba rendezhető és végig lehet rajta menni egy ciklussal."
        // miért nem ObservableCollection<Customer> customers ahogy eredetileg létrehoztuk a MainViewModel-ben?
        // azért mert már nincs szükség a jelzőrendszerre, mivel a fájlba mentéskor nem kell értesíteni a UI-t a változásokról.

        public static void Save(IEnumerable<Customer> customers)
        {
            //string listát készítek, mert azt könnyű kiírni egyetlen paranccsal (File.WriteAllLines) egy txt-be.
            var lines = new List<string>();
            //átpakolom az adatokat ;-vel elválasztva egy stringbe, majd hozzáadom a listához.
            foreach (var c in customers)
            {
                lines.Add($"{c.Name};{c.Email}");
            }
            //kiírom a megadott helyen található fájlba az összes sort egyszerre.
            File.WriteAllLines(path, lines);
        }
    }
}
