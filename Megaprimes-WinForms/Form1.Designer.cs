namespace Megaprimes_WinForms
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.nudInput = new System.Windows.Forms.NumericUpDown();
            this.bCheckIfPrime = new System.Windows.Forms.Button();
            this.lResult = new System.Windows.Forms.Label();
            this.bMegaPrimes = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.nudInput)).BeginInit();
            this.SuspendLayout();
            // 
            // nudInput
            // 
            this.nudInput.Location = new System.Drawing.Point(20, 23);
            this.nudInput.Maximum = new decimal(new int[] {
            -1,
            0,
            0,
            0});
            this.nudInput.Name = "nudInput";
            this.nudInput.Size = new System.Drawing.Size(120, 23);
            this.nudInput.TabIndex = 0;
            // 
            // bCheckIfPrime
            // 
            this.bCheckIfPrime.Location = new System.Drawing.Point(150, 22);
            this.bCheckIfPrime.Name = "bCheckIfPrime";
            this.bCheckIfPrime.Size = new System.Drawing.Size(96, 23);
            this.bCheckIfPrime.TabIndex = 1;
            this.bCheckIfPrime.Text = "Check if prime";
            this.bCheckIfPrime.UseVisualStyleBackColor = true;
            this.bCheckIfPrime.Click += new System.EventHandler(this.bCheckIfPrime_Click);
            // 
            // lResult
            // 
            this.lResult.AutoSize = true;
            this.lResult.Location = new System.Drawing.Point(18, 56);
            this.lResult.Name = "lResult";
            this.lResult.Size = new System.Drawing.Size(0, 15);
            this.lResult.TabIndex = 2;
            // 
            // bMegaPrimes
            // 
            this.bMegaPrimes.Location = new System.Drawing.Point(255, 23);
            this.bMegaPrimes.Name = "bMegaPrimes";
            this.bMegaPrimes.Size = new System.Drawing.Size(142, 23);
            this.bMegaPrimes.TabIndex = 3;
            this.bMegaPrimes.Text = "Calculate Megaprimes";
            this.bMegaPrimes.UseVisualStyleBackColor = true;
            this.bMegaPrimes.Click += new System.EventHandler(this.bMegaPrimes_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(409, 216);
            this.Controls.Add(this.bMegaPrimes);
            this.Controls.Add(this.lResult);
            this.Controls.Add(this.bCheckIfPrime);
            this.Controls.Add(this.nudInput);
            this.Name = "Form1";
            this.Text = "Megaprimes";
            ((System.ComponentModel.ISupportInitialize)(this.nudInput)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private NumericUpDown nudInput;
        private Button bCheckIfPrime;
        private Label lResult;
        private Button bMegaPrimes;
    }
}