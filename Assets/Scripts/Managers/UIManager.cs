using UnityEngine;

public class UIManager : Singleton<UIManager>
{
	public void PopupRegister()
	{
		Instantiate(Resources.Load("UI/UI_Popup_Register"));
	}
}
