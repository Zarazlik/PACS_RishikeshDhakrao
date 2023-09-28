using FellowOakDicom;
using FellowOakDicom.Imaging;

namespace PACS_RishikeshDhakrao.BackEnd
{
    public static class DicomRequester
    {
        public static DicomFile LocalFile(string path)
        {
            return DicomFile.Open(path);
        }

        public static Bitmap OpenImage(DicomFile dicomFile)
        {
            DicomImage dicomImage = new DicomImage(dicomFile.Dataset);

            IImage image = dicomImage.RenderImage();

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
    }
}
