﻿#pragma checksum "..\..\Utilizador.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "E921A685F038D0B1F69215BBB1E3E7FC"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using OrniBest;
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


namespace OrniBest {
    
    
    /// <summary>
    /// Utilizador
    /// </summary>
    public partial class Utilizador : System.Windows.Controls.Page, System.Windows.Markup.IComponentConnector {
        
        
        #line 12 "..\..\Utilizador.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label lb_nome;
        
        #line default
        #line hidden
        
        
        #line 13 "..\..\Utilizador.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox tb_nome;
        
        #line default
        #line hidden
        
        
        #line 15 "..\..\Utilizador.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Image image_utilizador;
        
        #line default
        #line hidden
        
        
        #line 17 "..\..\Utilizador.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btt_selecionarimagem;
        
        #line default
        #line hidden
        
        
        #line 18 "..\..\Utilizador.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label lb_morada;
        
        #line default
        #line hidden
        
        
        #line 19 "..\..\Utilizador.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox tb_morada;
        
        #line default
        #line hidden
        
        
        #line 20 "..\..\Utilizador.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label lb_codigopostal;
        
        #line default
        #line hidden
        
        
        #line 21 "..\..\Utilizador.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox tb_codigopostal;
        
        #line default
        #line hidden
        
        
        #line 22 "..\..\Utilizador.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label lb_telemovel;
        
        #line default
        #line hidden
        
        
        #line 23 "..\..\Utilizador.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox tb_telemovel;
        
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
            System.Uri resourceLocater = new System.Uri("/OrniBest;component/utilizador.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\Utilizador.xaml"
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
            this.lb_nome = ((System.Windows.Controls.Label)(target));
            return;
            case 2:
            this.tb_nome = ((System.Windows.Controls.TextBox)(target));
            return;
            case 3:
            this.image_utilizador = ((System.Windows.Controls.Image)(target));
            return;
            case 4:
            this.btt_selecionarimagem = ((System.Windows.Controls.Button)(target));
            
            #line 17 "..\..\Utilizador.xaml"
            this.btt_selecionarimagem.Click += new System.Windows.RoutedEventHandler(this.btt_selecionarimagem_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.lb_morada = ((System.Windows.Controls.Label)(target));
            return;
            case 6:
            this.tb_morada = ((System.Windows.Controls.TextBox)(target));
            return;
            case 7:
            this.lb_codigopostal = ((System.Windows.Controls.Label)(target));
            return;
            case 8:
            this.tb_codigopostal = ((System.Windows.Controls.TextBox)(target));
            return;
            case 9:
            this.lb_telemovel = ((System.Windows.Controls.Label)(target));
            return;
            case 10:
            this.tb_telemovel = ((System.Windows.Controls.TextBox)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

