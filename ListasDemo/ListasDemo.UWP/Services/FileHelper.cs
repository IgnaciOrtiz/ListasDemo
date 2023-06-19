using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage;
using ListasDemo.Services;
using ListasDemo.UWP.Services;
using Xamarin.Forms;

[assembly:Dependency(typeof(FileHelper))]
namespace ListasDemo.UWP.Services
{
    public class FileHelper : IFileHelper
    {
        public string GetLocalFilePath(string fileName)
        {
            return Path.Combine(ApplicationData.Current.LocalFolder.Path,
                fileName);
        }
    }
}
