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
    }
}
