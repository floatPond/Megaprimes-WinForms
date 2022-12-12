using Megaprimes_Console;
using System.Threading;

namespace Megaprimes_WinForms
{
    /// <summary>
    /// Main form containing user interactivity for finding prime, megaprime and all megaprimes up to a number
    /// </summary>
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        #region Methods

        private void CheckIfPrime()
        {
            tbOutput.Text = "";
            if (PrimeNumberController.IsPrime((uint)nudInput.Value))
            {
                tbOutput.Text = "Number IS prime";
            }
            else
            {
                tbOutput.Text = "Number IS NOT prime";
            }
        }

        private void CheckIfMegaPrime()
        {
            tbOutput.Text = "";
            if (PrimeNumberController.IsMegaprime((uint)nudInput.Value))
            {
                tbOutput.Text = "Number IS Megaprime";
            }
            else
            {
                tbOutput.Text = "Number IS NOT Megaprime";
            }
        }

        private void FindMegaPrimesUpToNumber()
        {
            tbOutput.Text = "Finding all Megaprimes...";
            TimeSpan timespanTotal = new TimeSpan();
            for (int i = 0; i < nudRunTimes.Value; i++)
            {
                timespanTotal += PrimeNumberController.MegaprimeFinderThreaded((uint)nudThreadCount.Value, (uint)nudInput.Value);
            }
            string total = timespanTotal.TotalSeconds.ToString() + " seconds Total. ";
            timespanTotal = timespanTotal / (uint)nudRunTimes.Value;
            tbOutput.Text = total + Environment.NewLine + (timespanTotal.TotalSeconds.ToString() + " seconds Average.");
            tbOutput.Text += Environment.NewLine + PrimeNumberController.ReturnMegaprimeCount().ToString() + " megaprimes";

            lItems.Items.Clear();
            List<uint> listMegaprimes = PrimeNumberController.ReturnMegaprimeList();
            foreach (uint megaprime in listMegaprimes)
            {
                lItems.Items.Add(megaprime.ToString());
            }
        }

        private void SetInputToMax()
        {
            nudInput.Value = nudInput.Maximum;
        }

        #endregion

        #region Buttons

        private void bCheckIfPrime_Click(object sender, EventArgs e)
        {
            CheckIfPrime();
        }

        private void bCheckIfMegaprime_Click(object sender, EventArgs e)
        {
            CheckIfMegaPrime();
        }

        private void bMegaPrimes_Click(object sender, EventArgs e)
        {
            FindMegaPrimesUpToNumber();
        }

        private void bMax_Click(object sender, EventArgs e)
        {
            SetInputToMax();
        }

        #endregion
    }
}