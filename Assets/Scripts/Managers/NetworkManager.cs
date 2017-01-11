using UnityEngine;
using System.Collections;
using System;
using UnityEngine.Networking;

public class NetworkManager : Singleton<NetworkManager>
{
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

	private const string WEB_API_ENDPOINT = "https://localhost:44354"; //https://combattrackerserver20170105013416.azurewebsites.net/

	private UserAuthorization currentAuthorization;

	protected NetworkManager()
	{
	}

	public void WebAPIRegister(string email, string password)
	{
		StartCoroutine(DoWebAPIRegister(email, password));
	}

	private IEnumerator DoWebAPIRegister(string email, string password)
	{
		Debug.Log("Attempting to register new user...");

		WWWForm loginParams = new WWWForm();
		loginParams.AddField("email", email);
		loginParams.AddField("password", password);
		loginParams.AddField("confirmPassword", password);

		UnityWebRequest loginRequest = UnityWebRequest.Post(WEB_API_ENDPOINT + "/api/register", loginParams);
		loginRequest.SetRequestHeader("Content-Type", "application/x-www-form-urlencoded");
		yield return loginRequest.Send();

		string result = loginRequest.downloadHandler.text;
		if(loginRequest.responseCode != 200)
		{
			Debug.LogError("Register ERROR: " + result);
		}
		else
		{
			Debug.Log("Register Success: " + result);
		}
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

		UnityWebRequest loginRequest = UnityWebRequest.Post(WEB_API_ENDPOINT + "/connect/token", loginParams);
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

	public void AuthorizationCheck()
	{
		StartCoroutine(DoAuthorizationCheck());
	}

	private IEnumerator DoAuthorizationCheck()
	{
		Debug.Log("Attempting to reach authorized-only endpoint...");

		UnityWebRequest authorizedRequest = UnityWebRequest.Get(WEB_API_ENDPOINT + "/api/authtest");
		authorizedRequest.SetRequestHeader("Authorization", currentAuthorization.token_type + " " + currentAuthorization.access_token);
		yield return authorizedRequest.Send();

		if(authorizedRequest.responseCode != 200)
		{
			Debug.LogError("Authenticated ERROR: " + authorizedRequest.responseCode);
		}
		else
		{
			Debug.Log("Authenticated Success: " + authorizedRequest.downloadHandler.text);
		}
	}
}
