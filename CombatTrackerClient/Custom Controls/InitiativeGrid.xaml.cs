using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

namespace CombatTrackerClient
{
	public sealed partial class InitiativeGrid : UserControl
	{
		List<InitiativeButton> buttons;

		public InitiativeGrid()
		{
			buttons = new List<InitiativeButton>();
			this.InitializeComponent();
		}

		public void AddButton(InitiativeButton button)
		{
			buttons.Add(button);
			buttons.Sort();

			if(ButtonGrid.RowDefinitions.Count < buttons.Count)
			{
				RowDefinition rowDef = new RowDefinition();
				rowDef.Height = ButtonGrid.RowDefinitions.Count == 0 ? new GridLength(100) : new GridLength(50);
				ButtonGrid.RowDefinitions.Add(rowDef);
			}

			ButtonGrid.Children.Clear();

			for(int i = 0; i < buttons.Count; i++)
			{
				InitiativeButton b = buttons.ElementAt(i);
				Grid.SetRow(b, i);
				ButtonGrid.Children.Add(b);
			}
		}

		public void Next()
		{
			InitiativeButton but = ButtonGrid.Children.ElementAt(0) as InitiativeButton;
			but.InitiativeGrid_PointerExited(null, null);

			ButtonGrid.Children.RemoveAt(0);

			foreach(InitiativeButton b in ButtonGrid.Children)
			{
				Grid.SetRow(b, Grid.GetRow(b) - 1);
			}

			Grid.SetRow(but, ButtonGrid.RowDefinitions.Count - 1);
			ButtonGrid.Children.Add(but);
		}
	}
}
