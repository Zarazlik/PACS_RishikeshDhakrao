using PACS_RishikeshDhakrao.BackEnd.DicomProcessing;

namespace PACS_RishikeshDhakrao.UI
{
    public partial class MainWindow : Form
    {
        List<FellowOakDicom.DicomFile> dicomFiles = new List<FellowOakDicom.DicomFile>();
        ImageViewer viewer;
        PrintingWindow printingWindow = new PrintingWindow();

        public MainWindow()
        {
            InitializeComponent();

            dataGridView1.CellDoubleClick += DataGridView1_CellDoubleClick;
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
            row.Cells[0].Value = DicomRequester.GetPatientName(dicomFiles[dataGridView1.RowCount]);
            row.Cells[1].Value = DicomRequester.GetPatientAge(dicomFiles[dataGridView1.RowCount]);
            row.Cells[2].Value = DicomRequester.GetPatientSex(dicomFiles[dataGridView1.RowCount]);
            row.Cells[3].Value = DicomRequester.GetStudyDate(dicomFiles[dataGridView1.RowCount]);
            row.Cells[4].Value = DicomRequester.GetStudyDescription(dicomFiles[dataGridView1.RowCount]);
            row.Cells[5].Value = DicomRequester.GetImagesCount(dicomFiles[dataGridView1.RowCount]);
            row.Cells[6].Value = DicomRequester.GetModality(dicomFiles[dataGridView1.RowCount]);
            row.Cells[7].Value = DicomRequester.GetAccessionNumber(dicomFiles[dataGridView1.RowCount]);
            row.Cells[8].Value = DicomRequester.GetReferringPhysicianName(dicomFiles[dataGridView1.RowCount]);

            dataGridView1.Rows.Add(row);
        }

        private void DataGridView1_CellDoubleClick(object? sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                if (viewer != null)
                {
                    viewer.Dispose();
                }
                viewer = new ImageViewer(dicomFiles[e.RowIndex], Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[5].Value));
                viewer.Show();
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            printingWindow.Show();
        }
    }
}
