namespace WindowsFormsApplication1
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.refreshRate = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.usedMemoryBar = new System.Windows.Forms.ProgressBar();
            this.usedMemoryLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.refreshRate)).BeginInit();
            this.SuspendLayout();
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.Text = "notifyIcon1";
            this.notifyIcon1.Visible = true;
            // 
            // refreshRate
            // 
            this.refreshRate.Location = new System.Drawing.Point(187, 12);
            this.refreshRate.Minimum = new decimal(new int[] {
            5,
            0,
            0,
            65536});
            this.refreshRate.Name = "refreshRate";
            this.refreshRate.Size = new System.Drawing.Size(85, 20);
            this.refreshRate.TabIndex = 0;
            this.refreshRate.Value = new decimal(new int[] {
            5,
            0,
            0,
            65536});
            this.refreshRate.ValueChanged += new System.EventHandler(this.refreshRate_ValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(114, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Refresh rate (seconds)";
            // 
            // usedMemoryBar
            // 
            this.usedMemoryBar.Location = new System.Drawing.Point(12, 44);
            this.usedMemoryBar.Name = "usedMemoryBar";
            this.usedMemoryBar.Size = new System.Drawing.Size(163, 23);
            this.usedMemoryBar.TabIndex = 2;
            // 
            // usedMemoryLabel
            // 
            this.usedMemoryLabel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.usedMemoryLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.usedMemoryLabel.Location = new System.Drawing.Point(187, 44);
            this.usedMemoryLabel.Name = "usedMemoryLabel";
            this.usedMemoryLabel.Size = new System.Drawing.Size(85, 23);
            this.usedMemoryLabel.TabIndex = 3;
            this.usedMemoryLabel.Text = "MEMORY";
            this.usedMemoryLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 79);
            this.Controls.Add(this.usedMemoryLabel);
            this.Controls.Add(this.usedMemoryBar);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.refreshRate);
            this.Name = "Form1";
            this.Text = "uRAMmeter";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Resize += new System.EventHandler(this.Form1_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.refreshRate)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.NotifyIcon notifyIcon1;
        private System.Windows.Forms.NumericUpDown refreshRate;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ProgressBar usedMemoryBar;
        private System.Windows.Forms.Label usedMemoryLabel;
    }
}

