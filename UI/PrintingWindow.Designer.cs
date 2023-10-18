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
            comboBox1 = new ComboBox();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            panel1.AutoScroll = true;
            panel1.BackColor = SystemColors.ControlDarkDark;
            panel1.Controls.Add(panel_Paper);
            panel1.Location = new Point(12, 51);
            panel1.Name = "panel1";
            panel1.Size = new Size(640, 357);
            panel1.TabIndex = 0;
            // 
            // panel_Paper
            // 
            panel_Paper.BackColor = Color.White;
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
            panel2.Controls.Add(comboBox1);
            panel2.Controls.Add(button1);
            panel2.Location = new Point(658, 51);
            panel2.Name = "panel2";
            panel2.Size = new Size(126, 357);
            panel2.TabIndex = 2;
            // 
            // comboBox1
            // 
            comboBox1.AutoCompleteCustomSource.AddRange(new string[] { "1 Spot", "2 Spots", "4 Spots", "6 Spots", "8 Spots", "10 Spots", "12 Spots" });
            comboBox1.FormattingEnabled = true;
            comboBox1.Items.AddRange(new object[] { "1 Spot", "2 Spots", "4 Spots", "6 Spots", "8 Spots", "10 Spots", "12 Spots" });
            comboBox1.Location = new Point(3, 3);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(120, 23);
            comboBox1.TabIndex = 2;
            comboBox1.Text = "1 Spot";
            comboBox1.SelectedIndexChanged += comboBox1_SelectedIndexChanged;
            // 
            // PrintingWindow
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(796, 420);
            Controls.Add(panel2);
            Controls.Add(panel1);
            Name = "PrintingWindow";
            Text = "PrintingWindow";
            Load += PrintingWindow_Load;
            panel1.ResumeLayout(false);
            panel2.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Button button1;
        private PrintDialog printDialog1;
        private Panel panel2;
        private ComboBox comboBox1;
        private Panel panel_Paper;
    }
}