using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using gombvlami.persistance;
using System.Drawing;


namespace gombvlami.Model
{
    public class ColorPickerModel
    {
        private IDataAcces acces; 
        public int Red { get; private set; }
        public int Green { get; private set; }
        public int Blue { get; private set; }

        public event EventHandler<ColorEventArgs> ColorChanged;

        public ColorPickerModel(IDataAcces access)
        {
            acces = access;
            ChangeColorValues(0, 0, 0);
        }
        public void ChangeColorValues(int red,int green,int blue)
        {
            Red = 0;
            Green = 0;
            Blue = 0;
            if (red >= 0 && red <= 255)
                Red = red;
            if (green >= 0 && green <= 255)
                Green = green;
            if (blue >= 0 && blue <= 255)
                Blue = blue;
            OnColorChanged(GenerateHexCode());
        }
        public string GenerateHexCode()
        {
            var color = Color.FromArgb(Red, Green, Blue);
            string colorHexCode = "#"+color.R.ToString("X2") + color.G.ToString("X2") + color.B.ToString("X2");

            return colorHexCode;
        }
        public void OnColorChanged(string hexcode)
        {
            ColorChanged?.Invoke(this, new ColorEventArgs(Red, Green, Blue, hexcode));
        }

        public void ResetColors()
        {
            ChangeColorValues(0, 0, 0);
        }
        public void Save(string filename)
        {
            string hex = GenerateHexCode();
            acces.Save(filename, new ColorEventArgs(Red, Green, Blue, hex));
        }
        public async void Load(string filename)
        {
            ColorEventArgs color = await acces.Load(filename);
            ChangeColorValues(color.Red, color.Green, color.Blue);
        }
    }
}
