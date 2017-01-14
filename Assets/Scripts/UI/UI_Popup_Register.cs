using System.Collections.Generic;
using System.Text.RegularExpressions;
using UnityEngine;
using UnityEngine.UI;

public class UI_Popup_Register : UI_Popup
{
	public InputField emailInput;
	public InputField passwordInput;
	public InputField reenterPasswordInput;
	public Button signUpButton;

	Regex emailRegex = new Regex(@"\A(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?)\Z");

	private void EnableFields(bool enable)
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

	public void OnRegisterComplete(Dictionary<string, object> paramDict)
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
				case "DuplicateUserName": break;
				case "PasswordRequiresNonAlphanumeric": break;
			}
		}
	}

	public void OnTextChanged()
	{
		signUpButton.interactable = emailRegex.IsMatch(emailInput.text) && passwordInput.text.Length > 6 && 
			reenterPasswordInput.text.Length > 6 && passwordInput.text == reenterPasswordInput.text;
	}
}
