﻿#pragma checksum "..\..\GraphicPanelControl.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "E32941B75924760B6560CDD7F0AFC202"
//------------------------------------------------------------------------------
// <auto-generated>
//     此代码由工具生成。
//     运行时版本:4.0.30319.42000
//
//     对此文件的更改可能会导致不正确的行为，并且如果
//     重新生成代码，这些更改将会丢失。
// </auto-generated>
//------------------------------------------------------------------------------

using MetroStopStation;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;
using System.Windows.Media.TextFormatting;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Shell;


namespace MetroStopStation {
    
    
    /// <summary>
    /// GraphicPanelControl
    /// </summary>
    public partial class GraphicPanelControl : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector {
        
        
        #line 460 "..\..\GraphicPanelControl.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid userControlGrid;
        
        #line default
        #line hidden
        
        
        #line 461 "..\..\GraphicPanelControl.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ScrollViewer drawCanvasParent;
        
        #line default
        #line hidden
        
        
        #line 462 "..\..\GraphicPanelControl.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ZoomableCanvas drawCanvas;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/MetroStopStation;component/graphicpanelcontrol.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\GraphicPanelControl.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            
            #line 9 "..\..\GraphicPanelControl.xaml"
            ((MetroStopStation.GraphicPanelControl)(target)).Loaded += new System.Windows.RoutedEventHandler(this.UserControl_Loaded);
            
            #line default
            #line hidden
            
            #line 9 "..\..\GraphicPanelControl.xaml"
            ((MetroStopStation.GraphicPanelControl)(target)).KeyDown += new System.Windows.Input.KeyEventHandler(this.UserControl_KeyDown);
            
            #line default
            #line hidden
            return;
            case 2:
            this.userControlGrid = ((System.Windows.Controls.Grid)(target));
            return;
            case 3:
            this.drawCanvasParent = ((System.Windows.Controls.ScrollViewer)(target));
            return;
            case 4:
            this.drawCanvas = ((System.Windows.Controls.ZoomableCanvas)(target));
            
            #line 462 "..\..\GraphicPanelControl.xaml"
            this.drawCanvas.MouseLeftButtonDown += new System.Windows.Input.MouseButtonEventHandler(this.DrawCanvas_MouseLeftButtonDown);
            
            #line default
            #line hidden
            
            #line 462 "..\..\GraphicPanelControl.xaml"
            this.drawCanvas.MouseMove += new System.Windows.Input.MouseEventHandler(this.DrawCanvas_MouseMove);
            
            #line default
            #line hidden
            
            #line 462 "..\..\GraphicPanelControl.xaml"
            this.drawCanvas.MouseLeftButtonUp += new System.Windows.Input.MouseButtonEventHandler(this.DrawCanvas_MouseLeftButtonUp);
            
            #line default
            #line hidden
            
            #line 462 "..\..\GraphicPanelControl.xaml"
            this.drawCanvas.KeyDown += new System.Windows.Input.KeyEventHandler(this.drawCanvas_KeyDown);
            
            #line default
            #line hidden
            
            #line 462 "..\..\GraphicPanelControl.xaml"
            this.drawCanvas.MouseEnter += new System.Windows.Input.MouseEventHandler(this.drawCanvas_MouseEnter);
            
            #line default
            #line hidden
            
            #line 462 "..\..\GraphicPanelControl.xaml"
            this.drawCanvas.MouseLeave += new System.Windows.Input.MouseEventHandler(this.drawCanvas_MouseLeave);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

