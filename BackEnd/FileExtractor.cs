using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using FellowOakDicom;

namespace PACS_RishikeshDhakrao.BackEnd
{
    public static class FileExtractor
    {
        public static DicomFile GetFromLocalFile(string path)
        {
            return DicomFile.Open(path);
        }
            
    }
}
