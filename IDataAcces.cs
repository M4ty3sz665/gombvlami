using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using gombvlami.Model;

namespace gombvlami.persistance
{
    public interface IDataAcces
    {
        Task<ColorEventArgs> Load(string path);
        Task Save(string path, ColorEventArgs color);
    }
    
}
