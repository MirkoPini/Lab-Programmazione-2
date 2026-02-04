namespace AppEsempio
{
    public partial class MainPage : ContentPage
    {
        int count = 0;
        int count10 = 0;

        public MainPage()
        {
            InitializeComponent();
        }

        private void OnCounterClicked(object sender, EventArgs e)
        {
            count++;

            if (count == 1)
                CounterBtn.Text = $"Clicked {count} time";
            else
                CounterBtn.Text = $"Clicked {count} times";

            SemanticScreenReader.Announce(CounterBtn.Text);
        }
        private void OnCounterClickedX10(object sender, EventArgs e)
        {
            count10 += 10;
            if (count10 == 1)
                CounterBtnx10.Text = $"Clicked {count10} time";
            else
                CounterBtnx10.Text = $"Clicked {count10} times";

            SemanticScreenReader.Announce(CounterBtnx10.Text);

        }
        private void OnToggleImageClicked(object sender, EventArgs e)
        {
            Marucca.IsVisible = !Marucca.IsVisible;
        }
    }

}
