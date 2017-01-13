using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CTButton : Button
{
	protected override void Awake()
	{
		base.Awake();
		Image image = GetComponent<Image>();
		image.sprite = UIStyleManager.Instance.buttonImage;
	}
}
