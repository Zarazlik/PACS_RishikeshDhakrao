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

namespace PACS_RishikeshDhakrao.UI
{
    public partial class PrintingWindow : Form
    {
        DicomFile dicomFile;

        List<(ImageProcessor, ViewingPanel)> imageProcessors =new List<(ImageProcessor, ViewingPanel)>();

        public PrintingWindow(DicomFile dicomFile)
        {
            this.dicomFile = dicomFile;

            InitializeComponent();
        }

        private void PrintingWindow_Load(object sender, EventArgs e)
        {
            ChangeSpots();
        }

        void ChangeSpots()
        {
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

            imageProcessors[0].Item1.Visible = true;
            FillImageProcessors(0);


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
            imageProcessor.Dock = DockStyle.Top;
            imageProcessor.Visible = false;

            imageProcessors.Add((imageProcessor, viewingPanel));
            imageProcessors[imageProcessors.Count - 1].Item1.SetViewingPanel(viewingPanel);
        }

        void FillImageProcessors(int count)
        {
            for (int i = 0;  i < numericUpDown1.Value; i++) 
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
        }
    }
}
