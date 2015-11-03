using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.IO;
using System.IO.Packaging;
using Ionic.Zip;
using Microsoft.Win32;

namespace CustomSounds
{
    /// <summary>
    /// Interaction logic for EditMusicDisk.xaml
    /// </summary>
    public partial class EditMusicDisk : Window
    {
        private string exportpath;
        string tomodifyoggorigin;

        private String tomodifyname;
        public EditMusicDisk()
        {
            InitializeComponent();
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            waitingList.Items.Add(tomodifyname);
            File.Copy(tomodifyoggorigin, "C:/tmp/soundpcker/assets/minecraft/sounds/records/" + tomodifyname + ".ogg", true);

        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("OGG is the Format that minecraft stores audio." +
                            " To create your OGG, download audacity and open your audio file, then goto File, Export and Select something like OGG Vorbis in Type.", "Info", MessageBoxButton.OK, MessageBoxImage.Asterisk);

        }



        private void button2_Click(object sender, RoutedEventArgs e)
        {
            tomodifyname = diskSelector.Text.ToString();

            
            Directory.SetCurrentDirectory("C:/tmp/soundpcker/assets/minecraft/sounds/records");
            Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog();
            dlg.DefaultExt = ".ogg";
            dlg.Filter = "OGG Audio (.ogg)|*.ogg";
            dlg.Multiselect = false;
            bool? result = dlg.ShowDialog();
            if (result == true)
            {
                tomodifyoggorigin = dlg.FileName;
            }
            if (result == false)
            {
                MessageBox.Show("Operation Cancelled.", "Cancelled", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            
        }

        private void button3_Copy_Click(object sender, RoutedEventArgs e)
        {

        }

        private void button3_Click(object sender, RoutedEventArgs e)
        {
            Directory.SetCurrentDirectory("C:/tmp/soundpcker");
            using (ZipFile zip = new ZipFile())
            {
                // add this map file into the "images" directory in the zip archive
                zip.AddFile("pack.mcmeta");
                // add the report into a different directory in the archive
                zip.AddDirectory("assets");
                zip.AddFile("lcrm");
                zip.Save("CustomSoundInjector_ResourcePack.zip");
            }
                SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.DefaultExt = ".zip";
            saveFileDialog.Filter = "Minecraft ResourcePack (with Bytecode)|*.zip";
            if (saveFileDialog.ShowDialog() == true)
            {
                exportpath = saveFileDialog.FileName;
            }
            else
            {
                MessageBox.Show("Operation Cancelled.", "Cancelled", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            string originExport = "C:/tmp/soundpcker/CustomSoundInjector_ResourcePack.zip";
            File.Copy(originExport, exportpath, true);
            MessageBox.Show("Saved.", "Saved", MessageBoxButton.OK, MessageBoxImage.Information);

        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            Directory.SetCurrentDirectory("C:/");
            Directory.Delete("C:/tmp", true);
            MainWindow mw = new MainWindow();
            mw.Show();
        }
    }
}
