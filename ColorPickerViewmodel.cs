using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.Input;
using gombvlami.Model;

namespace gombvlami.Viewmodel
{
    public class ColorPickerViewmodel : ViewModelBase
    {
        private ColorPickerViewmodel mmodel;

        public int Red { get {
                return mmodel.Red;
            } set
            {
                if (mmodel.Red != value)
                {
                    Red = value;
                    OnPropertyChanged(nameof(Red));
                }

            } }
        public int Green
        {
            get
            {
                return mmodel.Green;
                OnPropertyChanged(nameof(Green));
            }
            set
            {
                if (mmodel.Green != value)
                {
                    Green = value;
                }

            }
        }
        public int Blue
        {
            get
            {
                return mmodel.Blue;
            }
            set
            {
                if (mmodel.Blue != value)
                {
                    Blue = value;
                    OnPropertyChanged(nameof(Blue));
                }
            }
        }

        private string color;
        private string text;
        private ColorPickerModel mmodel1;

        public string ButtonText
        {
            get
            {
                return text;
            }
            set
            {
                if (text != value)
                {
                    text = value;
                    OnPropertyChanged(nameof(text));
                }

            }
        }

        public string ButtonColor
        {
            get
            {
                return color;
            }
            set
            {
                if (color != value)
                {
                    color = value;
                    OnPropertyChanged(nameof(color));
                }

            }
        }

        public RelayCommand PickColorCommand { get; private set; }
        public RelayCommand<string> MenuCommand { get; private set; }

        public event EventHandler ExitEvent;
        public event EventHandler SaveEvent;
        public event EventHandler LoadEvent;

        public ColorPickerViewmodel(ColorPickerModel model) 
        {
            mmodel = model;
            PickColorCommand = new RelayCommand(PickColor);
            MenuCommand = new RelayCommand<string>(MenuOption);
            mmodel.ColorChanged += OnColorChanged;
        }

        public ColorPickerViewmodel(ColorPickerModel mmodel1)
        {
            this.mmodel1 = mmodel1;
        }

        private void OnColorChanged(object sender, ColorEventArgs e)
        {
            ButtonColor = e.HexCode;
            ButtonText = e.HexCode;
        }
        private void MenuOption(string option)
        {
            switch (option)
            {
                case "RESET": mmodel.ResetColors(); break;
                case "SAVE": SaveEvent.Invoke(this, new EventArgs()); break;
                case "LOAD": LoadEvent.Invoke(this, new EventArgs()); break;
                case "EXIT": ExitEvent.Invoke(this, new EventArgs()); break;
            }
        }
        private void PickColor()
        {
            mmodel.ChangeColorValues(Red, Green, Blue);
            
        }
    }
}
