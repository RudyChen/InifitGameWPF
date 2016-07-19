using Microsoft.Win32;
using Microsoft.WindowsAPICodePack.Dialogs;
using Microsoft.WindowsAPICodePack.Shell;
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

namespace MetroStopStation
{
    /// <summary>
    /// ImportGraphicFile.xaml 的交互逻辑
    /// </summary>
    public partial class ImportGraphicFile : Window
    {
        public ImportGraphicFile()
        {
            InitializeComponent();
        }

        private string importFilePath=string.Empty;

        public string ImportFilePath
        {
            get { return importFilePath; }
            set { importFilePath = value; }
        }


        private void ImportButton_Clicked(object sender, RoutedEventArgs e)
        {
           
            if (!string.IsNullOrEmpty(ImportFilePath))
            {
                this.DialogResult = true;
            }
            this.Close();
        }

        private void FileBrowseButton_Clicked(object sender, RoutedEventArgs e)
        {
            ShellContainer selectedFolder = null;
           selectedFolder = KnownFolders.Computer as ShellContainer;
            CommonOpenFileDialog openFileDialog = new CommonOpenFileDialog();
            openFileDialog.InitialDirectoryShellContainer = selectedFolder;
            openFileDialog.EnsureReadOnly = true;

            if (openFileDialog.ShowDialog() == CommonFileDialogResult.Ok)
            {
                ImportFilePath = openFileDialog.FileName;
                pathTextBox.Text = importFilePath;
            }
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (!string.IsNullOrEmpty(ImportFilePath))
            {
                this.DialogResult = true;
            }
            else
            {
                this.DialogResult = false;
            }
        }
    }
}
