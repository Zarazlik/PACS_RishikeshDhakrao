using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PACS_RishikeshDhakrao.UI
{
    public class ComboBoxWithTrackBar : UserControl
    {
        private ComboBox comboBox;
        private Button button1;
        private TextBox textBox1;
        private TrackBar trackBar;

        private void InitializeComponent()
        {
            button1 = new Button();
            textBox1 = new TextBox();
            SuspendLayout();
            // 
            // button1
            // 
            button1.Dock = DockStyle.Right;
            button1.Location = new Point(76, 0);
            button1.Name = "button1";
            button1.Size = new Size(24, 23);
            button1.TabIndex = 0;
            button1.Text = "▼";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // textBox1
            // 
            textBox1.Dock = DockStyle.Left;
            textBox1.Location = new Point(0, 0);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(75, 23);
            textBox1.TabIndex = 1;
            // 
            // ComboBoxWithTrackBar
            // 
            Controls.Add(textBox1);
            Controls.Add(button1);
            Name = "ComboBoxWithTrackBar";
            Size = new Size(100, 23);
            ResumeLayout(false);
            PerformLayout();
        }

        public ComboBoxWithTrackBar()
        {

        }

        public int SelectedValue
        {
            get { return trackBar.Value; }
            set { trackBar.Value = value; comboBox.Text = value.ToString(); }
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
    }
}
