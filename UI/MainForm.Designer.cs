namespace PACS_RishikeshDhakrao.UI
{
    partial class MainWindow
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            btn_OpenFile = new Button();
            dataGridView1 = new DataGridView();
            PatientName = new DataGridViewTextBoxColumn();
            Age = new DataGridViewTextBoxColumn();
            Sex = new DataGridViewTextBoxColumn();
            StudyDate = new DataGridViewTextBoxColumn();
            StudyDescription = new DataGridViewTextBoxColumn();
            Images = new DataGridViewTextBoxColumn();
            Modality = new DataGridViewTextBoxColumn();
            AccessionNumber = new DataGridViewTextBoxColumn();
            ReferingPhsyician = new DataGridViewTextBoxColumn();
            openFileDialog1 = new OpenFileDialog();
            button1 = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // btn_OpenFile
            // 
            btn_OpenFile.Location = new Point(13, 12);
            btn_OpenFile.Margin = new Padding(4, 3, 4, 3);
            btn_OpenFile.Name = "btn_OpenFile";
            btn_OpenFile.Size = new Size(117, 27);
            btn_OpenFile.TabIndex = 0;
            btn_OpenFile.Text = "Open DICOM file";
            btn_OpenFile.UseVisualStyleBackColor = true;
            btn_OpenFile.Click += button1_Click;
            // 
            // dataGridView1
            // 
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToDeleteRows = false;
            dataGridView1.AllowUserToOrderColumns = true;
            dataGridView1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Columns.AddRange(new DataGridViewColumn[] { PatientName, Age, Sex, StudyDate, StudyDescription, Images, Modality, AccessionNumber, ReferingPhsyician });
            dataGridView1.Location = new Point(12, 45);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.ReadOnly = true;
            dataGridView1.RowTemplate.Height = 25;
            dataGridView1.Size = new Size(821, 392);
            dataGridView1.TabIndex = 4;
            // 
            // PatientName
            // 
            PatientName.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            PatientName.HeaderText = "Patient Name";
            PatientName.Name = "PatientName";
            PatientName.ReadOnly = true;
            // 
            // Age
            // 
            Age.AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;
            Age.HeaderText = "Age";
            Age.Name = "Age";
            Age.ReadOnly = true;
            Age.Width = 53;
            // 
            // Sex
            // 
            Sex.AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;
            Sex.HeaderText = "Sex";
            Sex.Name = "Sex";
            Sex.ReadOnly = true;
            Sex.Width = 50;
            // 
            // StudyDate
            // 
            StudyDate.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            StudyDate.HeaderText = "Study Date";
            StudyDate.Name = "StudyDate";
            StudyDate.ReadOnly = true;
            // 
            // StudyDescription
            // 
            StudyDescription.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            StudyDescription.HeaderText = "Study Description";
            StudyDescription.Name = "StudyDescription";
            StudyDescription.ReadOnly = true;
            // 
            // Images
            // 
            Images.AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;
            Images.HeaderText = "Images";
            Images.Name = "Images";
            Images.ReadOnly = true;
            Images.Width = 70;
            // 
            // Modality
            // 
            Modality.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            Modality.HeaderText = "Modality";
            Modality.Name = "Modality";
            Modality.ReadOnly = true;
            // 
            // AccessionNumber
            // 
            AccessionNumber.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            AccessionNumber.HeaderText = "Accession Number";
            AccessionNumber.Name = "AccessionNumber";
            AccessionNumber.ReadOnly = true;
            // 
            // ReferingPhsyician
            // 
            ReferingPhsyician.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            ReferingPhsyician.HeaderText = "Refering Phsyician";
            ReferingPhsyician.Name = "ReferingPhsyician";
            ReferingPhsyician.ReadOnly = true;
            // 
            // openFileDialog1
            // 
            openFileDialog1.FileName = "openFileDialog1";
            openFileDialog1.Filter = "DICOM file (*.dcm)|*.dcm";
            openFileDialog1.FileOk += openFileDialog1_FileOk;
            // 
            // button1
            // 
            button1.Location = new Point(137, 16);
            button1.Name = "button1";
            button1.Size = new Size(75, 23);
            button1.TabIndex = 5;
            button1.Text = "button1";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click_1;
            // 
            // MainWindow
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoScroll = true;
            ClientSize = new Size(845, 449);
            Controls.Add(button1);
            Controls.Add(dataGridView1);
            Controls.Add(btn_OpenFile);
            Margin = new Padding(4, 3, 4, 3);
            Name = "MainWindow";
            Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Button btn_OpenFile;
        private DataGridView dataGridView1;
        private OpenFileDialog openFileDialog1;
        private DataGridViewTextBoxColumn PatientName;
        private DataGridViewTextBoxColumn Age;
        private DataGridViewTextBoxColumn Sex;
        private DataGridViewTextBoxColumn StudyDate;
        private DataGridViewTextBoxColumn StudyDescription;
        private DataGridViewTextBoxColumn Images;
        private DataGridViewTextBoxColumn Modality;
        private DataGridViewTextBoxColumn AccessionNumber;
        private DataGridViewTextBoxColumn ReferingPhsyician;
        private Button button1;
    }
}

