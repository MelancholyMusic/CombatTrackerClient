using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UI_Login : MonoBehaviour
{
	public InputField accountInput;
	public InputField passwordInput;
	public Button loginButton;
	public Button registerButton;
	public Toggle rememberMeToggle;

	private void Start()
	{
		accountInput.text = PlayerPrefs.GetString("accountName");
		if(accountInput.text.Length > 0)
		{
			EventSystem.current.SetSelectedGameObject(passwordInput.gameObject);
			rememberMeToggle.isOn = true;
		}
	}

	private void OnDestroy()
	{
		if(rememberMeToggle.isOn)
			PlayerPrefs.SetString("accountName", accountInput.text);
		else
			PlayerPrefs.DeleteKey("accountName");

		PlayerPrefs.Save();
	}

	public void BtnPressedRegister()
	{
		UIManager.Instance.QueuePopup(Popup.Register);
	}

	public void BtnPressedLogin()
	{
		MessageDispatcher.AddListener(MessageEventId.OnLogin, OnLoginComplete);

		EnableButtons(false);
		UIManager.Instance.Waiting(true);

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

		UIManager.Instance.Waiting(false);

		if((bool)paramDict[MessageParamId.Success])
		{
			LoadingManager.Instance.LoadScene(CTScene.CHARACTER_SELECT);
		}
		else
		{
			EnableButtons(true);
			loginButton.interactable = false;
		}
	}

	public void OnTextChanged()
	{
		loginButton.interactable = GlobalVars.EMAIL_REGEX.IsMatch(accountInput.text) && passwordInput.text.Length >= GlobalVars.PASSWORD_MIN_LENGTH;
	}
}
