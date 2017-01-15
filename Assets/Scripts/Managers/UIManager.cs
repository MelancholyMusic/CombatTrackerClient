using UnityEngine;

public class Popup
{
	public static string Register = "UI/Popups/UI_Popup_Register";
}

public class UIManager : Singleton<UIManager>
{

	public void QueuePopup(string popup)
	{
		Instantiate(Resources.Load(popup));
	}
}
