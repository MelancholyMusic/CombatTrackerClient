//http://timokorinth.de/creating-circular-progress-bar-wpf-silverlight/
using System.Linq;
using Windows.UI;
using Windows.UI.ViewManagement;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Input;

namespace CombatTrackerClient
{
    public sealed partial class MainPage : Page
    {
		GridLength _twoHundredPix = new GridLength(225, GridUnitType.Pixel);
		GridLength _fiftyPix = new GridLength(50, GridUnitType.Pixel);

		public static bool IsClicking = false;
		public static object BeingClicked;

		NavigationButton _currentlySelected;

		public MainPage()
		{
			ApplicationViewTitleBar titleBar = ApplicationView.GetForCurrentView().TitleBar;
			titleBar.BackgroundColor = Colors.Black;
			titleBar.ForegroundColor = Colors.White;
			titleBar.ButtonBackgroundColor = Colors.Black;
			titleBar.ButtonForegroundColor = Colors.White;
			titleBar.InactiveBackgroundColor = Colors.Black;
			titleBar.InactiveForegroundColor = App.Colors.BUTTON_CLICK.Color;
			titleBar.ButtonInactiveBackgroundColor = Colors.Black;
			titleBar.ButtonHoverBackgroundColor = App.Colors.BUTTON_IDLE_LEFT.Color;
			titleBar.ButtonHoverForegroundColor = Colors.White;

			InitializeComponent();
			Character.SetPageType(PageType.CHARACTER);
			Party.SetPageType(PageType.PARTY);
			Combat.SetPageType(PageType.COMBAT);
			SignIn.SetPageType(PageType.SIGN_IN);
			Settings.SetPageType(PageType.SETTINGS);

			ChangePage(Character);
		}

		private void ChangePage(NavigationButton navButton)
		{
			if(_currentlySelected != null)
				_currentlySelected.MakeActive(false);

			navButton.MakeActive(true);
			Content.Navigate(navButton.Type);
			_currentlySelected = navButton;
		}

		private void Navigation_Pressed(object sender, PointerRoutedEventArgs e)
		{
			IsClicking = true;
			NavigationButton button = sender as NavigationButton;
			if(button != null && button != BeingClicked)
			{
				BeingClicked = button;
				button.Clicked(true);
			}
        }

		private void Pointer_Released(object sender, PointerRoutedEventArgs e)
		{
			IsClicking = false;
			NavigationButton button = sender as NavigationButton;
			if(button != null && BeingClicked == button)
				ChangePage(button);
		}

		private void Expand_Released(object sender, PointerRoutedEventArgs e)
		{
			ColumnDefinition expandColumnDef = MainGrid.ColumnDefinitions.ElementAt(0);

			expandColumnDef.Width = expandColumnDef.Width == _twoHundredPix ? _fiftyPix : _twoHundredPix;
			Expand.Background = App.Colors.BUTTON_HOVER;
		}

		private void Expand_Pressed(object sender, PointerRoutedEventArgs e)
		{
			Expand.Background = App.Colors.BUTTON_CLICK;
		}

		private void Hover_Enter(object sender, PointerRoutedEventArgs e)
		{
			Expand.Background = App.Colors.BUTTON_HOVER;
		}

		private void Hover_Exit(object sender, PointerRoutedEventArgs e)
		{
			Expand.Background = App.Colors.BUTTON_IDLE_LEFT;
		}
	}

	public enum PageType
	{
		PARTY, CHARACTER, COMBAT, SIGN_IN, SETTINGS, EXPAND
	}
}
