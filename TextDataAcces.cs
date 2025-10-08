using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using gombvlami.Model;

namespace gombvlami.persistance
{
    public class TextDataAcces : IDataAcces
    {
        public TextDataAcces()
        {

        }

        public async Task<ColorEventArgs> Load(string path)
        {
            try
            {
                using (StreamReader sr = new StreamReader(path))
                {
                    string red = await sr.ReadLineAsync() ?? string.Empty;
                    string green = await sr.ReadLineAsync() ?? string.Empty;
                    string blue = await sr.ReadLineAsync() ?? string.Empty;
                    string hexCode = await sr.ReadLineAsync() ?? string.Empty;
                    
                    
                    return new ColorEventArgs(int.Parse(red), int.Parse(green), int.Parse(blue), hexCode);
                        
                }
            }
            catch (Exception)
            {
                throw new Exception();
            }
        }
        public async Task Save(string path, ColorEventArgs color)
        {
            try
            {
                using (StreamWriter sw = new StreamWriter(path))
                {
                    await sw.WriteLineAsync(color.Red.ToString());
                    await sw.WriteLineAsync(color.Green.ToString());
                    await sw.WriteLineAsync(color.Blue.ToString());
                    await sw.WriteLineAsync(color.HexCode.ToString());
                }
            }
            catch (Exception)
            {

                throw new Exception(); 
            }
        }
    }
}
