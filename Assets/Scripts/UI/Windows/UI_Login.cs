using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Login : MonoBehaviour
{
	public InputField accountInput;
	public InputField passwordInput;
	public Button loginButton;
	public Button registerButton;

	public void BtnPressedRegister()
	{
		UIManager.Instance.QueuePopup(Popup.Register);
	}

	public void BtnPressedLogin()
	{
		MessageDispatcher.AddListener(MessageEventId.OnLogin, OnLoginComplete);

		EnableButtons(false);
		NetworkManager.Instance.WebAPILogin(accountInput.text, passwordInput.text);
	}

	private void EnableButtons(bool enable)
	{
		accountInput.interactable = enable;
		passwordInput.interactable = enable;
		loginButton.interactable = enable;
		registerButton.interactable = enable;
	}

	private void OnLoginComplete(Dictionary<string, object> paramDict)
	{
		MessageDispatcher.RemoveListener(MessageEventId.OnLogin, OnLoginComplete);

		EnableButtons(true);
		loginButton.interactable = false;
	}

	public void OnTextChanged()
	{
		loginButton.interactable = GlobalVars.EMAIL_REGEX.IsMatch(accountInput.text) && passwordInput.text.Length >= GlobalVars.PASSWORD_MIN_LENGTH;
	}
}
