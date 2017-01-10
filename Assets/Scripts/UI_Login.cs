using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Login : MonoBehaviour
{
	[Serializable]
	private class JwtAuthorizationResult
	{
		public string token_type;
		public string access_token;
		public string expires_in;

		public override string ToString()
		{
			return "token_type=" + token_type + " access_token=" + access_token + " expires_in=" + expires_in;
		}
	}

	private JwtAuthorizationResult jwtAuthorization;

	public InputField emailInput;
	public InputField passwordInput;

	public void BtnPressedLogin()
	{
		StartCoroutine(doWebAPILogin());
	}

	public void BtnPressedAttemptAuthorized()
	{
		StartCoroutine(doAttemptAuthorizedGet());
	}

	private IEnumerator doWebAPILogin()
	{
		Debug.Log("Attempting to login...");

		WWWForm loginParams = new WWWForm();
		loginParams.AddField("grant_type", "password");
		loginParams.AddField("username", emailInput.text);
		loginParams.AddField("password", passwordInput.text);
		loginParams.AddField("scope", "openid+email+name+profile+roles");

		WWW loginRequest = new WWW("https://localhost:44354/connect/token", loginParams);
		yield return loginRequest;

		if(!string.IsNullOrEmpty(loginRequest.error))
		{
			Debug.LogError("Login ERROR: " + loginRequest.error);
		}
		else
		{
			Debug.Log("Login Success: " + loginRequest.text);
			jwtAuthorization = JsonUtility.FromJson<JwtAuthorizationResult>(loginRequest.text);
		}
	}

	private IEnumerator doAttemptAuthorizedGet()
	{
		Debug.Log("Attempting to reach authorized-only endpoint...");

		Dictionary<string, string> headers = new Dictionary<string, string>();
		headers["Authorization"] = jwtAuthorization.token_type + " " + jwtAuthorization.access_token;

		WWW authorizedRequest = new WWW("https://localhost:44354/api/test", null, headers);
		yield return authorizedRequest;

		if(!string.IsNullOrEmpty(authorizedRequest.error))
		{
			Debug.LogError("~/api/test ERROR: " + authorizedRequest.error);
		}
		else
		{
			Debug.Log("~/api/test Success: " + authorizedRequest.text);
		}
	}
}
