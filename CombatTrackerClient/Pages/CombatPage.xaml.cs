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
	public sealed partial class CombatPage : Page
	{
		public CombatPage()
		{
			this.InitializeComponent();
		}

		protected override void OnNavigatedTo(NavigationEventArgs e)
		{
			base.OnNavigatedTo(e);
			InitiativeButton enderButton = new InitiativeButton("Ender", 17);
			InitiativeButton vanlithButton = new InitiativeButton("Vanlith", 7);
			InitiativeButton gambitButton = new InitiativeButton("Gambit", 13);

			enderButton.NextButton.PointerPressed += NextButtonPressed;
			enderButton.NextButton.PointerReleased += NextButtonReleased;

			vanlithButton.NextButton.PointerPressed += NextButtonPressed;
			vanlithButton.NextButton.PointerReleased += NextButtonReleased;

			gambitButton.NextButton.PointerPressed += NextButtonPressed;
			gambitButton.NextButton.PointerReleased += NextButtonReleased;

			ButtonGrid.AddButton(enderButton);
			ButtonGrid.AddButton(vanlithButton);
			ButtonGrid.AddButton(gambitButton);
		}

		private void NextButtonPressed(object sender, PointerRoutedEventArgs e)
		{

		}

		private void NextButtonReleased(object sender, PointerRoutedEventArgs e)
		{
			ButtonGrid.Next();
		}
	}
}
