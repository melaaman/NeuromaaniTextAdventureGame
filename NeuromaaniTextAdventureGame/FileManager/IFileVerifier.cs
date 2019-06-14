using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeuromaaniTextAdventureGame.FileManager
{
    public interface IFileVerifier
    {
        bool IsValidFileName(string fileName);
    }
}
