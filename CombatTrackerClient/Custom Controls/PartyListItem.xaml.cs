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

namespace CombatTrackerClient.Custom_Controls
{
	public sealed partial class PartyListItem : UserControl
	{
		public int id;

		public PartyListItem(Party p)
		{
			this.InitializeComponent();

			id = p.Id;

			TextID.Text = p.Id.ToString();
			TextName.Text = p.Name;
			TextPlayers.Text = p.JoinedPlayers + "/" + p.MaxPlayers;

			if(p.Locked)
			{
				Symbol.Visibility = Visibility.Collapsed;
			}
		}
	}
}
