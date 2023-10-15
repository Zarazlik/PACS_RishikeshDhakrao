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

        float zoomFactor = 1.0f;

        private Point StartMousePosition;
        private Point initialAutoScrollPosition;
        private bool MouseIsDownLeft;

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

        #endregion

        #region Tools

        #region Moving around the image with the mouse
        private void PictureBox_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                StartMousePosition = e.Location;
                MouseIsDownLeft = true;
            }
        }

        private void PictureBox_MouseMove(object sender, MouseEventArgs e)
        {
            if (panel1.Capture)
            {
                if (MouseIsDownLeft)
                {
                    if (e.Location != StartMousePosition)
                    {
                        panel1.AutoScrollPosition = new Point(Math.Abs(panel1.AutoScrollPosition.X + (e.Location.X - StartMousePosition.X)), Math.Abs(panel1.AutoScrollPosition.Y + (e.Location.Y - StartMousePosition.Y)));
                        StartMousePosition = e.Location;
                    }
                }
            }
        }

        private void PictureBox_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                MouseIsDownLeft = false;
            }
        }
        #endregion

        #region Zoom

        private void Panel1_MouseWheel(object sender, MouseEventArgs e)
        {
            if ((ModifierKeys & Keys.Control) == Keys.Control)
            {
                if (e.Delta > 0)
                {
                    zoomFactor += 0.05f;
                    ChangePictureBoxZoom();
                }
                else
                {
                    zoomFactor -= 0.05f;
                    ChangePictureBoxZoom();
                }

                return;
            }

            void ChangePictureBoxZoom()
            {
                pictureBoxMain.Size = new Size((int)(bitmap.Width * zoomFactor), (int)(bitmap.Height * zoomFactor));

                /*
                // Вычисляем положение для прокрутки
                int scrollX = (int)((e.X - pictureBoxMain.Location.X) * 0.05f);
                int scrollY = (int)((e.Y - pictureBoxMain.Location.Y) * 0.05f);

                // Прокручиваем Panel, чтобы изображение было видно
                panel1.AutoScrollPosition = new Point(scrollX, scrollY);
                */
            }

        }

        #endregion

        #endregion
    }
}
