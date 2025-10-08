using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using gombvlami.Model;
using gombvlami.persistance;
using gombvlami.Viewmodel;
using Microsoft.Win32;

namespace gombvlami
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {

        private MainWindow wwindow;
        private ColorPickerModel mmodel;
        private ColorPickerViewmodel vmodel;
        private IDataAcces dataAcces;

        App()
        {
            Startup += App_Startup;
        }

        private void App_Startup(object sender, StartupEventArgs e)
        {
            dataAcces = new TextDataAcces();
            mmodel = new ColorPickerModel(dataAcces);
            vmodel = new ColorPickerViewmodel(mmodel);
            wwindow = new MainWindow();
            vmodel.ExitEvent += OnExit;
            vmodel.ExitEvent += OnSave;
            vmodel.LoadEvent += OnLoad;
            wwindow.DataContext = vmodel;
            wwindow.Show();
        }
        private void OnLoad(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog ofd = new OpenFileDialog();
                ofd.Filter = "txt files (*txt)|*.txt";
                if (ofd.ShowDialog() == true)
                {
                    var color = dataAcces.Load(ofd.FileName).Result;
                    mmodel.ChangeColorValues(color.Red, color.Green, color.Blue);
                }
            }
            catch (Exception)
            {
                MessageBox.Show("error while loading", "color picker", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        private void OnExit(object sender, EventArgs e)
        {
            wwindow.Close();
        }
        private void OnSave(object sender, EventArgs e)
        {
            try
            {
                SaveFileDialog sfd = new SaveFileDialog();
                sfd.Filter = "txt files (*txt)|*.txt";
                if (sfd.ShowDialog() == true)
                {
                    mmodel.Save(sfd.FileName);
                }
            }
            catch (Exception)
            {
                MessageBox.Show("error while saving","color picker",MessageBoxButton.OK,MessageBoxImage.Error);
            }
        }
    }
}
