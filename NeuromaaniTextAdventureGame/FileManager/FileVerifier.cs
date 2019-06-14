using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeuromaaniTextAdventureGame.FileManager
{
    public class FileVerifier : IFileVerifier
    {
        public bool IsValidFileName(string fileName) => fileName.EndsWith(".txt", StringComparison.CurrentCultureIgnoreCase) && !string.IsNullOrEmpty(fileName) ?
            true : throw new Exception("Filename is missing or wrong format!");
    }
}
