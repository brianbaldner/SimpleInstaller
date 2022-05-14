using IWshRuntimeLibrary;
using Microsoft.Win32;
using System;
using System.Diagnostics;
using System.IO;
using System.IO.Compression;
using System.Net;
using System.Reflection;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using Path = System.IO.Path;

namespace SimpleInstaller
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        string[] j;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Grid_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
                this.DragMove();
        }

        private void TextBlock_MouseEnter(object sender, MouseEventArgs e)
        {
            TextBlock p = (TextBlock)sender;
            p.Background = Brushes.Red;
        }

        private void TextBlock_MouseLeave(object sender, MouseEventArgs e)
        {
            TextBlock p = (TextBlock)sender;
            p.Background = Brushes.Transparent;
        }

        private void TextBlock_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            var assembly = Assembly.GetExecutingAssembly();
            var resourceName = "SimpleInstaller.program.txt";
            string i;
            using (Stream stream = assembly.GetManifestResourceStream(resourceName))
            using (StreamReader reader = new StreamReader(stream))
            {
                i = reader.ReadToEnd();
            }

            j = i.Split(Environment.NewLine);
            Name.Text = j[0];
            Developer.Text = j[1];
            using (Stream stream = assembly.GetManifestResourceStream("SimpleInstaller.Logo.png"))
            using (StreamReader reader = new StreamReader(stream))
            {
                Logo.Source = BitmapFrame.Create(stream, BitmapCreateOptions.None, BitmapCacheOption.OnLoad);
                logoo.Source = BitmapFrame.Create(stream, BitmapCreateOptions.None, BitmapCacheOption.OnLoad);
            }
            var converter = new System.Windows.Media.BrushConverter();
            var brush = (Brush)converter.ConvertFromString(j[2]);
            this.Title = j[0] + " Installer";

            Location.Text = Environment.GetFolderPath(Environment.SpecialFolder.ProgramFilesX86) + j[4];
        }

        private void SettingsPress(object sender, MouseButtonEventArgs e)
        {
            settings.Visibility = Visibility.Visible;
        }
        private void SettingsXPress(object sender, MouseButtonEventArgs e)
        {
            settings.Visibility = Visibility.Collapsed;
        }

        private async void Install(object sender, MouseButtonEventArgs e)
        {
            startpage.Visibility = Visibility.Collapsed;
            settings.Visibility = Visibility.Collapsed;
            downloadpage.Visibility = Visibility.Visible;
            byte[] file;

            if (j[3] != "local")
            {
                WebClient client = new WebClient();
                client.DownloadProgressChanged += delegate (object sender, DownloadProgressChangedEventArgs e) { progressBar.Width = ((double)e.ProgressPercentage / 100) * 180; };
                file = await client.DownloadDataTaskAsync(new Uri(j[3]));
            }
            else
            {
                var assembly = Assembly.GetExecutingAssembly();
                var resourceName = "SimpleInstaller.pack.zip";
                using (Stream stream = assembly.GetManifestResourceStream(resourceName))
                {
                    MemoryStream ms = new MemoryStream();
                    await stream.CopyToAsync(ms);
                    file = ms.ToArray();
                }
                progressBar.Width = 180;
            }

            System.IO.File.WriteAllBytes(Path.GetTempPath() + "quickinstall.zip", file);
            if (Directory.Exists(Location.Text))
            {
                Directory.Delete(Location.Text, true);
            }
            DirectoryInfo di = Directory.CreateDirectory(Location.Text);
            ZipFile.ExtractToDirectory(Path.GetTempPath() + "quickinstall.zip", Location.Text);
            System.IO.File.Delete(Path.GetTempPath() + "quickinstall.zip");
            if (!System.IO.File.Exists(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\" + j[6] + ".lnk"))
            {
                WshShell wsh = new WshShell();
                IWshRuntimeLibrary.IWshShortcut shortcut = wsh.CreateShortcut(
                Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\" + j[6] + ".lnk") as IWshRuntimeLibrary.IWshShortcut;
                shortcut.TargetPath = Environment.GetFolderPath(Environment.SpecialFolder.ProgramFilesX86) + j[4] + j[5];
                // not sure about what this is for
                shortcut.WindowStyle = 1;
                shortcut.WorkingDirectory = Environment.GetFolderPath(Environment.SpecialFolder.ProgramFilesX86) + j[4];
                shortcut.Save();
            }
            System.Diagnostics.Debug.WriteLine("done");
            progressBar.Width = 200;
            downloadpage.Visibility = Visibility.Collapsed;
            endpage.Visibility = Visibility.Visible;
        }

        private void TextBlock_MouseDown_1(object sender, MouseButtonEventArgs e)
        {
            Process.Start(Location.Text + j[5]);
            Application.Current.Shutdown();
        }

        private void LinkPress(object sender, MouseButtonEventArgs e)
        {
            Process myProcess = new Process();
            myProcess.StartInfo.UseShellExecute = true;
            myProcess.StartInfo.FileName = "https://github.com/brianbaldner/quickinstall";
            myProcess.Start();
        }
    }
}
