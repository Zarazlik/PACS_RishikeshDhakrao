using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using FellowOakDicom;
using PACS_RishikeshDhakrao.BackEnd;

namespace PACS_RishikeshDhakrao.UI
{
    public partial class ImageViewer : Form
    {
        DicomFile dicomFile;
        public Bitmap bitmap;
        int ImageCount;

        public ImageViewer(DicomFile dicomFile, int imageCount)
        {
            

            this.dicomFile = dicomFile;
            this.ImageCount = imageCount;

            InitializeComponent();
        }

        private void ImageViewer_Load(object sender, EventArgs e)
        {
            myTrackBar1.Max = ImageCount;
            myTrackBar1.Text2 = "/ " + ImageCount.ToString();
            myTrackBar1.Value = 1;

            myTrackBar1.ValueСhanged += MyTrackBar1_ValueСhanged;

            LoadImage(0);
        }

        private void MyTrackBar1_ValueСhanged(object? sender, EventArgs e)
        {
            LoadImage(myTrackBar1.Value);
        }

        void LoadImage(int NuberOfImage)
        {
            if (!backgroundWorker1.IsBusy)
            {
                backgroundWorker1.RunWorkerAsync(NuberOfImage);
            }
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            backgroundWorker1 = sender as BackgroundWorker;
            bitmap = DicomRequester.OpenImageAsync(dicomFile, (int)e.Argument, backgroundWorker1, e);
        }

        private void BackgroundWorker1_RunWorkerCompleted(object? sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Cancelled)
            {
                backgroundWorker1.RunWorkerAsync(myTrackBar1.Value - 1);
            }
            else
            {
                pictureBoxMain.Size = new Size(bitmap.Width, bitmap.Height);
                pictureBoxMain.Image = bitmap;
            }
        }
    }
}
