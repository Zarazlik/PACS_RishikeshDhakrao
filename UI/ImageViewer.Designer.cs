using System.Windows.Forms;

namespace PACS_RishikeshDhakrao.UI
{
    partial class ImageViewer
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            panel1 = new Panel();
            pictureBoxMain = new PictureBox();
            backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            myTrackBar1 = new RMDdev.MyTrackBar();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBoxMain).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            panel1.AutoScroll = true;
            panel1.BackColor = SystemColors.ControlDarkDark;
            panel1.Controls.Add(pictureBoxMain);
            panel1.Location = new Point(12, 12);
            panel1.Name = "panel1";
            panel1.Size = new Size(776, 464);
            panel1.TabIndex = 0;
            panel1.MouseDown += PictureBox_MouseDown;
            panel1.MouseMove += PictureBox_MouseMove;
            panel1.MouseUp += PictureBox_MouseUp;
            panel1.MouseWheel += Panel1_MouseWheel;
            // 
            // pictureBoxMain
            // 
            pictureBoxMain.Enabled = false;
            pictureBoxMain.Location = new Point(0, 0);
            pictureBoxMain.Name = "pictureBoxMain";
            pictureBoxMain.Size = new Size(350, 259);
            pictureBoxMain.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBoxMain.TabIndex = 0;
            pictureBoxMain.TabStop = false;
            // 
            // backgroundWorker1
            // 
            backgroundWorker1.WorkerSupportsCancellation = true;
            backgroundWorker1.DoWork += backgroundWorker1_DoWork;
            backgroundWorker1.RunWorkerCompleted += BackgroundWorker1_RunWorkerCompleted;
            // 
            // myTrackBar1
            // 
            myTrackBar1.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            myTrackBar1.BackColor = SystemColors.Control;
            myTrackBar1.Font = new Font("Bahnschrift", 18F, FontStyle.Regular, GraphicsUnit.Pixel);
            myTrackBar1.Header = null;
            myTrackBar1.Location = new Point(12, 483);
            myTrackBar1.Margin = new Padding(4);
            myTrackBar1.Max = 10;
            myTrackBar1.Min = 1;
            myTrackBar1.Name = "myTrackBar1";
            myTrackBar1.Size = new Size(775, 39);
            myTrackBar1.TabIndex = 1;
            myTrackBar1.Text2 = "";
            myTrackBar1.Value = 1;
            // 
            // ImageViewer
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 535);
            Controls.Add(myTrackBar1);
            Controls.Add(panel1);
            Name = "ImageViewer";
            Text = "ImageViwer";
            Load += ImageViewer_Load;
            panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBoxMain).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private PictureBox pictureBoxMain;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private RMDdev.MyTrackBar myTrackBar1;
    }
}