using UnityEngine;
using UnityEngine.UI;

public class UI_Login : MonoBehaviour
{
	public InputField accountInput;
	public InputField passwordInput;
	public Button loginButton;

	public void BtnPressedRegister()
	{
		UIManager.Instance.QueuePopup(Popup.Register);
	}

	public void BtnPressedLogin()
	{
		accountInput.interactable = false;
		passwordInput.interactable = false;
		loginButton.interactable = false;
		NetworkManager.Instance.WebAPILogin(accountInput.text, passwordInput.text);
	}

	public void OnTextChanged()
	{
		loginButton.interactable = accountInput.text.Length > 0 && passwordInput.text.Length > 0;
	}
}
