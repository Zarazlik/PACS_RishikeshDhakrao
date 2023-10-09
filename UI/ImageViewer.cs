using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
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
        public List<Bitmap> bitmaps = new List<Bitmap>();

        public ImageViewer(DicomFile dicomFile)
        {
            this.dicomFile = dicomFile;

            InitializeComponent();


        }

        private void ImageViewer_Load(object sender, EventArgs e)
        {
            LoadImage();

        }


        void LoadImage()
        {
            backgroundWorker1.RunWorkerAsync();
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            bitmaps.Add(DicomRequester.OpenImage(dicomFile));
        }

        private void BackgroundWorker1_RunWorkerCompleted(object? sender, RunWorkerCompletedEventArgs e)
        {
            pictureBoxMain.Size = new Size(bitmaps[0].Width, bitmaps[0].Height);
            pictureBoxMain.Image = bitmaps[0];
        }
    }
}
