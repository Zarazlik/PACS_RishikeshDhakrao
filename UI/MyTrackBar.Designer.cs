namespace RMDdev
{
    partial class MyTrackBar
    {
        /// <summary> 
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором компонентов

        /// <summary> 
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            maskedTextBox = new MaskedTextBox();
            trackBar = new TrackBar();
            label2 = new Label();
            ((System.ComponentModel.ISupportInitialize)trackBar).BeginInit();
            SuspendLayout();
            // 
            // maskedTextBox
            // 
            maskedTextBox.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            maskedTextBox.BackColor = SystemColors.Control;
            maskedTextBox.BorderStyle = BorderStyle.None;
            maskedTextBox.Culture = new System.Globalization.CultureInfo("");
            maskedTextBox.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            maskedTextBox.ForeColor = SystemColors.ControlText;
            maskedTextBox.Location = new Point(313, 13);
            maskedTextBox.Margin = new Padding(4);
            maskedTextBox.Mask = "00000";
            maskedTextBox.Name = "maskedTextBox";
            maskedTextBox.RightToLeft = RightToLeft.Yes;
            maskedTextBox.Size = new Size(59, 22);
            maskedTextBox.TabIndex = 42;
            maskedTextBox.Text = "1";
            maskedTextBox.ValidatingType = typeof(int);
            maskedTextBox.KeyDown += maskedTextBox_KeyDown;
            maskedTextBox.Leave += maskedTextBox_Leave;
            // 
            // trackBar
            // 
            trackBar.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            trackBar.Cursor = Cursors.Hand;
            trackBar.LargeChange = 1;
            trackBar.Location = new Point(4, 4);
            trackBar.Margin = new Padding(4);
            trackBar.Maximum = 255;
            trackBar.Name = "trackBar";
            trackBar.Size = new Size(307, 45);
            trackBar.TabIndex = 40;
            trackBar.ValueChanged += trackBar_ValueChanged;
            // 
            // label2
            // 
            label2.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            label2.AutoSize = true;
            label2.BackColor = SystemColors.Control;
            label2.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label2.ForeColor = SystemColors.ControlText;
            label2.Location = new Point(380, 14);
            label2.Margin = new Padding(4, 0, 4, 0);
            label2.Name = "label2";
            label2.Size = new Size(54, 21);
            label2.TabIndex = 41;
            label2.Text = "#Text2";
            // 
            // MyTrackBar
            // 
            AutoScaleDimensions = new SizeF(10F, 22F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.Control;
            Controls.Add(maskedTextBox);
            Controls.Add(label2);
            Controls.Add(trackBar);
            Font = new Font("Bahnschrift", 18F, FontStyle.Regular, GraphicsUnit.Pixel);
            Margin = new Padding(4);
            Name = "MyTrackBar";
            Size = new Size(447, 55);
            Load += This_Load;
            ((System.ComponentModel.ISupportInitialize)trackBar).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MaskedTextBox maskedTextBox;
        public TrackBar trackBar;
        private Label label2;
    }
}
