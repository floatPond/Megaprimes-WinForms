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
            this.bMegaPrimes = new System.Windows.Forms.Button();
            this.bCheckIfMegaprime = new System.Windows.Forms.Button();
            this.lInput = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.nudThreadCount = new System.Windows.Forms.NumericUpDown();
            this.bMax = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.nudRunTimes = new System.Windows.Forms.NumericUpDown();
            this.tbOutput = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.nudInput)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudThreadCount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudRunTimes)).BeginInit();
            this.SuspendLayout();
            // 
            // nudInput
            // 
            this.nudInput.Location = new System.Drawing.Point(124, 13);
            this.nudInput.Maximum = new decimal(new int[] {
            -1,
            0,
            0,
            0});
            this.nudInput.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudInput.Name = "nudInput";
            this.nudInput.Size = new System.Drawing.Size(121, 23);
            this.nudInput.TabIndex = 0;
            this.nudInput.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // bCheckIfPrime
            // 
            this.bCheckIfPrime.Location = new System.Drawing.Point(262, 38);
            this.bCheckIfPrime.Name = "bCheckIfPrime";
            this.bCheckIfPrime.Size = new System.Drawing.Size(135, 23);
            this.bCheckIfPrime.TabIndex = 1;
            this.bCheckIfPrime.Text = "Check if Input is Prime";
            this.bCheckIfPrime.UseVisualStyleBackColor = true;
            this.bCheckIfPrime.Click += new System.EventHandler(this.bCheckIfPrime_Click);
            // 
            // bMegaPrimes
            // 
            this.bMegaPrimes.Location = new System.Drawing.Point(262, 105);
            this.bMegaPrimes.Name = "bMegaPrimes";
            this.bMegaPrimes.Size = new System.Drawing.Size(135, 40);
            this.bMegaPrimes.TabIndex = 3;
            this.bMegaPrimes.Text = "Calculate Megaprimes Up To Input";
            this.bMegaPrimes.UseVisualStyleBackColor = true;
            this.bMegaPrimes.Click += new System.EventHandler(this.bMegaPrimes_Click);
            // 
            // bCheckIfMegaprime
            // 
            this.bCheckIfMegaprime.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.bCheckIfMegaprime.Location = new System.Drawing.Point(262, 64);
            this.bCheckIfMegaprime.Name = "bCheckIfMegaprime";
            this.bCheckIfMegaprime.Size = new System.Drawing.Size(135, 38);
            this.bCheckIfMegaprime.TabIndex = 4;
            this.bCheckIfMegaprime.Text = "Check if Input is Megaprime";
            this.bCheckIfMegaprime.UseVisualStyleBackColor = true;
            this.bCheckIfMegaprime.Click += new System.EventHandler(this.bCheckIfMegaprime_Click);
            // 
            // lInput
            // 
            this.lInput.AutoSize = true;
            this.lInput.Location = new System.Drawing.Point(12, 15);
            this.lInput.Name = "lInput";
            this.lInput.Size = new System.Drawing.Size(83, 15);
            this.lInput.TabIndex = 5;
            this.lInput.Text = "Input number:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 46);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 15);
            this.label1.TabIndex = 6;
            this.label1.Text = "Thread count:";
            // 
            // nudThreadCount
            // 
            this.nudThreadCount.Location = new System.Drawing.Point(124, 44);
            this.nudThreadCount.Maximum = new decimal(new int[] {
            64,
            0,
            0,
            0});
            this.nudThreadCount.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudThreadCount.Name = "nudThreadCount";
            this.nudThreadCount.Size = new System.Drawing.Size(121, 23);
            this.nudThreadCount.TabIndex = 7;
            this.nudThreadCount.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // bMax
            // 
            this.bMax.Location = new System.Drawing.Point(262, 13);
            this.bMax.Name = "bMax";
            this.bMax.Size = new System.Drawing.Size(135, 23);
            this.bMax.TabIndex = 8;
            this.bMax.Text = "Max";
            this.bMax.UseVisualStyleBackColor = true;
            this.bMax.Click += new System.EventHandler(this.bMax_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(15, 76);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 15);
            this.label2.TabIndex = 9;
            this.label2.Text = "Run Times:";
            // 
            // nudRunTimes
            // 
            this.nudRunTimes.Location = new System.Drawing.Point(124, 73);
            this.nudRunTimes.Maximum = new decimal(new int[] {
            -1,
            0,
            0,
            0});
            this.nudRunTimes.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudRunTimes.Name = "nudRunTimes";
            this.nudRunTimes.Size = new System.Drawing.Size(121, 23);
            this.nudRunTimes.TabIndex = 10;
            this.nudRunTimes.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // tbOutput
            // 
            this.tbOutput.Location = new System.Drawing.Point(12, 163);
            this.tbOutput.Multiline = true;
            this.tbOutput.Name = "tbOutput";
            this.tbOutput.ReadOnly = true;
            this.tbOutput.Size = new System.Drawing.Size(385, 41);
            this.tbOutput.TabIndex = 11;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(409, 216);
            this.Controls.Add(this.tbOutput);
            this.Controls.Add(this.nudRunTimes);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.bMax);
            this.Controls.Add(this.nudThreadCount);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lInput);
            this.Controls.Add(this.bCheckIfMegaprime);
            this.Controls.Add(this.bMegaPrimes);
            this.Controls.Add(this.bCheckIfPrime);
            this.Controls.Add(this.nudInput);
            this.Name = "Form1";
            this.Text = "Megaprimes";
            ((System.ComponentModel.ISupportInitialize)(this.nudInput)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudThreadCount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudRunTimes)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private NumericUpDown nudInput;
        private Button bCheckIfPrime;
        private Button bMegaPrimes;
        private Button bCheckIfMegaprime;
        private Label lInput;
        private Label label1;
        private NumericUpDown nudThreadCount;
        private Button bMax;
        private Label label2;
        private NumericUpDown nudRunTimes;
        private TextBox tbOutput;
    }
}