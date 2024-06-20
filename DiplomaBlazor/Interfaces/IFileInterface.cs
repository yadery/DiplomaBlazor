using DiplomaBlazor.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiplomaBlazor.Interfaces
{
    public interface IFileInterface
    {
        Task View(string fileName, MemoryStream stream, OpenOption context, string contentType = "application/pdf");
    }
}
