namespace Equation
{
    public partial class MainPage : ContentPage
    {
        int count = 0;

        public MainPage()
        {
            InitializeComponent();
        }

        public void btnCalcola_Clicked(object sender, EventArgs e)
        {
            string StrCoeffA = entCoeffA.Text;
            string StrCoeffB = entCoeffB.Text;
            string StrCoeffC = entCoeffC.Text;
            if(string.IsNullOrWhiteSpace(StrCoeffA) || string.IsNullOrWhiteSpace(StrCoeffB) || string.IsNullOrWhiteSpace(StrCoeffC))
            {
                return;
            }
            try
            {
                double CoeffA = Convert.ToDouble(StrCoeffA);
                double CoeffB = Convert.ToDouble(StrCoeffB);
                double CoeffC = Convert.ToDouble(StrCoeffC);

                if (CoeffA == 0)
                {
                    VisualizzaErrore();
                }
                else
                {
                    double Delta = Math.Pow(CoeffB, 2) - 4 * CoeffA * CoeffC;
                    double Result1;
                    double Result2;
                    if(Delta > 0)
                    {
                        lblResult.TextColor = Colors.Green;
                        Result1 = (-CoeffB + Math.Sqrt(Delta)) / (2 * CoeffA);
                        Result2 = (-CoeffB - Math.Sqrt(Delta)) / (2 * CoeffA);
                        lblResult.Text = "Risultati: " + Result1.ToString("F2") + " " + Result2.ToString("F2");
                    }
                    else if (Delta == 0)
                    {
                        lblResult.TextColor = Colors.Blue;
                        Result1 = -CoeffB / (CoeffA * 2);
                        lblResult.Text = "Risultato: " + Result1.ToString("F2");
                    }
                    else if(Delta < 0)
                    {
                        lblResult.TextColor = Colors.Red;
                        lblResult.Text = "Nessuna soluzione reale";
                    }
                }
            }catch(Exception exe)
            {
                VisualizzaErrore();
            }
        }

        public void VisualizzaErrore()
        {
            lblResult.Text = "Coefficenti inseriti invalidi!";
            lblResult.TextColor = Colors.Orange;
        }
    }

}
