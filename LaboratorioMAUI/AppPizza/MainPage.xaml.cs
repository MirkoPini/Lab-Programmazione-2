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
            pizze.Add(new Pizza("Pizza Margherita", 10, "Pomodoro - Mozzarella", "pizza_margherita.png"));
            pkPizze.ItemsSource = pizze;
        }

        private void OnPizzaSelezionata(object sender, EventArgs e)
        {
            Pizza pizzaSelezionata = (Pizza)pkPizze.SelectedItem;
            lblNomePizza.Text = pizzaSelezionata.Nome;
            lblPrezzoPizza.Text = pizzaSelezionata.Prezzo + " FR.-";
            lblIngredientiPizza.Text = pizzaSelezionata.Ingredienti;
            imgPizza.Source = pizzaSelezionata.Immagine;
        }
    }

}
