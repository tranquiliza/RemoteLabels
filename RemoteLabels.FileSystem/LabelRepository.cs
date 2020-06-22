using RemoteLabels.Core;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace RemoteLabels.FileSystem
{
    public class LabelRepository : ILabelRepository
    {
        private const string fileName = "myLabel.txt";

        private readonly string filePath;

        public LabelRepository(IApplicationSettings applicationSettings)
        {
            this.filePath = applicationSettings.FilePath;
        }

        public void UpdateLabel(string newLabel)
        {
            try
            {
                EnsureFolderCreated();
                File.WriteAllText(FullFilePath(), newLabel);
            }
            catch (Exception)
            {
            }
        }

        public string GetCurrentLabel()
        {
            try
            {
                EnsureFolderCreated();
                return File.ReadAllText(FullFilePath());
            }
            catch (Exception)
            {
                return "";
            }
        }

        private void EnsureFolderCreated()
        {
            Directory.CreateDirectory(filePath);
        }

        private string FullFilePath() => filePath != string.Empty ? Path.Combine(filePath, fileName) : fileName;
    }
}
