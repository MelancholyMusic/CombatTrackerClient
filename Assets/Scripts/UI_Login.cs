using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class UI_Login : MonoBehaviour
{
	public InputField emailInput;
	public InputField passwordInput;

	public void BtnPressedLogin()
	{
		StartCoroutine(doWebAPILogin());
	}

	private IEnumerator doWebAPILogin()
	{
		Debug.Log("Attempting to login...");

		WWWForm loginParams = new WWWForm();
		loginParams.AddField("email", emailInput.text);
		loginParams.AddField("password", passwordInput.text);

		WWW loginRequest = new WWW("https://combattrackerserver20170105013416.azurewebsites.net/Account/Login", loginParams);
		yield return loginRequest;

		if(!string.IsNullOrEmpty(loginRequest.error))
		{
			Debug.LogError("Login ERROR: " + loginRequest.error);
		}
		else
		{
			Debug.Log("Login Success: " + loginRequest.text);
		}
	}
}
