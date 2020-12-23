using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace PrintDoc
{
    public class MainPageViewModel
    {
        private readonly IPrintDocumentService _printService;
        public ICommand OnPrintPDFCommand { get; set; }

        public MainPageViewModel()
        {
            OnPrintPDFCommand = new Command(() => PrintPDF());
            _printService = DependencyService.Get<IPrintDocumentService>();
        }

        public async void PrintPDF()
        {
            try
            {
                var obj = this.GetType().Assembly.GetManifestResourceNames();
                Stream file = typeof(App).GetTypeInfo().Assembly.GetManifestResourceStream(obj[0]);
                _printService.PrintPdfFile(file);
            }
            catch(Exception ex)
            {
                await Application.Current.MainPage.DisplayAlert("Error", ex.Message, "Accept");
            }
        }
       
    }
}
