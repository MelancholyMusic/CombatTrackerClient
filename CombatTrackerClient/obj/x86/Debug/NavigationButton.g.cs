﻿#pragma checksum "c:\users\mike\documents\visual studio 2015\Projects\UWCombatTracker\UWCombatTracker\NavigationButton.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "89A78BBEF4073BD27C1D08EDCB961B73"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace UWCombatTracker
{
    partial class NavigationButton : 
        global::Windows.UI.Xaml.Controls.UserControl, 
        global::Windows.UI.Xaml.Markup.IComponentConnector,
        global::Windows.UI.Xaml.Markup.IComponentConnector2
    {
        /// <summary>
        /// Connect()
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 14.0.0.0")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public void Connect(int connectionId, object target)
        {
            switch(connectionId)
            {
            case 1:
                {
                    this.NavigationGrid = (global::Windows.UI.Xaml.Controls.Grid)(target);
                    #line 12 "..\..\..\NavigationButton.xaml"
                    ((global::Windows.UI.Xaml.Controls.Grid)this.NavigationGrid).PointerEntered += this.NavigationGrid_PointerEntered;
                    #line 12 "..\..\..\NavigationButton.xaml"
                    ((global::Windows.UI.Xaml.Controls.Grid)this.NavigationGrid).PointerExited += this.NavigationGrid_PointerExited;
                    #line default
                }
                break;
            case 2:
                {
                    this.Text = (global::Windows.UI.Xaml.Controls.TextBlock)(target);
                }
                break;
            case 3:
                {
                    this.Symbol = (global::Windows.UI.Xaml.Controls.TextBlock)(target);
                }
                break;
            default:
                break;
            }
            this._contentLoaded = true;
        }

        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 14.0.0.0")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public global::Windows.UI.Xaml.Markup.IComponentConnector GetBindingConnector(int connectionId, object target)
        {
            global::Windows.UI.Xaml.Markup.IComponentConnector returnValue = null;
            return returnValue;
        }
    }
}

