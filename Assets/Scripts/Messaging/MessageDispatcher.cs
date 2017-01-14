using System.Collections.Generic;

public static class MessageDispatcher
{
	public delegate void EventListener(Dictionary<string, object> paramDict);

	private struct PendingEventListener
	{
		public EventListener eventListener;
		public string messageEventId;
	}

	private static Dictionary<string, EventListener> registeredListeners = new Dictionary<string, EventListener>();
	private static HashSet<PendingEventListener> listenersToAdd = new HashSet<PendingEventListener>();
	private static HashSet<PendingEventListener> listenersToRemove = new HashSet<PendingEventListener>();
	private static bool isDispatching = false;

	public static void AddListener(string eventId, EventListener listener)
	{
		if(isDispatching)
		{
			listenersToAdd.Add(new PendingEventListener { messageEventId = eventId, eventListener = listener });
		}
		else
		{
			if(registeredListeners.ContainsKey(eventId))
			{
				registeredListeners[eventId] += listener;
			}
			else
			{
				registeredListeners.Add(eventId, listener);
			}
		}
	}

	public static void RemoveListener(string eventId, EventListener listener)
	{
		if(isDispatching)
		{
			listenersToRemove.Add(new PendingEventListener { messageEventId = eventId, eventListener = listener });
		}
		else
		{
			if(registeredListeners.ContainsKey(eventId))
			{
				registeredListeners[eventId] -= listener;
			}
		}
	}

	public static void SendDictionaryMessage(string eventId, params object[] paramArray)
	{
		if(!registeredListeners.ContainsKey(eventId))
			return;

		isDispatching = true;

		Dictionary<string, object> paramDict = new Dictionary<string, object>();
		for(int i = 0; i < paramArray.Length; i++)
		{
			paramDict[(string)paramArray[i++]] = paramArray[i];
		}

		registeredListeners[eventId](paramDict);

		isDispatching = false;

		ProcessPendingLists();
	}

	private static void ProcessPendingLists()
	{
		foreach(PendingEventListener pel in listenersToAdd)
		{
			AddListener(pel.messageEventId, pel.eventListener);
		}

		foreach(PendingEventListener pel in listenersToRemove)
		{
			RemoveListener(pel.messageEventId, pel.eventListener);
		}

		listenersToAdd.Clear();
		listenersToRemove.Clear();
	}
}
