using UnityEngine;

public abstract class UI_Popup : MonoBehaviour
{
	public void Close()
	{
		Destroy(gameObject);
	}
}
