using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace PrintDoc.DependencyServices
{
    public interface IPrintDocumentService
    {
        void PrintPdfFile(Stream file);
    }
}
