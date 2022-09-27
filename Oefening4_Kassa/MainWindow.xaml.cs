using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Oefening4_Kassa
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        ///Formule om de ondernemingsNR te controleren:
        /// [OndernemingsNR] / 97 = X || 97 - X = [ControleNR]
        /// De quotient word afgerond op 0 cijfers na de komma
        
        long OndernemingsNR;
        long ControleNR;
        float PRIJS;
        float AANTAL;
        float TEBETALEN;

        private void BtnControleNummer_Click(object sender, RoutedEventArgs e)
        {
                //Is er een geldig controleNR ingegeven?
            // [1] Is de controle nummer 10 cijfers lang?
            if (TxtOndernemingsnummer.Text.Length != 10) 
            {
                MessageBox.Show("Geef een geldig controle nummer in.", "Foutcode 1");
                return;
            }
            // [2] Bestaat de controlenummer uit cijfers?
            try //Probeer de waarde om te zetten naar een integer.
            {
                long TestNR = long.Parse(TxtOndernemingsnummer.Text); 
            }
            catch (Exception)
            {
                MessageBox.Show("Geef een geldig controle nummer in.", "Foutcode 2");
                return;
            }

            //Voer de bewerking uit. --> Formule: Deel OndernemingsNR met 97 en rond af op 2 decimalen. Y = rest
            OndernemingsNR = long.Parse(TxtOndernemingsnummer.Text);
            long y = OndernemingsNR % 97;
            ControleNR = 97 - Convert.ToInt16(y);

            //Toon ControleNR
            TxtControlenummer.Text = ControleNR.ToString();
        }

        private void BtnBereken_Click(object sender, RoutedEventArgs e)
        {
            //Controleer of er geldige waardes zijn ingevoerd
            try
            {
                int Z = int.Parse( TxtPrijs.Text);
                int ZZ = int.Parse(TxtAantal.Text);
            }
            catch(Exception)
            {
                MessageBox.Show("Controleer de prijs en aantal opnieuw. Zijn uw prijzen/aantal misschien te hoog?", "Foutcode 3");
                return;
            }

            //Voer de bewerking uit
            PRIJS = float.Parse( TxtPrijs.Text);
            AANTAL = float.Parse(TxtAantal.Text);
            TEBETALEN = PRIJS * AANTAL;
            //Toon Resultaat
            TxtTeBetalen.Text = TEBETALEN.ToString();
        }

        private void BtnWissen_Click(object sender, RoutedEventArgs e)
        {
            //Vragen voor een bevestiging.
            var RESULT = //Is een variable dat ziet welke antwoord werd gegeven bij de messagebox
                MessageBox.Show("Alles wissen?", "Bevestiging", MessageBoxButton.YesNo);

            if (RESULT == MessageBoxResult.Yes) //Indien er "ja" werd geantwoord
            {
                TxtAantal.Clear();
                TxtControlenummer.Clear();
                TxtOndernemingsnummer.Clear();
                TxtPrijs.Clear();
                TxtTeBetalen.Clear();
            }
        }

        private void BtnSluiten_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
