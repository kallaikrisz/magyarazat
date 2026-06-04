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

        public static List<Customer> Load()
        {
            var customers = new List<Customer>();

            if (!File.Exists(path))
                return customers;

            var lines = File.ReadAllLines(path);

            foreach (var line in lines)
            {
                var parts = line.Split(';');

                if (parts.Length == 2)
                {
                    customers.Add(new Customer
                    {
                        Name = parts[0],
                        Email = parts[1]
                    });
                }
            }

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
