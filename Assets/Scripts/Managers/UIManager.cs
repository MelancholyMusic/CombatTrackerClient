using UnityEngine;

public class Popup
{
	public static string Register = "UI/Popups/UI_Popup_Register";
}

public class UIManager : Singleton<UIManager>
{
	[SerializeField]
	private GameObject waiting;

	public void QueuePopup(string popup)
	{
		Instantiate(Resources.Load(popup));
	}

	public void Waiting(bool isOn)
	{
		waiting.SetActive(isOn);
	}
}
