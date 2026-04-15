using HelloList.Models;

namespace HelloList
{
    public partial class MainPage : ContentPage
    {
        //Lista di Frutto
        List<Frutto> frutti;

        public MainPage()
        {
            InitializeComponent();
            ShowGUI();
        }

        private void ShowGUI() 
        {
            frutti = new List<Frutto>();
            
            frutti.Add(new Frutto("Mela", "Svizzera"));
            frutti.Add(new Frutto("Pera", "Italia"));
            frutti.Add(new Frutto("Ananas", "Brasile"));
            //frutti.Remove("Mela"); //Rimuoviamo la mela
            //frutti.Insert(1, "Banana"); //Si colloca ad indice 1
            //frutti.RemoveAt(1);
            frutti.Count();
            //Popolato l'item source del Picker
            pickFrutti.ItemsSource = frutti;
        }
    }

}
