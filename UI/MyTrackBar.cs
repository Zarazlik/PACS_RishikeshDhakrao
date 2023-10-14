using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RMDdev
{
    public partial class MyTrackBar : UserControl
    {
        [Category("Data")]
        public string Header { get; set; }

        [Category("Data")]
        public string Text2
        {
            get { return label2.Text; }
            set { label2.Text = value; }
        }

        [Category("Data")]
        public int Value
        {
            get { return _value; }
            set
            {
                _value = value;
                maskedTextBox_Validate();
                ValueСhanged?.Invoke(this, EventArgs.Empty);
            }
        }

        [Category("Data")]
        public int Min
        {
            get { return _min; }
            set { _min = value; trackBar.Minimum = value; }
        }

        [Category("Data")]
        public int Max
        {
            get { return _max; }
            set { _max = value; trackBar.Maximum = value; }
        }

        public event EventHandler ValueСhanged;

        public MyTrackBar()
        {
            InitializeComponent();
        }

        int _value;
        int _min;
        int _max;

        bool trackbarChaneged;
        bool maskedTextBoxChaneged;

        private void This_Load(object sender, EventArgs e)
        {
            label2.Text = Text2;

            trackBar.Maximum = _max;
            trackBar.Minimum = _min;
            trackBar.Value = _value;

            label2.Location = new Point(maskedTextBox.Location.X + maskedTextBox.Size.Width, maskedTextBox.Location.Y);
        }

        #region Value chaneging
        private void maskedTextBox_Validate()
        {
            maskedTextBox.Text = maskedTextBox.Text.Replace(" ", "");

            if (maskedTextBox.Text == "")
            {
                ValueChang(_min, maskedTextBox);
            }
            else
            {
                int i = Convert.ToInt32(maskedTextBox.Text);

                if (i > _max)
                {
                    maskedTextBox.Text = _max.ToString();
                }
                else if (i < _min)
                {
                    maskedTextBox.Text = _min.ToString();
                }

                maskedTextBoxChaneged = true;

                ValueChang(Convert.ToInt32(maskedTextBox.Text), maskedTextBox);
            }

        }

        private void trackBar_ValueChanged(object sender, EventArgs e)
        {
            trackbarChaneged = true;
            ValueChang(trackBar.Value, trackBar);
        }

        void ValueChang(int NewValue, Control UsedControl)
        {
            ChangDataViewing(NewValue, UsedControl);

            if (trackbarChaneged && maskedTextBoxChaneged)
            {
                trackbarChaneged = false;
                maskedTextBoxChaneged = false;

                Value = NewValue;
            }
        }

        void ChangDataViewing(int NewValue, Control UsedControl)
        {
            if (UsedControl != maskedTextBox)
            {
                maskedTextBox.Text = NewValue.ToString();
            }

            if (UsedControl != trackBar)
            {
                trackBar.Value = NewValue;
            }
        }
        #endregion

        private void maskedTextBox_Leave(object sender, EventArgs e)
        {
            maskedTextBox_Validate();
        }

        private void maskedTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                maskedTextBox_Validate();
            }
        }

        public void SetValue(int value)
        {
            trackBar.Value = value;
            maskedTextBox.Text = value.ToString();
            Refresh();
        }
    }
}
