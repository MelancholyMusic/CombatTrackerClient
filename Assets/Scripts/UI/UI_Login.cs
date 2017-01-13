using UnityEngine;
using UnityEngine.UI;

public class UI_Login : MonoBehaviour
{
	public InputField accountInput;
	public InputField passwordInput;

	public void BtnPressedRegister()
	{
		NetworkManager.Instance.WebAPIRegister(accountInput.text, passwordInput.text);
	}

	public void BtnPressedLogin(Button button)
	{
		button.enabled = false;
		NetworkManager.Instance.WebAPILogin(accountInput.text, passwordInput.text);
	}
}
