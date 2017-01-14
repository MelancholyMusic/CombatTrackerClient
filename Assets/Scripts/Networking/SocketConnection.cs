using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using WebSocketSharp;

public class SocketConnection : MonoBehaviour
{
	WebSocket socket;

	public SocketConnection(string url)
	{
		socket = new WebSocket(url);
		socket.OnClose   += OnClose;
		socket.OnError   += OnError;
		socket.OnMessage += OnMessage;
		socket.OnOpen    += OnOpen;
	}

	public void OnClose(object sender, CloseEventArgs args)
	{

	}

	private void OnError(object sender, ErrorEventArgs args)
	{

	}

	private void OnMessage(object sender, MessageEventArgs args)
	{

	}

	private void OnOpen(object sender, object args)
	{

	}
}
