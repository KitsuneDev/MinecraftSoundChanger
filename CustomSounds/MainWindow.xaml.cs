using System.Windows;
using System.IO;

namespace CustomSounds
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            //initialize records tree
            Directory.CreateDirectory("C:/tmp/soundpcker/assets/minecraft/sounds/records");
            Directory.SetCurrentDirectory("C:/tmp/soundpcker/");
            StreamWriter mcmeta = File.CreateText("pack.mcmeta");
            mcmeta.WriteLine("{");
            mcmeta.WriteLine("   \"pack\":{");
            mcmeta.WriteLine("      \"pack_format\":1,");
            mcmeta.WriteLine("      \"description\":\"Music Disks Custom Injector Bytecode\"");
            mcmeta.WriteLine("   }");
            mcmeta.Write("}");
            mcmeta.Close();
            StreamWriter lcrm = File.CreateText("lcrm");
            lcrm.Write("MwCGMSC!!");
            lcrm.Close();
            EditMusicDisk emd = new EditMusicDisk();
            emd.Show();
            this.Hide();
        }
    }
}
