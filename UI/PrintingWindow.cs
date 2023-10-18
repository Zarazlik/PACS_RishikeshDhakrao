using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Printing;
using System.Drawing.Imaging;
using PACS_RishikeshDhakrao.BackEnd.ImageProcesing;
using FellowOakDicom;
using PACS_RishikeshDhakrao.BackEnd.DicomProcessing;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace PACS_RishikeshDhakrao.UI
{
    public partial class PrintingWindow : Form
    {
        DicomFile dicomFile;

        List<(ImageProcessor, ViewingPanel)> imageProcessors = new List<(ImageProcessor, ViewingPanel)>();
        int OpenedProcessor = 0;

        public PrintingWindow(DicomFile dicomFile)
        {
            this.dicomFile = dicomFile;

            InitializeComponent();
        }

        private void PrintingWindow_Load(object sender, EventArgs e)
        {
            panel1.MouseWheel += Panel1_MouseWheel;

            ChangeSpots();
        }



        void ChangeSpots()
        {
            foreach (var processors in imageProcessors)
            {
                Controls.Remove(processors.Item1);
                processors.Item1.Dispose();

                Controls.Remove(processors.Item2);
                processors.Item2.Dispose();
            }
            imageProcessors.Clear();

            if (numericUpDown1.Value == 1 || numericUpDown1.Value == 2)
            {
                DistributePictureBoxes((int)numericUpDown1.Value, 1);
            }
            else if (numericUpDown1.Value >= 3 && numericUpDown1.Value < 11)
            {
                DistributePictureBoxes((int)numericUpDown1.Value, 2);
            }
            else if (numericUpDown1.Value == 11 || numericUpDown1.Value == 12)
            {
                DistributePictureBoxes((int)numericUpDown1.Value, 3);
            }


            if (OpenedProcessor >= imageProcessors.Count)
            {
                OpenedProcessor = imageProcessors.Count - 1;
            }
            imageProcessors[OpenedProcessor].Item1.Visible = true;
            FillImageProcessors(OpenedProcessor);


            //---
            void DistributePictureBoxes(int numberOfPictureBoxes, int pictureBoxesPerRow)
            {
                panel_Paper.Controls.Clear();

                int marginBetweenPictureBoxes = 6;
                int marginFromEdges = 6;

                int availableWidth = panel_Paper.Width - (pictureBoxesPerRow + 1) * marginBetweenPictureBoxes;
                int pictureBoxWidth = availableWidth / pictureBoxesPerRow;

                int availableHeight = panel_Paper.Height - (numberOfPictureBoxes + 1) * marginBetweenPictureBoxes;
                int pictureBoxHeight = availableHeight / (int)Math.Ceiling((double)numberOfPictureBoxes / pictureBoxesPerRow);

                int currentX = marginFromEdges;
                int currentY = marginFromEdges;

                for (int i = 0; i < numberOfPictureBoxes; i++)
                {
                    ViewingPanel viewingPanel = new ViewingPanel();
                    AddImageProcessor(viewingPanel);

                    viewingPanel.Width = pictureBoxWidth;
                    viewingPanel.Height = pictureBoxHeight;
                    viewingPanel.Margin = new Padding(marginBetweenPictureBoxes);
                    viewingPanel.Location = new Point(currentX, currentY);

                    viewingPanel.AutoScroll = false;

                    panel_Paper.Controls.Add(viewingPanel);

                    currentX += pictureBoxWidth + marginBetweenPictureBoxes;

                    if (currentX + pictureBoxWidth + marginBetweenPictureBoxes > panel_Paper.Width)
                    {
                        currentX = marginFromEdges;
                        currentY += pictureBoxHeight + marginBetweenPictureBoxes;
                    }
                }
            }
        }

        void AddImageProcessor(ViewingPanel viewingPanel)
        {
            ImageProcessor imageProcessor = new ImageProcessor();
            this.Controls.Add(imageProcessor);
            imageProcessor.Location = new Point(110, 5);
            imageProcessor.Size = new Size(Width - 110, Height);
            imageProcessor.Visible = false;

            imageProcessors.Add((imageProcessor, viewingPanel));
            imageProcessors[imageProcessors.Count - 1].Item1.SetViewingPanel(viewingPanel);
            imageProcessor.AutoScrollMode = false;
        }

        void FillImageProcessors(int count)
        {
            for (int i = 0; i < numericUpDown1.Value; i++)
            {
                try
                {
                    imageProcessors[i].Item1.SetNewImage(DicomRequester.OpenImage(dicomFile, i + count));
                }
                catch
                {
                    imageProcessors[i].Item1.Enabled = false;
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            printDialog1.Document = new PrintDocument();
            printDialog1.Document.PrintPage += PrintImage;

            if (printDialog1.ShowDialog() == DialogResult.OK)
            {
                printDialog1.Document.Print();
            }
        }

        void PrintImage(object sender, PrintPageEventArgs e)
        {
            int PeperSizeX = 1050;
            int PeperSizeY = 1485;

            e.PageSettings.PaperSize = new PaperSize("210х297", PeperSizeX, PeperSizeY);

            Bitmap PrintingBitmap = new Bitmap(panel_Paper.Width, panel_Paper.Height);
            panel_Paper.DrawToBitmap(PrintingBitmap, new Rectangle(0, 0, PeperSizeX, PeperSizeY));
            e.Graphics.DrawImage(PrintingBitmap, new Rectangle(0, 0, (int)(PeperSizeX / 1.27f), (int)(PeperSizeY / 1.27f)));
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            ChangeSpots();
            numericUpDown2.Maximum = numericUpDown1.Value;
        }

        private void numericUpDown2_ValueChanged(object sender, EventArgs e)
        {
            imageProcessors[OpenedProcessor].Item1.Visible = false;
            OpenedProcessor = (int)(numericUpDown2.Value - 1);
            imageProcessors[OpenedProcessor].Item1.Visible = true;
        }

        private void panel1_SizeChanged(object sender, EventArgs e)
        {
            if (panel_Paper.Width > panel1.Width)
            {
                hScrollBar1.Visible = true;
                hScrollBar1.Maximum = (panel_Paper.Width - panel1.Width) / 10;

            }
            else
            {
                hScrollBar1.Value = 0;
                hScrollBar1.Visible = false;
            }

            if (panel_Paper.Height > panel1.Height)
            {
                vScrollBar1.Visible = true;
                vScrollBar1.Maximum = (panel_Paper.Height - panel1.Height) / 10;
            }
            else
            {
                vScrollBar1.Value = 0;
                vScrollBar1.Visible = false;
            }
        }

        private void vScrollBar1_Scroll(object sender, ScrollEventArgs e)
        {
            ChanegePaperLocation();
        }

        private void vScrollBar1_ValueChanged(object sender, EventArgs e)
        {
            ChanegePaperLocation();
        }

        private void hScrollBar1_Scroll(object sender, ScrollEventArgs e)
        {
            ChanegePaperLocation();
        }

        private void hScrollBar1_ValueChanged(object sender, EventArgs e)
        {
            ChanegePaperLocation();
        }

        void ChanegePaperLocation()
        {
            panel_Paper.Location = new Point(-hScrollBar1.Value * 10, -vScrollBar1.Value * 10);
        }

        private void Panel1_MouseWheel(object? sender, MouseEventArgs e)
        {
            if ((ModifierKeys & Keys.Control) != Keys.Control)
            {
                if (e.Delta > 0)
                {
                    if (vScrollBar1.Value - 3 < vScrollBar1.Minimum)
                    {
                        vScrollBar1.Value = vScrollBar1.Minimum;
                    }
                    else
                    {
                        vScrollBar1.Value -= 3;
                    }
                }
                else
                {
                    if (vScrollBar1.Value + 3 > vScrollBar1.Maximum)
                    {
                        vScrollBar1.Value = vScrollBar1.Maximum;
                    }
                    else
                    {
                        vScrollBar1.Value += 3;
                    }
                }
            }
        }

    }
}
