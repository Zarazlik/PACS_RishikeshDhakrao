using FellowOakDicom;
using FellowOakDicom.Imaging;
using System.ComponentModel;
using System.Security.AccessControl;

namespace PACS_RishikeshDhakrao.BackEnd
{
    public static class DicomRequester
    {
        public static DicomFile LocalFile(string path)
        {
            return DicomFile.Open(path);
        }

        public static Bitmap OpenImage(DicomFile dicomFile, int imageIndex)
        {
            DicomImage dicomImage = new DicomImage(dicomFile.Dataset);

            IImage image = dicomImage.RenderImage(imageIndex);

            Bitmap bitmap = new Bitmap(dicomImage.Width, dicomImage.Height);

            for (int x = 0; x < dicomImage.Width; x++)
            {
                for (int y = 0; y < dicomImage.Height; y++)
                {
                    bitmap.SetPixel(x, y, FellowOakColorToColor(image.GetPixel(x, y)));
                }
            }

            return bitmap;

            Color FellowOakColorToColor(Color32 color32)
            {
                return Color.FromArgb(color32.A, color32.R, color32.G, color32.B);
            }
        }

        public static Bitmap OpenImageAsync(DicomFile dicomFile, int imageIndex, BackgroundWorker backgroundWorker, DoWorkEventArgs e)
        {
            DicomImage dicomImage = new DicomImage(dicomFile.Dataset);

            IImage image = dicomImage.RenderImage(imageIndex);

            Bitmap bitmap = new Bitmap(dicomImage.Width, dicomImage.Height);

            for (int x = 0; x < dicomImage.Width; x++)
            {
                for (int y = 0; y < dicomImage.Height; y++)
                {
                    if (backgroundWorker.CancellationPending)
                    {
                        e.Cancel = true;
                    }
                    else
                    {
                        bitmap.SetPixel(x, y, FellowOakColorToColor(image.GetPixel(x, y)));
                    }
                }
            }

            return bitmap;

            Color FellowOakColorToColor(Color32 color32)
            {
                return Color.FromArgb(color32.A, color32.R, color32.G, color32.B);
            }
        }

        public static string GetPatientName(DicomFile dicomFile)
        {
            try 
            { 
                return dicomFile.Dataset.GetSingleValue<string>(DicomTag.PatientName);
            }
            catch
            {
                return "-";
            }
        }

        public static string GetPatientAge(DicomFile dicomFile)
        {
            try
            {
                return dicomFile.Dataset.GetSingleValue<string>(DicomTag.PatientBirthDate);
            }
            catch
            {
                return "-";
            }
        }

        public static string GetPatientSex(DicomFile dicomFile)
        {
            try
            {
                return dicomFile.Dataset.GetSingleValue<string>(DicomTag.PatientSex);
            }
            catch
            {
                return "-";
            }
        }

        public static string GetStudyDate(DicomFile dicomFile)
        {
            try
            {
                return dicomFile.Dataset.GetSingleValue<DateTime>(DicomTag.StudyDate).ToString("D");
            }
            catch
            {
                return "-";
            }
        }

        public static string GetStudyDescription(DicomFile dicomFile)
        {
            try
            {
                return dicomFile.Dataset.GetSingleValue<string>(DicomTag.StudyDescription);
            }
            catch
            {
                return "-";
            }
        }

        public static uint GetImagesCount(DicomFile dicomFile)
        { 
            try
            {
                return dicomFile.Dataset.GetSingleValue<uint>(DicomTag.NumberOfFrames);
            }
            catch
            {
                return 1;
            }
        }

        public static string GetModality(DicomFile dicomFile)
        {
            try
            {
                return dicomFile.Dataset.GetSingleValue<string>(DicomTag.Modality);
            }
            catch
            {
                return "-";
            }
        }

        public static string GetAccessionNumber(DicomFile dicomFile)
        {
            try
            {
                return dicomFile.Dataset.GetSingleValue<string>(DicomTag.AccessionNumber);
            }
            catch
            {
                return "-";
            }
        }

        public static string GetReferringPhysicianName(DicomFile dicomFile)
        {
            try
            {
                return dicomFile.Dataset.GetSingleValue<string>(DicomTag.ReferringPhysicianName);  // new DicomTag(0x0008, 0x0090));
            }
            catch
            {
                return "-";
            }
        }

    }
}
