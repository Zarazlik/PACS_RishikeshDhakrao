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
using static System.Net.Mime.MediaTypeNames;

namespace PACS_RishikeshDhakrao.UI
{
    public partial class PrintingWindow : Form
    {
        Bitmap bitmap;

        List<PictureBox> pictureBoxes;

        public PrintingWindow()
        {
            InitializeComponent();
        }

        private void PrintingWindow_Load(object sender, EventArgs e)
        {
            ChangeSpots();
        }

        void ChangeSpots()
        {
            if (comboBox1.Text == "1 Spot")
            {
                DistributePictureBoxes(1, 1);
            }
            else if (comboBox1.Text == "2 Spots")
            {
                DistributePictureBoxes(2, 2);
            }
            else if (comboBox1.Text == "4 Spots")
            {
                DistributePictureBoxes(4, 2);
            }

            void DistributePictureBoxes(int numberOfPictureBoxes, int pictureBoxesPerRow)
            {
                // Очистим panel_Paper от предыдущих контролов (если есть)
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
                    PictureBox pictureBox = new PictureBox();

                    pictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
                    pictureBox.Image = ColorFiltersResource.abstract_rectangle_background_free_vector;

                    pictureBox.Width = pictureBoxWidth;
                    pictureBox.Height = pictureBoxHeight; // Можно установить другую высоту, если нужно
                    pictureBox.Margin = new Padding(marginBetweenPictureBoxes);

                    pictureBox.Location = new Point(currentX, currentY);

                    panel_Paper.Controls.Add(pictureBox);

                    currentX += pictureBoxWidth + marginBetweenPictureBoxes;

                    if (currentX + pictureBoxWidth + marginBetweenPictureBoxes > panel_Paper.Width)
                    {
                        // Если следующий PictureBox не помещается в текущей строке, переход к следующей строке
                        currentX = marginFromEdges;
                        currentY += pictureBoxHeight  + marginBetweenPictureBoxes;
                    }
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
            bitmap = new Bitmap(panel_Paper.Width, panel_Paper.Height);
            panel_Paper.DrawToBitmap(bitmap, new Rectangle(0, 0, panel_Paper.Width, panel_Paper.Height));
            e.Graphics.DrawImage(bitmap, 0, 0);
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            ChangeSpots();
        }


    }
}
