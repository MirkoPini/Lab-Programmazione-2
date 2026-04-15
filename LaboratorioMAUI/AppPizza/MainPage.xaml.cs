using AppPizza.Models;
namespace AppPizza
{
    public partial class MainPage : ContentPage
    {

        List<Pizza> pizze;

        public MainPage()
        {
            InitializeComponent();
            ShowGUI();
        }

        private void ShowGUI()
        {
            pizze = new List<Pizza>();
            pizze.Add(new Pizza("Margherita", 10, "Pomodoro - Mozzarella"));
            pkPizze.ItemsSource = pizze;
        }

        private void OnPizzaSelezionata(object sender, EventArgs e)
        {
            Pizza pizzaSelezionata = (Pizza)pkPizze.SelectedItem;
        }
    }

}
