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
	public sealed partial class InitiativeButton : UserControl, IComparable<InitiativeButton>
	{
		public TextBlock NextButton
		{
			get { return Next; }
		}

		public InitiativeButton(string name, int initiative)
		{
			this.InitializeComponent();
			Name.Text = name;
			Initiative.Text = initiative.ToString();
		}

		public int CompareTo(InitiativeButton other)
		{
			return int.Parse(other.Initiative.Text).CompareTo(int.Parse(Initiative.Text));
		}

		private void InitiativeGrid_PointerEntered(object sender, PointerRoutedEventArgs e)
		{
			InitiativeGrid.Background = App.Colors.BUTTON_HOVER;
		}

		public void InitiativeGrid_PointerExited(object sender, PointerRoutedEventArgs e)
		{
			InitiativeGrid.Background = App.Colors.BUTTON_IDLE_LEFT;
		}
	}
}
