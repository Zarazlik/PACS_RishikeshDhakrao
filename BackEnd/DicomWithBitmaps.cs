﻿using FellowOakDicom;

namespace PACS_RishikeshDhakrao.BackEnd
{
    public struct DicomWithBitmaps
    {
        public DicomFile dicomFile;
        public List<Bitmap> bitmaps;

        public DicomWithBitmaps(DicomFile dicomFile)
        {
            this.dicomFile = dicomFile;
            bitmaps = new List<Bitmap>();

            OpenBitmapImage();
        }

        void OpenBitmapImage()
        {
            bitmaps.Add(DicomRequester.OpenImage(dicomFile));
        }
    }
}