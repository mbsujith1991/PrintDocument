using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Print;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Plugin.CurrentActivity;
using PrintDoc.Droid;
using Xamarin.Forms;

[assembly: Dependency(typeof(PrintDocumentService))]
namespace PrintDoc.Droid
{
    public class PrintDocumentService : IPrintDocumentService
    {
        public void PrintPdfFile(Stream file)
        {
            try
            {
                if (file.CanSeek)
                    //Reset the position of PDF document stream to be printed
                    file.Position = 0;
                //Create a new file in the Personal folder with the given name
                string createdFilePath = System.IO.Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "PrintSampleFile");
                //Save the stream to the created file
                using (var dest = System.IO.File.OpenWrite(createdFilePath))
                    file.CopyTo(dest);
                string filePath = createdFilePath;
                PrintManager printManager = (PrintManager)CrossCurrentActivity.Current.Activity.GetSystemService(Context.PrintService);
                PrintDocumentAdapter pda = new CustomPrintDocumentAdapter(filePath);
                //Print with null PrintAttributes
                printManager.Print("PrintSampleFile Job", pda, null);
                file.Dispose();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}