﻿#pragma checksum "..\..\..\..\..\Views\Flora\AddEditFlora.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "E116961EF9A293331EAAFA8940FECC4EED89A659"
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
using WPF.Views.Flora;


namespace WPF.Views.Flora {
    
    
    /// <summary>
    /// AddEditFlora
    /// </summary>
    public partial class AddEditFlora : MahApps.Metro.Controls.MetroWindow, System.Windows.Markup.IComponentConnector {
        
        
        #line 26 "..\..\..\..\..\Views\Flora\AddEditFlora.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label lblTitle;
        
        #line default
        #line hidden
        
        
        #line 30 "..\..\..\..\..\Views\Flora\AddEditFlora.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtName;
        
        #line default
        #line hidden
        
        
        #line 33 "..\..\..\..\..\Views\Flora\AddEditFlora.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtSpecies;
        
        #line default
        #line hidden
        
        
        #line 36 "..\..\..\..\..\Views\Flora\AddEditFlora.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox cbHabitat;
        
        #line default
        #line hidden
        
        
        #line 47 "..\..\..\..\..\Views\Flora\AddEditFlora.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtDescription;
        
        #line default
        #line hidden
        
        
        #line 50 "..\..\..\..\..\Views\Flora\AddEditFlora.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtPicture;
        
        #line default
        #line hidden
        
        
        #line 53 "..\..\..\..\..\Views\Flora\AddEditFlora.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal MahApps.Metro.Controls.ToggleSwitch switchOriginal;
        
        #line default
        #line hidden
        
        
        #line 56 "..\..\..\..\..\Views\Flora\AddEditFlora.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtCreatorEmail;
        
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
            System.Uri resourceLocater = new System.Uri("/WPF;component/views/flora/addeditflora.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\..\Views\Flora\AddEditFlora.xaml"
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
            this.lblTitle = ((System.Windows.Controls.Label)(target));
            return;
            case 2:
            
            #line 27 "..\..\..\..\..\Views\Flora\AddEditFlora.xaml"
            ((System.Windows.Controls.Image)(target)).MouseLeftButtonUp += new System.Windows.Input.MouseButtonEventHandler(this.BtnClose);
            
            #line default
            #line hidden
            return;
            case 3:
            this.txtName = ((System.Windows.Controls.TextBox)(target));
            return;
            case 4:
            this.txtSpecies = ((System.Windows.Controls.TextBox)(target));
            return;
            case 5:
            this.cbHabitat = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 6:
            this.txtDescription = ((System.Windows.Controls.TextBox)(target));
            return;
            case 7:
            this.txtPicture = ((System.Windows.Controls.TextBox)(target));
            return;
            case 8:
            this.switchOriginal = ((MahApps.Metro.Controls.ToggleSwitch)(target));
            return;
            case 9:
            this.txtCreatorEmail = ((System.Windows.Controls.TextBox)(target));
            return;
            case 10:
            
            #line 71 "..\..\..\..\..\Views\Flora\AddEditFlora.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.BtnEnviar);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

