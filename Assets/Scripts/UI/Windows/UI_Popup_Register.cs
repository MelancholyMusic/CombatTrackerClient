using DG.Tweening;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UI_Popup_Register : UI_Popup
{
	public InputField emailInput;
	public GameObject emailErrorPanel;
	public GameObject emailTopGameObject;
	public InputField passwordInput;
	public GameObject passwordErrorPanel;
	public InputField reenterPasswordInput;
	public GameObject reenterPasswordErrorPanel;
	public Button signUpButton;

	private void Start()
	{
		EventSystem.current.SetSelectedGameObject(emailInput.gameObject);
	}

	public void EnableFields(bool enable)
	{
		emailInput.interactable = enable;
		passwordInput.interactable = enable;
		reenterPasswordInput.interactable = enable;
	}

	public void BtnPressedSignUp()
	{
		MessageDispatcher.AddListener(MessageEventId.OnRegister, OnRegisterComplete);
	
		EnableFields(false);
		signUpButton.interactable = false;
		NetworkManager.Instance.WebAPIRegister(emailInput.text, passwordInput.text, reenterPasswordInput.text);
	}

	public void OnTextChanged()
	{
		signUpButton.interactable = GlobalVars.EMAIL_REGEX.IsMatch(emailInput.text) &&
			GlobalVars.PASSWORD_REGEX.IsMatch(passwordInput.text) &&
			passwordInput.text == reenterPasswordInput.text;
	}

	public void OnEmailEndEdit()
	{
		if(emailInput.text.Length > 0)
			emailErrorPanel.SetActive(!GlobalVars.EMAIL_REGEX.IsMatch(emailInput.text));
	}

	public void OnPasswordEndEdit()
	{
		if(passwordInput.text.Length > 0)
			passwordErrorPanel.SetActive(!GlobalVars.PASSWORD_REGEX.IsMatch(passwordInput.text));
	}

	public void OnReenterPasswordEndEdit()
	{
		if(reenterPasswordInput.text.Length > 0)
			reenterPasswordErrorPanel.SetActive(reenterPasswordInput.text != passwordInput.text);
	}

	private void OnRegisterComplete(Dictionary<string, object> paramDict)
	{
		MessageDispatcher.RemoveListener(MessageEventId.OnRegister, OnRegisterComplete);

		if((bool)paramDict[MessageParamId.Success])
		{
			Close();
		}
		else
		{
			EnableFields(true);

			switch((string)paramDict[MessageParamId.ErrorCode])
			{
				case "DuplicateUserName":
					emailErrorPanel.SetActive(true);
					emailTopGameObject.transform.DOShakePosition(0.5f, new Vector3(50, 0), 10, 0);
					break;
				default:
					Debug.Log("Registration failed: " + paramDict[MessageParamId.ErrorCode]);
					break;
			}
		}
	}
}
