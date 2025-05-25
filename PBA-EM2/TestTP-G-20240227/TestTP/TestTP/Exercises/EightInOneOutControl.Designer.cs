namespace TestTP.Exercises
{
    partial class EightInOneOutControl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.txtOpgave = new System.Windows.Forms.RichTextBox();
            this.Panel3 = new System.Windows.Forms.Panel();
            this.Label2 = new System.Windows.Forms.Label();
            this.btnManual = new System.Windows.Forms.Button();
            this.btnAuto = new System.Windows.Forms.Button();
            this.txtOutput = new System.Windows.Forms.TextBox();
            this.Label3 = new System.Windows.Forms.Label();
            this.txtInput1 = new System.Windows.Forms.MaskedTextBox();
            this.txtInput3 = new System.Windows.Forms.MaskedTextBox();
            this.txtInput2 = new System.Windows.Forms.MaskedTextBox();
            this.txtInput4 = new System.Windows.Forms.MaskedTextBox();
            this.txtInput5 = new System.Windows.Forms.MaskedTextBox();
            this.txtInput6 = new System.Windows.Forms.MaskedTextBox();
            this.txtInput7 = new System.Windows.Forms.MaskedTextBox();
            this.txtInput8 = new System.Windows.Forms.MaskedTextBox();
            this.tableLayoutPanel1.SuspendLayout();
            this.Panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.BackColor = System.Drawing.SystemColors.Window;
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.txtOpgave, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.Panel3, 1, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(689, 406);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // txtOpgave
            // 
            this.txtOpgave.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtOpgave.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtOpgave.Location = new System.Drawing.Point(0, 0);
            this.txtOpgave.Margin = new System.Windows.Forms.Padding(0, 0, 10, 0);
            this.txtOpgave.Name = "txtOpgave";
            this.txtOpgave.ReadOnly = true;
            this.txtOpgave.Size = new System.Drawing.Size(334, 406);
            this.txtOpgave.TabIndex = 0;
            this.txtOpgave.Text = "";
            // 
            // Panel3
            // 
            this.Panel3.BackColor = System.Drawing.SystemColors.Window;
            this.Panel3.Controls.Add(this.txtInput8);
            this.Panel3.Controls.Add(this.txtInput7);
            this.Panel3.Controls.Add(this.txtInput6);
            this.Panel3.Controls.Add(this.txtInput5);
            this.Panel3.Controls.Add(this.txtInput4);
            this.Panel3.Controls.Add(this.Label2);
            this.Panel3.Controls.Add(this.btnManual);
            this.Panel3.Controls.Add(this.btnAuto);
            this.Panel3.Controls.Add(this.txtOutput);
            this.Panel3.Controls.Add(this.Label3);
            this.Panel3.Controls.Add(this.txtInput1);
            this.Panel3.Controls.Add(this.txtInput3);
            this.Panel3.Controls.Add(this.txtInput2);
            this.Panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Panel3.Location = new System.Drawing.Point(354, 0);
            this.Panel3.Margin = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.Panel3.Name = "Panel3";
            this.Panel3.Size = new System.Drawing.Size(335, 406);
            this.Panel3.TabIndex = 25;
            // 
            // Label2
            // 
            this.Label2.AutoSize = true;
            this.Label2.Location = new System.Drawing.Point(55, 88);
            this.Label2.Name = "Label2";
            this.Label2.Size = new System.Drawing.Size(31, 13);
            this.Label2.TabIndex = 11;
            this.Label2.Text = "Input";
            // 
            // btnManual
            // 
            this.btnManual.Location = new System.Drawing.Point(134, 201);
            this.btnManual.Name = "btnManual";
            this.btnManual.Size = new System.Drawing.Size(75, 23);
            this.btnManual.TabIndex = 3;
            this.btnManual.Text = "Manueel";
            this.btnManual.UseVisualStyleBackColor = true;
            this.btnManual.Click += new System.EventHandler(this.btnManual_Click);
            // 
            // btnAuto
            // 
            this.btnAuto.Location = new System.Drawing.Point(134, 230);
            this.btnAuto.Name = "btnAuto";
            this.btnAuto.Size = new System.Drawing.Size(75, 23);
            this.btnAuto.TabIndex = 4;
            this.btnAuto.Text = "Auto";
            this.btnAuto.UseVisualStyleBackColor = true;
            this.btnAuto.Click += new System.EventHandler(this.btnAuto_Click);
            // 
            // txtOutput
            // 
            this.txtOutput.BackColor = System.Drawing.SystemColors.Window;
            this.txtOutput.Location = new System.Drawing.Point(249, 218);
            this.txtOutput.Name = "txtOutput";
            this.txtOutput.ReadOnly = true;
            this.txtOutput.Size = new System.Drawing.Size(61, 20);
            this.txtOutput.TabIndex = 10;
            // 
            // Label3
            // 
            this.Label3.AutoSize = true;
            this.Label3.Location = new System.Drawing.Point(253, 88);
            this.Label3.Name = "Label3";
            this.Label3.Size = new System.Drawing.Size(52, 13);
            this.Label3.TabIndex = 12;
            this.Label3.Text = "Resultaat";
            // 
            // txtInput1
            // 
            this.txtInput1.Location = new System.Drawing.Point(40, 126);
            this.txtInput1.Mask = "#####";
            this.txtInput1.Name = "txtInput1";
            this.txtInput1.Size = new System.Drawing.Size(61, 20);
            this.txtInput1.TabIndex = 15;
            this.txtInput1.ValidatingType = typeof(int);
            // 
            // txtInput3
            // 
            this.txtInput3.Location = new System.Drawing.Point(40, 178);
            this.txtInput3.Mask = "#####";
            this.txtInput3.Name = "txtInput3";
            this.txtInput3.Size = new System.Drawing.Size(61, 20);
            this.txtInput3.TabIndex = 18;
            this.txtInput3.ValidatingType = typeof(int);
            // 
            // txtInput2
            // 
            this.txtInput2.Location = new System.Drawing.Point(40, 152);
            this.txtInput2.Mask = "#####";
            this.txtInput2.Name = "txtInput2";
            this.txtInput2.Size = new System.Drawing.Size(61, 20);
            this.txtInput2.TabIndex = 17;
            this.txtInput2.ValidatingType = typeof(int);
            // 
            // txtInput4
            // 
            this.txtInput4.Location = new System.Drawing.Point(40, 204);
            this.txtInput4.Mask = "#####";
            this.txtInput4.Name = "txtInput4";
            this.txtInput4.Size = new System.Drawing.Size(61, 20);
            this.txtInput4.TabIndex = 19;
            this.txtInput4.ValidatingType = typeof(int);
            // 
            // txtInput5
            // 
            this.txtInput5.Location = new System.Drawing.Point(40, 230);
            this.txtInput5.Mask = "#####";
            this.txtInput5.Name = "txtInput5";
            this.txtInput5.Size = new System.Drawing.Size(61, 20);
            this.txtInput5.TabIndex = 20;
            this.txtInput5.ValidatingType = typeof(int);
            // 
            // txtInput6
            // 
            this.txtInput6.Location = new System.Drawing.Point(40, 256);
            this.txtInput6.Mask = "#####";
            this.txtInput6.Name = "txtInput6";
            this.txtInput6.Size = new System.Drawing.Size(61, 20);
            this.txtInput6.TabIndex = 21;
            this.txtInput6.ValidatingType = typeof(int);
            // 
            // txtInput7
            // 
            this.txtInput7.Location = new System.Drawing.Point(40, 282);
            this.txtInput7.Mask = "#####";
            this.txtInput7.Name = "txtInput7";
            this.txtInput7.Size = new System.Drawing.Size(61, 20);
            this.txtInput7.TabIndex = 22;
            this.txtInput7.ValidatingType = typeof(int);
            // 
            // txtInput8
            // 
            this.txtInput8.Location = new System.Drawing.Point(40, 308);
            this.txtInput8.Mask = "#####";
            this.txtInput8.Name = "txtInput8";
            this.txtInput8.Size = new System.Drawing.Size(61, 20);
            this.txtInput8.TabIndex = 23;
            this.txtInput8.ValidatingType = typeof(int);
            // 
            // EightInOneOutControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "EightInOneOutControl";
            this.Size = new System.Drawing.Size(695, 409);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.Panel3.ResumeLayout(false);
            this.Panel3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        //private System.Windows.Forms.RichTextBox txtOpgave;
        internal System.Windows.Forms.Panel Panel3;
        internal System.Windows.Forms.Label Label2;
        //internal System.Windows.Forms.Button btnManual;
        //internal System.Windows.Forms.Button btnAuto;
        internal System.Windows.Forms.TextBox txtOutput;
        internal System.Windows.Forms.Label Label3;
        internal System.Windows.Forms.MaskedTextBox txtInput1;
        internal System.Windows.Forms.MaskedTextBox txtInput3;
        internal System.Windows.Forms.MaskedTextBox txtInput2;
        internal System.Windows.Forms.MaskedTextBox txtInput8;
        internal System.Windows.Forms.MaskedTextBox txtInput7;
        internal System.Windows.Forms.MaskedTextBox txtInput6;
        internal System.Windows.Forms.MaskedTextBox txtInput5;
        internal System.Windows.Forms.MaskedTextBox txtInput4;
    }
}
