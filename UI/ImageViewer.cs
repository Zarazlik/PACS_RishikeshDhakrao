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
        public List<Bitmap> bitmaps;


        public ImageViewer(DicomFile dicomFile)
        {
            this.dicomFile = dicomFile;

            InitializeComponent();
        }

        private void ImageViewer_Load(object sender, EventArgs e)
        {
            bitmaps.Add(DicomRequester.OpenImage(dicomFile));
            pictureBoxMain.Size = new Size(bitmaps[0].Width, bitmaps[0].Height);
            pictureBoxMain.Image = bitmaps[0];
        }
    }
}
