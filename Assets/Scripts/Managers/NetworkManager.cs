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

	private string WebApiEndpoint
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

	public void WebAPIRegister(string email, string password, string reenterPassword)
	{
		StartCoroutine(DoWebAPIRegister(email, password, reenterPassword));
	}

	private IEnumerator DoWebAPIRegister(string email, string password, string reenterPassword)
	{
		WWWForm registerParams = new WWWForm();
		registerParams.AddField("email", email);
		registerParams.AddField("password", password);
		registerParams.AddField("confirmPassword", reenterPassword);

		UnityWebRequest registerRequest = UnityWebRequest.Post(WebApiEndpoint + "/api/register", registerParams);
		registerRequest.SetRequestHeader("Content-Type", "application/x-www-form-urlencoded");
		yield return registerRequest.Send();

		MessageDispatcher.SendDictionaryMessage(MessageEventId.OnRegister, MessageParamId.Success, registerRequest.responseCode == 200, MessageParamId.ErrorCode, registerRequest.downloadHandler.text);
	}

	public void WebAPILogin(string email, string password)
	{
		StartCoroutine(DoWebAPILogin(email, password));
	}

	private IEnumerator DoWebAPILogin(string email, string password)
	{
		WWWForm loginParams = new WWWForm();
		loginParams.AddField("grant_type", "password");
		loginParams.AddField("username", email);
		loginParams.AddField("password", password);
		loginParams.AddField("scope", "openid+email+name+profile+roles");

		UnityWebRequest loginRequest = UnityWebRequest.Post(WebApiEndpoint + "/connect/token", loginParams);
		loginRequest.SetRequestHeader("Content-Type", "application/x-www-form-urlencoded");
		yield return loginRequest.Send();

		MessageDispatcher.SendDictionaryMessage(MessageEventId.OnLogin, MessageParamId.Success, loginRequest.responseCode == 200, MessageParamId.ErrorCode, loginRequest.downloadHandler.text);
	}

	public void WebAPIRetrievePlayerData()
	{
		StartCoroutine(DoWebAPIRetrievePlayerData());
	}

	private IEnumerator DoWebAPIRetrievePlayerData()
	{
		UnityWebRequest loginRequest = UnityWebRequest.Get(WebApiEndpoint + "/");
		loginRequest.SetRequestHeader("Authorization", currentAuthorization.token_type + " " + currentAuthorization.access_token);
		yield return loginRequest.Send();
	}
}
