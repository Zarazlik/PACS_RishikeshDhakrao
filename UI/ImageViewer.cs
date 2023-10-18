using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Contracts;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using FellowOakDicom;
using PACS_RishikeshDhakrao.BackEnd.DicomProcessing;
using PACS_RishikeshDhakrao.BackEnd.ImageProcesing;

namespace PACS_RishikeshDhakrao.UI
{
    public partial class ImageViewer : Form
    {
        DicomFile dicomFile;
        int ImageCount;

        Bitmap originalBitmap;

        public ImageViewer(DicomFile dicomFile, int imageCount)
        {
            this.dicomFile = dicomFile;
            this.ImageCount = imageCount;

            InitializeComponent();
        }

        private void ImageViewer_Load(object sender, EventArgs e)
        {
            imageProcessor1.SetViewingPanel(viewingPanel1);

            myTrackBar1.Max = ImageCount;
            myTrackBar1.Text2 = "/ " + ImageCount.ToString();
            myTrackBar1.Value = 1;

            myTrackBar1.ValueСhanged += MyTrackBar1_ValueСhanged;

            LoadImage(0);
        }

        private void MyTrackBar1_ValueСhanged(object? sender, EventArgs e)
        {
            LoadImage(myTrackBar1.Value - 1);
        }

        #region Image loading

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
            originalBitmap = DicomRequester.OpenImageAsync(dicomFile, (int)e.Argument, backgroundWorker1, e);
        }

        private void BackgroundWorker1_RunWorkerCompleted(object? sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Cancelled)
            {
                backgroundWorker1.RunWorkerAsync(myTrackBar1.Value - 1);
            }
            else
            {
                imageProcessor1.SetNewImage(originalBitmap);
            }
        }

        #endregion

        private void button1_Click(object sender, EventArgs e)
        {
            new PrintingWindow(dicomFile, ImageCount).Show();
        }
    }
}
