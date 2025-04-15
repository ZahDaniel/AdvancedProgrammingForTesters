using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PageLibrary.Interfaces
{
    public interface IPage : IPageHelper
    {
        void UploadFile(string selector, string filePath);
    }
}
