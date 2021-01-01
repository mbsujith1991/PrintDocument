using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

using Foundation;
using PrintDoc.DependencyServices;
using PrintDoc.iOS.DependencyServices;
using UIKit;
using Xamarin.Forms;

[assembly:Dependency(typeof(PrintDocumentService))]
namespace PrintDoc.iOS.DependencyServices
{
    public class PrintDocumentService : IPrintDocumentService
    {
        public void PrintPdfFile(Stream file)
        {
            var printInfo = UIPrintInfo.PrintInfo;
            printInfo.OutputType = UIPrintInfoOutputType.General;
            printInfo.JobName = "Print PDF";

            //Get the path of the MyDocuments folder
            var documents = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            //Get the path of the Library folder within the MyDocuments folder
            var library = Path.Combine(documents, "..", "Library");
            //Create a new file with the input file name in the Library folder
            var filepath = Path.Combine(library, "PrintSampleFile");

            //Write the contents of the input file to the newly created file
            using (MemoryStream tempStream = new MemoryStream())
            {
                file.Position = 0;
                file.CopyTo(tempStream);
                File.WriteAllBytes(filepath, tempStream.ToArray());
            }

            var printer = UIPrintInteractionController.SharedPrintController;
            printInfo.OutputType = UIPrintInfoOutputType.General;

            printer.PrintingItem = NSUrl.FromFilename(filepath);
            printer.PrintInfo = printInfo;


            printer.ShowsPageRange = true;

            printer.Present(true, (handler, completed, err) => {
                if (!completed && err != null)
                {
                    Console.WriteLine("error");
                }
            });
            file.Dispose();
        }
    }
}