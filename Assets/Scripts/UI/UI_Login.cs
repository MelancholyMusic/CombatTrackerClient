using UnityEngine;
using UnityEngine.UI;

public class UI_Login : MonoBehaviour
{
	public InputField emailInput;
	public InputField passwordInput;

	public void BtnPressedRegister()
	{
		NetworkManager.Instance.WebAPIRegister(emailInput.text, passwordInput.text);
	}

	public void BtnPressedLogin()
	{
		NetworkManager.Instance.WebAPILogin(emailInput.text, passwordInput.text);
	}

	public void BtnPressedAttemptAuthorized()
	{
		NetworkManager.Instance.AuthorizationCheck();
	}
}
