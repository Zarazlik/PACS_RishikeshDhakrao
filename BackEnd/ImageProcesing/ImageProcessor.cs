using FellowOakDicom;
using PACS_RishikeshDhakrao.UI;
using RMDdev;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace PACS_RishikeshDhakrao.BackEnd.ImageProcesing
{
    public partial class ImageProcessor : UserControl
    {
        ViewingPanel viewingPanel;
        PictureBox pictureBox;

        Bitmap originalBitmap;
        public Bitmap bitmap;

        ImageAttributes imageAttributes = new ImageAttributes();

        float Contrast
        {
            get
            {
                return _contrast;
            }
            set
            {
                _contrast = value;
                SetContrastMatrix();
                DrawImage();
            }
        }
        float _contrast = 1;
        float brightness = 0f;

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

        private Point initialAutoScrollPosition;
        private Size initialImageSize;

        private Point StartMousePosition;
        private bool MouseIsDownLeft;

        public event EventHandler LoadingCanseled;

        public bool AutoScrollMode
        {
            get { return _autoScrollMode; }
            set
            {
                _autoScrollMode = value;
                viewingPanel.AutoScroll = value;
            }
        }
        bool _autoScrollMode;

        public ImageProcessor()
        {
            InitializeComponent();
        }

        public void SetViewingPanel(ViewingPanel viewingPanel)
        {
            this.viewingPanel = viewingPanel;
            pictureBox = viewingPanel.pictureBox;
            this.originalBitmap = originalBitmap;

            viewingPanel.MouseDown += PictureBox_MouseDown;
            viewingPanel.MouseMove += PictureBox_MouseMove;
            viewingPanel.MouseUp += PictureBox_MouseUp;
            viewingPanel.MouseWheel += viewingPanel_MouseWheel;
        }

        public void SetNewImage(Bitmap newBitmap)
        {
            originalBitmap = newBitmap;
            bitmap = originalBitmap;
            initialImageSize = new Size((int)(bitmap.Width * _zoomFactor), (int)(bitmap.Height * _zoomFactor));
            pictureBox.Size = initialImageSize;
            DrawImage();
        }

        public void DrawImage()
        {
            Bitmap newImage = new Bitmap(originalBitmap);

            if (comboBox2.Text == "Metal hot blue")
            {
                newImage = ApplyColorFilter(newImage, ColorFiltersResource.Gradient_MetalHotBlue);
            }
            else if (comboBox2.Text == "Hot iron")
            {
                newImage = ApplyColorFilter(newImage, ColorFiltersResource.Gradient_HotIron);
            }

            using (Graphics g = Graphics.FromImage(newImage))
            {
                g.DrawImage(newImage, new Rectangle(0, 0, newImage.Width, newImage.Height),
                    0, 0, newImage.Width, newImage.Height, GraphicsUnit.Pixel, imageAttributes);
            }

            pictureBox.Image = newImage;
        }



        #region Tools

        #region Moving image with mouse
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
            if (viewingPanel.Capture)
            {
                if (MouseIsDownLeft)
                {
                    if (e.Location != StartMousePosition)
                    {
                        if (_autoScrollMode)
                        {
                            viewingPanel.AutoScrollPosition = new Point(Math.Abs(viewingPanel.AutoScrollPosition.X + (e.Location.X - StartMousePosition.X)), Math.Abs(viewingPanel.AutoScrollPosition.Y + (e.Location.Y - StartMousePosition.Y)));
                            StartMousePosition = e.Location;
                        }
                        else 
                        {
                            viewingPanel.pictureBox.Location = new Point(pictureBox.Location.X + (e.Location.X - StartMousePosition.X), pictureBox.Location.Y + (e.Location.Y - StartMousePosition.Y));
                            StartMousePosition = e.Location;
                        }
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

        private void viewingPanel_MouseWheel(object sender, MouseEventArgs e)
        {
            if ((ModifierKeys & Keys.Control) == Keys.Control)
            {
                Point autoscrollBufer = viewingPanel.AutoScrollPosition;
                viewingPanel.AutoScroll = false;

                if (e.Delta > 0)
                {
                    ZoomFactor = _zoomFactor + 0.05f;
                }
                else
                {
                    ZoomFactor = _zoomFactor - 0.05f;
                }

                if (_autoScrollMode)
                {
                    viewingPanel.AutoScroll = true;
                    viewingPanel.AutoScrollPosition = new Point(Math.Abs(autoscrollBufer.X), Math.Abs(autoscrollBufer.Y));
                }
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            ZoomFactor = Convert.ToDouble(comboBox1.SelectedItem) / 100;
        }

        void ChangePictureBoxZoom()
        {
            initialImageSize = new Size((int)(bitmap.Width * _zoomFactor), (int)(bitmap.Height * _zoomFactor));
            pictureBox.Size = initialImageSize;
        }
        #endregion

        #region Contrast

        void SetContrastMatrix()
        {
            imageAttributes.SetColorMatrix
               (
                    new ColorMatrix
                       (
                       new float[][]
                       {
                            new float[] {_contrast, 0, 0, 0, 0},
                            new float[] {0, _contrast, 0, 0, 0},
                            new float[] {0, 0, _contrast, 0, 0},
                            new float[] {0, 0, 0, 1, 0},
                            new float[] {brightness, brightness, brightness, 0, 1}
                       }
                    )
                );
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            brightness = -((float)(trackBar1.Value - 100) / 100);
            Contrast = (float)(trackBar1.Value) / 100;
        }

        #endregion

        #region Color filter
        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            DrawImage();
        }

        Bitmap ApplyColorFilter(Bitmap originalImage, Bitmap filter)
        {
            for (int x = 0; x < originalImage.Width; x++)
            {
                for (int y = 0; y < originalImage.Height; y++)
                {
                    byte filteredBrightness = bitmap.GetPixel(x, y).R;

                    originalImage.SetPixel(x, y, filter.GetPixel(filteredBrightness, 0));
                }
            }
            return originalImage;
        }

        #endregion

        #endregion
    }
}
