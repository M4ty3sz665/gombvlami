using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gombvlami.Model
{
    public class ColorEventArgs: EventArgs
    {

        public int Red { get; private set; }
        public int Green { get; private set; }
        public int Blue { get; private set; }

        public string HexCode { get; private set; }


        public ColorEventArgs(int red, int green, int blue, string hexCode)
        {
            Red = red;
            Green = green;
            Blue = blue;
            HexCode = hexCode;
        }

    }
}
