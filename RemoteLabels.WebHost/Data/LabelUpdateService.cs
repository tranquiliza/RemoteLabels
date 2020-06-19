using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace RemoteLabels.WebHost.Data
{
    public class LabelUpdateService
    {
        private const string fileName = "myLabel.txt";

        private readonly string filePath;

        public LabelUpdateService(IApplicationSettings applicationSettings)
        {
            this.filePath = applicationSettings.FilePath;
        }

        public async Task UpdateLabel(string newLabel)
        {
            try
            {
                EnsureFolderCreated();
                await File.WriteAllTextAsync(FullFilePath(), newLabel).ConfigureAwait(false);
            }
            catch (Exception ex)
            {
            }
        }

        public async Task<string> GetCurrentLabel()
        {
            try
            {
                EnsureFolderCreated();
                return await File.ReadAllTextAsync(FullFilePath()).ConfigureAwait(false);
            }
            catch (Exception ex)
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
