namespace StroomWeerstandVermogen
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.knopBereken = new System.Windows.Forms.Button();
            this.VermogenOut = new System.Windows.Forms.Label();
            this.stroomInvoer = new System.Windows.Forms.NumericUpDown();
            this.weerstandInvoer = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.stroomInvoer)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.weerstandInvoer)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(74, 77);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Stroom:";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(74, 133);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(91, 20);
            this.label2.TabIndex = 1;
            this.label2.Text = "Weerstand:";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(74, 284);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(87, 20);
            this.label3.TabIndex = 2;
            this.label3.Text = "Vermogen:";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // knopBereken
            // 
            this.knopBereken.Location = new System.Drawing.Point(78, 197);
            this.knopBereken.Name = "knopBereken";
            this.knopBereken.Size = new System.Drawing.Size(369, 41);
            this.knopBereken.TabIndex = 3;
            this.knopBereken.Text = "Bereken";
            this.knopBereken.UseVisualStyleBackColor = true;
            this.knopBereken.Click += new System.EventHandler(this.button1_Click);
            // 
            // VermogenOut
            // 
            this.VermogenOut.AutoSize = true;
            this.VermogenOut.Location = new System.Drawing.Point(180, 284);
            this.VermogenOut.Name = "VermogenOut";
            this.VermogenOut.Size = new System.Drawing.Size(18, 20);
            this.VermogenOut.TabIndex = 4;
            this.VermogenOut.Text = "0";
            // 
            // stroomInvoer
            // 
            this.stroomInvoer.DecimalPlaces = 2;
            this.stroomInvoer.Location = new System.Drawing.Point(184, 77);
            this.stroomInvoer.Name = "stroomInvoer";
            this.stroomInvoer.Size = new System.Drawing.Size(263, 26);
            this.stroomInvoer.TabIndex = 5;
            // 
            // weerstandInvoer
            // 
            this.weerstandInvoer.DecimalPlaces = 2;
            this.weerstandInvoer.Location = new System.Drawing.Point(184, 133);
            this.weerstandInvoer.Maximum = new decimal(new int[] {
            999999999,
            0,
            0,
            0});
            this.weerstandInvoer.Name = "weerstandInvoer";
            this.weerstandInvoer.Size = new System.Drawing.Size(263, 26);
            this.weerstandInvoer.TabIndex = 6;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(940, 802);
            this.Controls.Add(this.weerstandInvoer);
            this.Controls.Add(this.stroomInvoer);
            this.Controls.Add(this.VermogenOut);
            this.Controls.Add(this.knopBereken);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.stroomInvoer)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.weerstandInvoer)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button knopBereken;
        private System.Windows.Forms.Label VermogenOut;
        private System.Windows.Forms.NumericUpDown stroomInvoer;
        private System.Windows.Forms.NumericUpDown weerstandInvoer;
    }
}

