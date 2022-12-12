using Megaprimes_Console;
using System.Threading;

namespace Megaprimes_WinForms
{
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
            if (PrimeNumberController.IsMegaPrime((uint)nudInput.Value))
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
                timespanTotal += PrimeNumberController.MegaPrimeFinderThreaded((uint)nudThreadCount.Value, (uint)nudInput.Value);
            }
            
            tbOutput.Text = timespanTotal.TotalSeconds.ToString() + " seconds Total.";
            timespanTotal = timespanTotal / (uint)nudRunTimes.Value;
            tbOutput.Text += Environment.NewLine + (timespanTotal.TotalSeconds.ToString() + " seconds Average.");
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