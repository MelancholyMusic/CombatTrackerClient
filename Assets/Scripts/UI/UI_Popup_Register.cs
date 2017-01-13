using UnityEngine.UI;

public class UI_Popup_Register : UI_Popup
{
	public InputField emailInput;
	public InputField passwordInput;
	public InputField reenterPasswordInput;
	public Button signUpButton;

	public void BtnPressedSignUp()
	{
		emailInput.interactable = false;
		passwordInput.interactable = false;
		reenterPasswordInput.interactable = false;
		signUpButton.interactable = false;
	}

	public void OnTextChanged()
	{
		signUpButton.interactable = emailInput.text.Length > 0 && passwordInput.text.Length > 0 && reenterPasswordInput.text.Length > 0 && passwordInput.text == reenterPasswordInput.text;
	}
}
