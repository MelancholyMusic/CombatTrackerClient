using UnityEngine;
using System.Collections;
using System;
using UnityEngine.Networking;

public class NetworkManager : Singleton<NetworkManager>
{
	public enum ServerTier
	{
		LOCAL,
		DEV
	}

	[Serializable]
	private class UserAuthorization
	{
		public string token_type   = "";
		public string access_token = "";
		public string expires_in   = "";

		public override string ToString()
		{
			return "token_type=" + token_type + " access_token=" + access_token + " expires_in=" + expires_in;
		}
	}

	public ServerTier serverTier;

	private UserAuthorization currentAuthorization = new UserAuthorization();

	string WebApiEndpoint
	{
		get
		{
			switch(serverTier)
			{
				case ServerTier.LOCAL:
					return "https://localhost:44354";
				case ServerTier.DEV:
				default:
					return "https://combattrackerserver20170105013416.azurewebsites.net/";
			}
		}
	}

	protected NetworkManager()
	{
	}

	public void WebAPIRegister(string email, string password, string reenterPassword)
	{
		StartCoroutine(DoWebAPIRegister(email, password, reenterPassword));
	}

	private IEnumerator DoWebAPIRegister(string email, string password, string reenterPassword)
	{
		Debug.Log("Attempting to register new user...");

		WWWForm loginParams = new WWWForm();
		loginParams.AddField("email", email);
		loginParams.AddField("password", password);
		loginParams.AddField("confirmPassword", reenterPassword);

		UnityWebRequest loginRequest = UnityWebRequest.Post(WebApiEndpoint + "/api/register", loginParams);
		loginRequest.SetRequestHeader("Content-Type", "application/x-www-form-urlencoded");
		yield return loginRequest.Send();

		MessageDispatcher.SendDictionaryMessage(MessageEventId.OnRegister, MessageParamId.Success, loginRequest.responseCode == 200, MessageParamId.ErrorCode, loginRequest.downloadHandler.text);
	}

	public void WebAPILogin(string email, string password)
	{
		StartCoroutine(DoWebAPILogin(email, password));
	}

	private IEnumerator DoWebAPILogin(string email, string password)
	{
		Debug.Log("Attempting to login...");

		WWWForm loginParams = new WWWForm();
		loginParams.AddField("grant_type", "password");
		loginParams.AddField("username", email);
		loginParams.AddField("password", password);
		loginParams.AddField("scope", "openid+email+name+profile+roles");

		UnityWebRequest loginRequest = UnityWebRequest.Post(WebApiEndpoint + "/connect/token", loginParams);
		loginRequest.SetRequestHeader("Content-Type", "application/x-www-form-urlencoded");
		yield return loginRequest.Send();

		string result = loginRequest.downloadHandler.text;
		if(loginRequest.responseCode != 200)
		{
			Debug.LogError("Login ERROR: " + result);
		}
		else
		{
			Debug.Log("Login Success: " + result);
			currentAuthorization = JsonUtility.FromJson<UserAuthorization>(result);
		}
	}
}
