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

        double ZoomFactor
        {
            get { return _zoomFactor; }
            set
            {
                if (bitmap != null)
                {
                    if (value > 5f)
                    {
                        _zoomFactor = 5;
                    }
                    else if (value < 0.05f)
                    {
                        _zoomFactor = 0.05f;
                    }
                    else
                    {
                        _zoomFactor = value;
                    }

                    comboBox1.Text = Math.Round(_zoomFactor * 100).ToString();
                    ChangePictureBoxZoom();
                }
            }
        }
        double _zoomFactor = 1;

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
                Point autoscrollBufer = panel1.AutoScrollPosition;
                panel1.AutoScroll = false;

                if (e.Delta > 0)
                {
                    ZoomFactor = _zoomFactor + 0.05f;
                }
                else
                {
                    ZoomFactor = _zoomFactor - 0.05f;
                }

                panel1.AutoScroll = true;
                panel1.AutoScrollPosition = new Point(Math.Abs(autoscrollBufer.X), Math.Abs(autoscrollBufer.Y));
            }
        }

        void ChangePictureBoxZoom()
        {
            pictureBoxMain.Size = new Size((int)(bitmap.Width * _zoomFactor), (int)(bitmap.Height * _zoomFactor));
        }

        #endregion

        #endregion

        private void ImageViewer_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.ControlKey)
            {
                panel1.AutoScroll = true;
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            ZoomFactor =  Convert.ToDouble(comboBox1.SelectedItem) / 100;
        }
    }
}
