using System.Drawing;
using System.Windows.Forms;
using FellowOakDicom;
using PACS_RishikeshDhakrao.BackEnd;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace PACS_RishikeshDhakrao.UI
{
    public partial class Form1 : Form
    {
        Controller controller = new Controller();

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, System.EventArgs e)
        {
            if (textBox1.Text != "")
            {
                controller.OpenLocalDicomFile(textBox1.Text);
                pictureBox1.Image = controller.Dicoms[0].bitmaps[0];
            }
            else
            {
                textBox1.Text = "Specify the path to the DICOM file";
            }
        }
    }
}
