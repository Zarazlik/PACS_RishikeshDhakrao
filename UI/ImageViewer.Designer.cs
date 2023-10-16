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
            comboBox1 = new ComboBox();
            backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            myTrackBar1 = new RMDdev.MyTrackBar();
            panel_ToolBox = new Panel();
            label1 = new Label();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBoxMain).BeginInit();
            panel_ToolBox.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            panel1.AutoScroll = true;
            panel1.BackColor = SystemColors.ControlDarkDark;
            panel1.Controls.Add(pictureBoxMain);
            panel1.Location = new Point(12, 52);
            panel1.Name = "panel1";
            panel1.Size = new Size(776, 424);
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
            // comboBox1
            // 
            comboBox1.FormattingEnabled = true;
            comboBox1.Items.AddRange(new object[] { "25", "50", "75", "100", "150", "200", "250", "300", "300", "400", "500" });
            comboBox1.Location = new Point(57, 11);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(44, 23);
            comboBox1.TabIndex = 0;
            comboBox1.Text = "100";
            comboBox1.SelectedIndexChanged += comboBox1_SelectedIndexChanged;
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
            // panel_ToolBox
            // 
            panel_ToolBox.Controls.Add(label1);
            panel_ToolBox.Controls.Add(comboBox1);
            panel_ToolBox.Dock = DockStyle.Top;
            panel_ToolBox.Location = new Point(0, 0);
            panel_ToolBox.Name = "panel_ToolBox";
            panel_ToolBox.Size = new Size(800, 46);
            panel_ToolBox.TabIndex = 2;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 14);
            label1.Name = "label1";
            label1.Size = new Size(39, 15);
            label1.TabIndex = 1;
            label1.Text = "Zoom";
            // 
            // ImageViewer
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 535);
            Controls.Add(panel_ToolBox);
            Controls.Add(myTrackBar1);
            Controls.Add(panel1);
            KeyPreview = true;
            Name = "ImageViewer";
            Text = "ImageViwer";
            Load += ImageViewer_Load;
            KeyUp += ImageViewer_KeyUp;
            panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBoxMain).EndInit();
            panel_ToolBox.ResumeLayout(false);
            panel_ToolBox.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private PictureBox pictureBoxMain;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private RMDdev.MyTrackBar myTrackBar1;
        private ComboBox comboBox1;
        private Panel panel_ToolBox;
        private Label label1;
    }
}