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
            if (string.IsNullOrEmpty(valoreChf))
            {
                return;
            }
            try
            {
                double importoChf = Convert.ToDouble(valoreChf);

                if (importoChf > 0)
                {
                    double importoEuro = importoChf * 1.09;
                    //lblRisultato.Text = "Risultato: " + importoChf.ToString("F2") + " CHF";
                    lblRisultato.Text = string.Format("Risultato: {0:F2} €", importoEuro);
                }
                else
                {
                    VisualizzaErrore();
                }
            }catch(Exception ex)
            {
                VisualizzaErrore();
            }
        }
        private void VisualizzaErrore()
        {
            lblRisultato.Text = "Importo inserito non valido";
            lblRisultato.TextColor = Colors.Red;
        }
        public void btnPulisci_Clicked(object sender, EventArgs e)
        {
            entImporto.Text = "";
            lblRisultato.Text = "Pronto per convertire";
            lblRisultato.TextColor = Colors.White;
            entImporto.Focus();
        }
    }

}
