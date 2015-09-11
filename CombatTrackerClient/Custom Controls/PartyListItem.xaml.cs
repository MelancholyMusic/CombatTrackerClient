using CombatTrackerServer.Models;
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

// The User Control item template is documented at http://go.microsoft.com/fwlink/?LinkId=234236

namespace CombatTrackerClient.Custom_Controls
{
    public sealed partial class PartyListItem : UserControl
    {
        public Party party; //maybe unneccessary?
        public bool IsActive { get; private set; }

        public PartyListItem(Party p)
        {
            this.InitializeComponent();

            party = p;

            TextID.Text = party.Id.ToString();
            TextName.Text = party.Name;
            TextPlayers.Text = "0/4"; //party.Players + "/" + party.MaxPlayers;

            if (false)//(!party.Private)
            {
                Symbol.Visibility = Visibility.Collapsed;
            }
        }

        private void NavigationGrid_PointerEntered(object sender, PointerRoutedEventArgs e)
        {
            if (!IsActive && !MainPage.IsClicking)
                NavigationGrid.Background = App.Colors.BUTTON_HOVER;
            else if (MainPage.IsClicking && MainPage.BeingClicked == this)
                NavigationGrid.Background = App.Colors.BUTTON_CLICK;
        }

        private void NavigationGrid_PointerExited(object sender, PointerRoutedEventArgs e)
        {
            if (!IsActive)
                NavigationGrid.Background = App.Colors.BUTTON_IDLE_LEFT;
        }

        public void MakeActive(bool isActive)
        {
            NavigationGrid.Background = isActive ? App.Colors.BUTTON_SELECTED : App.Colors.BUTTON_IDLE_LEFT;
            IsActive = isActive;
        }

        private void NavigationGrid_Tapped(object sender, TappedRoutedEventArgs e)
        {
            MakeActive(true);
        }
    }
}
