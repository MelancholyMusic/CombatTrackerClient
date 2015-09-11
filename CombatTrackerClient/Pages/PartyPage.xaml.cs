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
using System.Threading.Tasks;
using System.Net.Http;
using Newtonsoft.Json;
using CombatTrackerServer.Models;
using CombatTrackerClient.Custom_Controls;

namespace CombatTrackerClient
{
	public sealed partial class PartyPage : Page
	{
		public PartyPage()
		{
			this.InitializeComponent();
		}

		private void Page_Loaded(object sender, RoutedEventArgs e)
		{
			LoadParties();
		}

		private async void LoadParties()
		{
			HttpClient client = new HttpClient();
			string parties = await client.GetStringAsync("http://combattracker.azurewebsites.net/api/Parties/");
			List<Party> partyList = JsonConvert.DeserializeObject<List<Party>>(parties);

            StackParties.Children.Clear();

            foreach (Party party in partyList)
            {
                StackParties.Children.Add(new PartyListItem(party));
            }

            //Text.Text = parties + " xxxxxxxxxxxxxxxxx " + partyList.Count + partyList.ElementAt(1).Name;
		}
    }
}
