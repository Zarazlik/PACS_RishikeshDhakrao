using System.Collections.Generic;
using System.Drawing;

namespace PACS_RishikeshDhakrao.BackEnd
{
    internal class Controller
    {
        public List<DicomWithBitmaps> Dicoms =  new List<DicomWithBitmaps>();

        public void OpenLocalDicomFile(string filePath)
        {
            Dicoms.Add(new DicomWithBitmaps(FileExtractor.GetFromLocalFile(filePath)));
        }
    }
}
