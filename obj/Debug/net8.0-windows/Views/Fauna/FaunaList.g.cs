﻿#pragma checksum "..\..\..\..\..\Views\Fauna\FaunaList.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "5C16773682CB9F322B8AF5E8F5D940E053658664"
//------------------------------------------------------------------------------
// <auto-generated>
//     Este código fue generado por una herramienta.
//     Versión de runtime:4.0.30319.42000
//
//     Los cambios en este archivo podrían causar un comportamiento incorrecto y se perderán si
//     se vuelve a generar el código.
// </auto-generated>
//------------------------------------------------------------------------------

using MahApps.Metro;
using MahApps.Metro.Accessibility;
using MahApps.Metro.Actions;
using MahApps.Metro.Automation.Peers;
using MahApps.Metro.Behaviors;
using MahApps.Metro.Controls;
using MahApps.Metro.Controls.Dialogs;
using MahApps.Metro.Converters;
using MahApps.Metro.Markup;
using MahApps.Metro.Theming;
using MahApps.Metro.ValueBoxes;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Controls.Ribbon;
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
using WPF.Views.Fauna;


namespace WPF.Views.Fauna {
    
    
    /// <summary>
    /// FaunaList
    /// </summary>
    public partial class FaunaList : MahApps.Metro.Controls.MetroWindow, System.Windows.Markup.IComponentConnector, System.Windows.Markup.IStyleConnector {
        
        
        #line 34 "..\..\..\..\..\Views\Fauna\FaunaList.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListView faunaListView;
        
        #line default
        #line hidden
        
        
        #line 123 "..\..\..\..\..\Views\Fauna\FaunaList.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnAdd;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "8.0.1.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/WPF;component/views/fauna/faunalist.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\..\Views\Fauna\FaunaList.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "8.0.1.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            
            #line 22 "..\..\..\..\..\Views\Fauna\FaunaList.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.BtnUsuarios);
            
            #line default
            #line hidden
            return;
            case 2:
            
            #line 24 "..\..\..\..\..\Views\Fauna\FaunaList.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.BtnFlora);
            
            #line default
            #line hidden
            return;
            case 3:
            
            #line 25 "..\..\..\..\..\Views\Fauna\FaunaList.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.BtnArtefactos);
            
            #line default
            #line hidden
            return;
            case 4:
            
            #line 26 "..\..\..\..\..\Views\Fauna\FaunaList.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.BtnExploradores);
            
            #line default
            #line hidden
            return;
            case 5:
            
            #line 27 "..\..\..\..\..\Views\Fauna\FaunaList.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.BtnSolicitudes);
            
            #line default
            #line hidden
            return;
            case 6:
            
            #line 28 "..\..\..\..\..\Views\Fauna\FaunaList.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.BtnLogout);
            
            #line default
            #line hidden
            return;
            case 7:
            this.faunaListView = ((System.Windows.Controls.ListView)(target));
            return;
            case 10:
            this.btnAdd = ((System.Windows.Controls.Button)(target));
            
            #line 123 "..\..\..\..\..\Views\Fauna\FaunaList.xaml"
            this.btnAdd.Click += new System.Windows.RoutedEventHandler(this.BtnAdd);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "8.0.1.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        void System.Windows.Markup.IStyleConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 8:
            
            #line 112 "..\..\..\..\..\Views\Fauna\FaunaList.xaml"
            ((System.Windows.Controls.Image)(target)).MouseLeftButtonUp += new System.Windows.Input.MouseButtonEventHandler(this.BtnEdit);
            
            #line default
            #line hidden
            break;
            case 9:
            
            #line 113 "..\..\..\..\..\Views\Fauna\FaunaList.xaml"
            ((System.Windows.Controls.Image)(target)).MouseLeftButtonUp += new System.Windows.Input.MouseButtonEventHandler(this.BtnDelete);
            
            #line default
            #line hidden
            break;
            }
        }
    }
}

