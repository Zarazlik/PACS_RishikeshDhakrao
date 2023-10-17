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
            backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            myTrackBar1 = new RMDdev.MyTrackBar();
            viewingPanel1 = new BackEnd.ImageProcesing.ViewingPanel();
            imageProcessor1 = new BackEnd.ImageProcesing.ImageProcessor();
            SuspendLayout();
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
            myTrackBar1.Size = new Size(776, 39);
            myTrackBar1.TabIndex = 1;
            myTrackBar1.Text2 = "";
            myTrackBar1.Value = 1;
            // 
            // viewingPanel1
            // 
            viewingPanel1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            viewingPanel1.AutoScroll = true;
            viewingPanel1.BackColor = SystemColors.ControlDarkDark;
            viewingPanel1.Location = new Point(12, 47);
            viewingPanel1.Name = "viewingPanel1";
            viewingPanel1.Size = new Size(776, 429);
            viewingPanel1.TabIndex = 3;
            // 
            // imageProcessor1
            // 
            imageProcessor1.Dock = DockStyle.Top;
            imageProcessor1.Location = new Point(0, 0);
            imageProcessor1.Name = "imageProcessor1";
            imageProcessor1.Size = new Size(800, 41);
            imageProcessor1.TabIndex = 4;
            // 
            // ImageViewer
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 535);
            Controls.Add(imageProcessor1);
            Controls.Add(viewingPanel1);
            Controls.Add(myTrackBar1);
            KeyPreview = true;
            Name = "ImageViewer";
            Text = "ImageViewer";
            Load += ImageViewer_Load;
            ResumeLayout(false);
        }

        #endregion
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private RMDdev.MyTrackBar myTrackBar1;
        private BackEnd.ImageProcesing.ViewingPanel viewingPanel1;
        private BackEnd.ImageProcesing.ImageProcessor imageProcessor1;
    }
}