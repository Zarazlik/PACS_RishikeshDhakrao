namespace PACS_RishikeshDhakrao.UI
{
    partial class PrintingWindow
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
            panel1 = new Panel();
            panel_Paper = new Panel();
            button1 = new Button();
            printDialog1 = new PrintDialog();
            panel2 = new Panel();
            label1 = new Label();
            numericUpDown1 = new NumericUpDown();
            numericUpDown2 = new NumericUpDown();
            label2 = new Label();
            vScrollBar1 = new VScrollBar();
            hScrollBar1 = new HScrollBar();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numericUpDown1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown2).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            panel1.BackColor = SystemColors.ControlDark;
            panel1.BorderStyle = BorderStyle.Fixed3D;
            panel1.Controls.Add(panel_Paper);
            panel1.Location = new Point(12, 51);
            panel1.Name = "panel1";
            panel1.Size = new Size(623, 340);
            panel1.TabIndex = 0;
            panel1.SizeChanged += panel1_SizeChanged;
            // 
            // panel_Paper
            // 
            panel_Paper.BackColor = Color.White;
            panel_Paper.CausesValidation = false;
            panel_Paper.Location = new Point(3, 3);
            panel_Paper.Name = "panel_Paper";
            panel_Paper.Size = new Size(1050, 1485);
            panel_Paper.TabIndex = 0;
            // 
            // button1
            // 
            button1.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            button1.Location = new Point(3, 331);
            button1.Name = "button1";
            button1.Size = new Size(120, 23);
            button1.TabIndex = 1;
            button1.Text = "Print";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // printDialog1
            // 
            printDialog1.UseEXDialog = true;
            // 
            // panel2
            // 
            panel2.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right;
            panel2.Controls.Add(label1);
            panel2.Controls.Add(numericUpDown1);
            panel2.Controls.Add(button1);
            panel2.Location = new Point(658, 51);
            panel2.Name = "panel2";
            panel2.Size = new Size(126, 357);
            panel2.TabIndex = 2;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(3, 3);
            label1.Name = "label1";
            label1.Size = new Size(74, 15);
            label1.TabIndex = 3;
            label1.Text = "Image count";
            // 
            // numericUpDown1
            // 
            numericUpDown1.Location = new Point(3, 21);
            numericUpDown1.Maximum = new decimal(new int[] { 12, 0, 0, 0 });
            numericUpDown1.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            numericUpDown1.Name = "numericUpDown1";
            numericUpDown1.Size = new Size(120, 23);
            numericUpDown1.TabIndex = 2;
            numericUpDown1.Value = new decimal(new int[] { 1, 0, 0, 0 });
            numericUpDown1.ValueChanged += numericUpDown1_ValueChanged;
            // 
            // numericUpDown2
            // 
            numericUpDown2.Location = new Point(52, 15);
            numericUpDown2.Maximum = new decimal(new int[] { 1, 0, 0, 0 });
            numericUpDown2.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            numericUpDown2.Name = "numericUpDown2";
            numericUpDown2.Size = new Size(39, 23);
            numericUpDown2.TabIndex = 3;
            numericUpDown2.Value = new decimal(new int[] { 1, 0, 0, 0 });
            numericUpDown2.ValueChanged += numericUpDown2_ValueChanged;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(15, 17);
            label2.Name = "label2";
            label2.Size = new Size(31, 15);
            label2.TabIndex = 4;
            label2.Text = "Spot";
            // 
            // vScrollBar1
            // 
            vScrollBar1.AllowDrop = true;
            vScrollBar1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right;
            vScrollBar1.Location = new Point(638, 54);
            vScrollBar1.Name = "vScrollBar1";
            vScrollBar1.Size = new Size(17, 337);
            vScrollBar1.TabIndex = 5;
            vScrollBar1.Scroll += vScrollBar1_Scroll;
            vScrollBar1.ValueChanged += vScrollBar1_ValueChanged;
            // 
            // hScrollBar1
            // 
            hScrollBar1.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            hScrollBar1.Location = new Point(12, 394);
            hScrollBar1.Name = "hScrollBar1";
            hScrollBar1.Size = new Size(623, 17);
            hScrollBar1.TabIndex = 6;
            hScrollBar1.Scroll += hScrollBar1_Scroll;
            hScrollBar1.ValueChanged += hScrollBar1_ValueChanged;
            // 
            // PrintingWindow
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(796, 420);
            Controls.Add(hScrollBar1);
            Controls.Add(vScrollBar1);
            Controls.Add(label2);
            Controls.Add(numericUpDown2);
            Controls.Add(panel2);
            Controls.Add(panel1);
            Name = "PrintingWindow";
            Text = "PrintingWindow";
            Load += PrintingWindow_Load;
            panel1.ResumeLayout(false);
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numericUpDown1).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown2).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel panel1;
        private Button button1;
        private PrintDialog printDialog1;
        private Panel panel2;
        private Panel panel_Paper;
        private NumericUpDown numericUpDown1;
        private Label label1;
        private NumericUpDown numericUpDown2;
        private Label label2;
        private VScrollBar vScrollBar1;
        private HScrollBar hScrollBar1;
    }
}