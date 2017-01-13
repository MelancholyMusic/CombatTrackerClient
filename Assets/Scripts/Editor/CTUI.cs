using UnityEngine;
using System.Collections;
using UnityEditor;

public class CTUI : MonoBehaviour
{
	[MenuItem("GameObject/UI/CTButton", false, 0)]
	static void CreateCTButton()
	{
		GameObject button = Instantiate(Resources.Load("CTUI/CTButton")) as GameObject;
		button.name = "CTButton";
	}
}
