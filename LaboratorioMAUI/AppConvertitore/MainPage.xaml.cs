namespace AppConvertitore
{
    public partial class MainPage : ContentPage
    {

        public MainPage()
        {
            //Inizzializza i componenti grafici
            InitializeComponent();
        }

        private void btnConverti_Clicked(object sender, EventArgs e)
        {
            string valoreChf = entImporto.Text;
            double importoChf = Convert.ToDouble(valoreChf);

            if(importoChf > 0)
            {
                importoChf = importoChf * 1.09;
                //lblRisultato = "Risultato: " + importoChf;
                //SemanticScreenReader.Announce(lblRisultato.Text);
            }
            else
            {

            }
        }
    }

}
