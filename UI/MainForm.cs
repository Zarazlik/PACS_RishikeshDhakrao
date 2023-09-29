using System.Drawing;
using System.Windows.Forms;
using FellowOakDicom;
using PACS_RishikeshDhakrao.BackEnd;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace PACS_RishikeshDhakrao.UI
{
    public partial class MainWindow : Form
    {
        Controller controller = new Controller();

        public MainWindow()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, System.EventArgs e)
        {
            openFileDialog1.ShowDialog();
        }

        private void openFileDialog1_FileOk(object sender, System.ComponentModel.CancelEventArgs e)
        {
            controller.OpenLocalDicomFile(openFileDialog1.FileName);
            pictureBox1.Size = new Size(controller.Dicoms[0].bitmaps[0].Width, controller.Dicoms[0].bitmaps[0].Height);
            pictureBox1.Image = controller.Dicoms[0].bitmaps[0];
        }
    }
}
