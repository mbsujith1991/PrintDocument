using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace PrintDoc
{
    public interface IPrintDocumentService
    {
        void PrintPdfFile(Stream file);
    }
}
