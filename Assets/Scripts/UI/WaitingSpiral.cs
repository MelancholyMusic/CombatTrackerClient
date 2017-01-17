using UnityEngine;
using UnityEngine.UI;

public class WaitingSpiral : MonoBehaviour
{
	public Image loadingImage;

	private float minimum = 0.0f;
	private float maximum = 1.0f;
	private float t = 0.0f;

	void Update()
	{
		loadingImage.fillAmount = Mathf.Lerp(minimum, maximum, t);
		t += Time.deltaTime * 2.0f;

		if(t > 1.0f)
		{
			loadingImage.fillClockwise = !loadingImage.fillClockwise;
			float temp = maximum;
			maximum = minimum;
			minimum = temp;
			t = 0.0f;
		}
	}
}
