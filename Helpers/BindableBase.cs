using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace ujablak.Helpers
{
    //3. az INotifyPropertyChanged-ből is öröklök funkciókat, de ezt nem nézem meg, ezt már megírták a program készítői, mint pl a max() függvényt a LINQ-ban
    // Egy BindableBase nevű osztály, amely értesítést küld, ha egy property értéke megváltozik
    public class BindableBase : INotifyPropertyChanged
    {
        // 4. PropertyChanged nevű esemény, amelyre az adatkötési rendszer (binding engine) feliratkozhat. Ha az esemény bekövetkezik, a feliratkozott vezérlők frissítik a megjelenített értéket.
        // ez az esemény kezdetben (lehet) null, mert a létrehozás pillanatában még nincs feliratkozó, de majd az UI elemek feliratkoznak rá, hogy értesüljenek a változásokról
        public event PropertyChangedEventHandler? PropertyChanged;

        // 5. PropertyChanged esemény OnPropertyChanged nevű segédfüggvénye, amit meghívunk, ha egy property értéke megváltozik
        // A CallerMemberName a meghívó property nevét adja át automatikusan, de meg lehetne adni kézzel is
        //tehát ha a hívó a CurrentView property, akkor a propertyName értéke "CurrentView" lesz

        protected void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            //6. Meghívja az eseményt, és értesíti a feliratkozókat (pl. UI-t), hogy a property frissült
            //A ?. null-feltételes operátor. Csak akkor hívja meg az eseményt, ha a PropertyChanged nem null, vagyis van legalább egy feliratkozó.
            //a this az aktuális objektumot jelenti, pl: MainVM, és az eseményargumentumokban megadjuk a property nevét, pl: "CurrentView"
            //A MainVM objektumban a CurrentView property értéke megváltozott. Az objektum kiváltja a PropertyChanged eseményt, hogy értesítse a feliratkozókat erről a változásról.
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
//elöször létrejön egy üres objektum a MainViewModel osztályból,
//majd amikor a CurrentView property értéke megváltozik,
//meghívja az OnPropertyChanged() metódust,
//amely kiváltja a PropertyChanged eseményt.
//Az esemény értesíti a feliratkozókat (pl. UI elemeket),
//hogy a CurrentView property értéke megváltozott, és frissítik a megjelenített értéket.

//az üres objektum létrehozása után visszatérek a MainViewModel osztály 7. pontjára
