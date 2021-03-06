﻿
using Microsoft.WindowsAPICodePack.Dialogs;
using Microsoft.WindowsAPICodePack.Shell;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Xml;
using Themes.CustomControls;

namespace MetroStopStation
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : WindowBase
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            
        }

        #region 页面缩放
        private void ZoomBig_Click(object sender, RoutedEventArgs e)
        {
            //drawCanvas.Scale += 0.2;
            //drawCanvas.Width += drawCanvas.ActualViewbox.Width;
            //drawCanvas.Height += drawCanvas.ActualViewbox.Height;
        }

        private void ZoomIn_Clicked(object sender, RoutedEventArgs e)
        {
            //if (drawCanvas.Scale >=1.2)
            //{
            //    drawCanvas.Scale -= 0.2;
            //}
        }

        private void ZoomBack_Clicked(object sender, RoutedEventArgs e)
        {
            //drawCanvas.Scale = 1;
            //drawCanvas.Offset = new Point(0, 0);
        }
        #endregion


        private void ElementSelectTool_Checked(object sender, RoutedEventArgs e)
        {
            var button = sender as RadioButton;
            var toolItem = ToolManager.GetInstance().Tools.Find(p => p.ToolType.ToString() == button.Name);
            ToolManager.GetInstance().SetSelectToolItem(toolItem.ToolType);
            ClearDrawShapTool();
        }

        private void CanvasMoveTool_Checked(object sender, RoutedEventArgs e)
        {
            var button = sender as RadioButton;
            var toolItem = ToolManager.GetInstance().Tools.Find(p => p.ToolType.ToString() == button.Name);
            ToolManager.GetInstance().SetSelectToolItem(toolItem.ToolType);
            ClearDrawShapTool();
        }

        private void ToolBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ListBoxItem listToolItem = toolBox.SelectedItem as ListBoxItem;

            if (null!=listToolItem)
            {
                var toolItem = ToolManager.GetInstance().Tools.Find(p => p.ToolType.ToString() == listToolItem.Name);
                ToolManager.GetInstance().SetSelectToolItem(toolItem.ToolType);
                ClearControlToolBar();
            }
        }

        private void ClearControlToolBar()
        {
            foreach (var item in controlToolBar.Items)
            {
                var button = item as RadioButton;
                button.IsChecked = false;
            }
        }

        private void ClearDrawShapTool()
        {
            foreach (var item in toolBox.Items)
            {
                var listboxItem = item as ListBoxItem;
                listboxItem.IsSelected = false;
            }
        }

        private void GraphicExportButton_Click(object sender, RoutedEventArgs e)
        {
            if (this.tabControl.Items != null && this.tabControl.Items.Count > 0)
            {
                TabItem tabItem = this.tabControl.SelectedItem as TabItem;

                GraphicPanelControl graphicPanel=tabItem.Content as GraphicPanelControl;

                string defaultFileName = tabItem.Header.ToString();
                CommonSaveFileDialog saveFileDialog = new CommonSaveFileDialog(defaultFileName);
                saveFileDialog.DefaultExtension = "dat";
                saveFileDialog.DefaultFileName = defaultFileName;
                saveFileDialog.RestoreDirectory = true; 

                if (saveFileDialog.ShowDialog()== CommonFileDialogResult.Ok)
                {
                    try
                    {
                        using (FileStream fs = new FileStream(saveFileDialog.FileName, FileMode.Create))
                        {
                            //当需要保存当前图形时，调用XamlWriter的以下方法将Canvas对象直接序列化到文件流中
                            XamlWriter.Save(graphicPanel.SaveGraphic(), fs); 
                        }
                    }
                    catch (Exception)
                    {                        
                    }
                }
               
            }


        }

        private void GraphicImportButton_Clicked(object sender, RoutedEventArgs e)
        {
            string filePath = string.Empty;         

            ShellContainer selectedFolder = null;
            selectedFolder = KnownFolders.Computer as ShellContainer;
            CommonOpenFileDialog openFileDialog = new CommonOpenFileDialog();
            openFileDialog.InitialDirectoryShellContainer = selectedFolder;
            openFileDialog.EnsurePathExists = true;
            openFileDialog.EnsureFileExists = true;
            openFileDialog.DefaultExtension = "dat";
            openFileDialog.EnsureReadOnly = true;

            if (openFileDialog.ShowDialog() == CommonFileDialogResult.Ok)
            {
                filePath= openFileDialog.FileName;

                TabItem newTabItem = new TabItem();
                newTabItem.Header = System.IO.Path.GetFileNameWithoutExtension(filePath);


                
                ScrollViewer scrollViewer = null;
                try
                {
                    using (FileStream fs = new FileStream(filePath, FileMode.Open))
                    {
                        scrollViewer = XamlReader.Load(fs) as ScrollViewer; 
                    }
                }
                catch (Exception ex)
                {
                }
                if (scrollViewer != null)
                {
                    GraphicPanelControl graphicsPanelControl = new GraphicPanelControl(scrollViewer);
                    //graphicsPanelControl.ImportFile(scrollViewer);
                    newTabItem.Content = graphicsPanelControl;
                    this.tabControl.Items.Add(newTabItem);
                    newTabItem.IsSelected = true;
                }
            }             
        }

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
           
        }

        private void NewFileMenu_Clicked(object sender, RoutedEventArgs e)
        {
            string newFileName = GetNewFileNameIndex();
            GraphicPanelControl graphicsPanelControl = new GraphicPanelControl();
            TabItem newTabItem = new TabItem();
            newTabItem.Header = newFileName;
            newTabItem.Content = graphicsPanelControl;
            this.tabControl.FlowDirection = FlowDirection.LeftToRight;
            this.tabControl.Items.Add(newTabItem);
            newTabItem.IsSelected = true;
        }

        private string GetNewFileNameIndex()
        {
            int maxIndex = 1;
            foreach (TabItem item in this.tabControl.Items)
            {
                string headerName = item.Header.ToString();
                string indexChar = headerName.Substring(headerName.Length - 1, 1);
                Regex r = new Regex(@"^\d*$");
                int index = 1;
                if (r.IsMatch(indexChar))
                {
                    if (int.TryParse(indexChar, out index))
                    {
                        if (index>=1)
                        {
                            maxIndex++;
                        }
                    }
                }
            }

            return "未命名文件" + maxIndex.ToString();
        }

        private void SaveFileMenu_Clicked(object sender, RoutedEventArgs e)
        {
            
        }

        private void SendCommandToChild_Clicked(object sender, RoutedEventArgs e)
        {
            ButtonBase buttonBase = sender as ButtonBase;
            if (this.tabControl.Items!=null&& this.tabControl.Items.Count>0)
            {
                var tabItem=this.tabControl.SelectedItem as TabItem;
                GraphicPanelControl graphicPanel= tabItem.Content as GraphicPanelControl;
                graphicPanel.ExecuteCommand(buttonBase.Name);
            }

        }       
    }
}
