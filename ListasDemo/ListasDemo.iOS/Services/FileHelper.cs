﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using ListasDemo.iOS.Services;
using ListasDemo.Services;
using Xamarin.Forms;

[assembly:Dependency(typeof(FileHelper))]
namespace ListasDemo.iOS.Services
{
    public class FileHelper : IFileHelper
    {
        public string GetLocalFilePath(string fileName)
        {
            string docFolder = 
                Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            string libFolder =
                Path.Combine(docFolder, "..", "Databases");
            if (!Directory.Exists(libFolder))
            {
                Directory.CreateDirectory(libFolder);
            }
            return Path.Combine(libFolder, fileName);
        }
    }
}
