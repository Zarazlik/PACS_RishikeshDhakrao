using FellowOakDicom;

namespace PACS_RishikeshDhakrao
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            //Rebuild fo-dicom library 
            new DicomSetupBuilder()
            .RegisterServices(s => s.AddFellowOakDicom()
            .AddTranscoderManager<FellowOakDicom.Imaging.NativeCodec.NativeTranscoderManager>())
            .SkipValidation()
            .Build();

            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            Application.Run(new PACS_RishikeshDhakrao.UI.Form1());
        }
    }
}