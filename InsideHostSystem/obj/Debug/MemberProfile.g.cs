﻿#pragma checksum "..\..\MemberProfile.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "CCC23E2242186CAA56BCCC71D93F2A1A6155209D"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using InsideHostSystem;
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


namespace InsideHostSystem {
    
    
    /// <summary>
    /// MemberProfile
    /// </summary>
    public partial class MemberProfile : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 14 "..\..\MemberProfile.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock MemberName;
        
        #line default
        #line hidden
        
        
        #line 20 "..\..\MemberProfile.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button Send;
        
        #line default
        #line hidden
        
        
        #line 21 "..\..\MemberProfile.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button AddToContacts;
        
        #line default
        #line hidden
        
        
        #line 22 "..\..\MemberProfile.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox NewContact;
        
        #line default
        #line hidden
        
        
        #line 23 "..\..\MemberProfile.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button Requests;
        
        #line default
        #line hidden
        
        
        #line 24 "..\..\MemberProfile.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox MessageContent;
        
        #line default
        #line hidden
        
        
        #line 25 "..\..\MemberProfile.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button Unseen;
        
        #line default
        #line hidden
        
        
        #line 26 "..\..\MemberProfile.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox NotContacted;
        
        #line default
        #line hidden
        
        
        #line 34 "..\..\MemberProfile.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox Contacts;
        
        #line default
        #line hidden
        
        
        #line 35 "..\..\MemberProfile.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox MailTo;
        
        #line default
        #line hidden
        
        
        #line 36 "..\..\MemberProfile.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button AllMessages;
        
        #line default
        #line hidden
        
        
        #line 38 "..\..\MemberProfile.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock EventsFromOP;
        
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
            System.Uri resourceLocater = new System.Uri("/InsideHostSystem;component/memberprofile.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\MemberProfile.xaml"
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
            
            #line 8 "..\..\MemberProfile.xaml"
            ((InsideHostSystem.MemberProfile)(target)).Closing += new System.ComponentModel.CancelEventHandler(this.Window_Closing);
            
            #line default
            #line hidden
            return;
            case 2:
            this.MemberName = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 3:
            this.Send = ((System.Windows.Controls.Button)(target));
            
            #line 20 "..\..\MemberProfile.xaml"
            this.Send.Click += new System.Windows.RoutedEventHandler(this.Send_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.AddToContacts = ((System.Windows.Controls.Button)(target));
            
            #line 21 "..\..\MemberProfile.xaml"
            this.AddToContacts.Click += new System.Windows.RoutedEventHandler(this.AddToContacts_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.NewContact = ((System.Windows.Controls.TextBox)(target));
            return;
            case 6:
            this.Requests = ((System.Windows.Controls.Button)(target));
            
            #line 23 "..\..\MemberProfile.xaml"
            this.Requests.Click += new System.Windows.RoutedEventHandler(this.Requests_Click);
            
            #line default
            #line hidden
            return;
            case 7:
            this.MessageContent = ((System.Windows.Controls.TextBox)(target));
            return;
            case 8:
            this.Unseen = ((System.Windows.Controls.Button)(target));
            
            #line 25 "..\..\MemberProfile.xaml"
            this.Unseen.Click += new System.Windows.RoutedEventHandler(this.Unseen_Click);
            
            #line default
            #line hidden
            return;
            case 9:
            this.NotContacted = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 10:
            this.Contacts = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 11:
            this.MailTo = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 12:
            this.AllMessages = ((System.Windows.Controls.Button)(target));
            
            #line 36 "..\..\MemberProfile.xaml"
            this.AllMessages.Click += new System.Windows.RoutedEventHandler(this.AllMessages_Click);
            
            #line default
            #line hidden
            return;
            case 13:
            this.EventsFromOP = ((System.Windows.Controls.TextBlock)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

