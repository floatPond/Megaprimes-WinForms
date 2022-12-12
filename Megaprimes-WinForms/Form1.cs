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

        /// <summary>
        /// Displays whether the input is prime or not
        /// </summary>
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

        /// <summary>
        /// Displays whether the input is megaprime or not
        /// </summary>
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

        /// <summary>
        /// Finds Megaprime numbers upto the input
        /// Displays the total and average time as well as the amount, and a list of the numbers
        /// </summary>
        private void FindMegaprimesUpToNumber()
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

        /// <summary>
        /// Sets the Numeric UpDown to the maximum number (Currently unint max)
        /// </summary>
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
            FindMegaprimesUpToNumber();
        }

        private void bMax_Click(object sender, EventArgs e)
        {
            SetInputToMax();
        }

        #endregion
    }
}