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

        private void bCheckIfPrime_Click(object sender, EventArgs e)
        {
            lResult.Text = "";
            if (PrimeNumberController.IsPrime((uint)nudInput.Value))
            {
                lResult.Text = "true";
            }
            else
            {
                lResult.Text = "false";
            }
            
        }

        private void bMegaPrimes_Click(object sender, EventArgs e)
        {
            lResult.Text = "";
            lResult.Text = (PrimeNumberController.MegaPrimeFinderThreaded(1, (uint)nudInput.Value)).TotalSeconds.ToString();
        }
    }
}