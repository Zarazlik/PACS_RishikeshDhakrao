using PACS_RishikeshDhakrao.BackEnd;

namespace PACS_RishikeshDhakrao.UI
{
    public partial class MainWindow : Form
    {
        List<FellowOakDicom.DicomFile> dicomFiles = new List<FellowOakDicom.DicomFile>();

        public MainWindow()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, System.EventArgs e)
        {
            openFileDialog1.ShowDialog();
        }

        private void openFileDialog1_FileOk(object sender, System.ComponentModel.CancelEventArgs e)
        {
            dicomFiles.Add(FileExtractor.GetFromLocalFile(openFileDialog1.FileName));

            DataGridViewRow row = new DataGridViewRow();
            row.CreateCells(dataGridView1);
            row.Cells[0].Value = DicomRequester.GetPatientName(dicomFiles[0]);
            row.Cells[1].Value = DicomRequester.GetPatientAge(dicomFiles[0]);
            row.Cells[2].Value = DicomRequester.GetPatientSex(dicomFiles[0]);
            row.Cells[3].Value = DicomRequester.GetStudyDate(dicomFiles[0]);
            row.Cells[4].Value = DicomRequester.GetStudyDescription(dicomFiles[0]);
            row.Cells[5].Value = DicomRequester.GetImagesCount(dicomFiles[0]);
            row.Cells[6].Value = DicomRequester.GetModality(dicomFiles[0]);
            row.Cells[7].Value = DicomRequester.GetAccessionNumber(dicomFiles[0]);
            row.Cells[8].Value = DicomRequester.GetReferringPhysicianName(dicomFiles[0]);

            dataGridView1.Rows.Add(row);
        }
    }
}
