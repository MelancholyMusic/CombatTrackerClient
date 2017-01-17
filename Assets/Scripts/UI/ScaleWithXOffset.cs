using System;
using UnityEngine;
using UnityEngine.UI.Extensions;

public class ScaleWithXOffset : MonoBehaviour
{
    public RectTransform cardRect;
	public RectTransform glow;
    public RectTransform screen;
	public float maxScale = 1.0f;
	public float minScale = 0.8f;

    float screenWidth;
	float scale;
	float prevX;
    UnityEngine.UI.Image glowImage;
    bool IsGlowing;

	void Awake()
	{
        glowImage = glow.GetComponent<UnityEngine.UI.Image>();
        SetGlow(0);

        screenWidth = screen.rect.width / 2 - 50;
		prevX = cardRect.position.x - 1;
		scale = maxScale;
		cardRect.localScale = new Vector3(scale, scale);
	}

	void Update()
	{
        if(prevX != cardRect.position.x)
		{
			scale = (maxScale - minScale) + minScale * Mathf.Clamp(1 - Mathf.Abs((prevX - screenWidth / 2) / (screenWidth / 2)), minScale, maxScale);
			cardRect.localScale = new Vector3(scale, scale);
			prevX = cardRect.position.x;            
		}

        if (scale > maxScale*.95)
        {
            IsGlowing = true;
        }
        else
            IsGlowing = false;

        Glow();
	}

    private void Glow()
    {
        if (IsGlowing)
            SetGlow(1 * Time.deltaTime, true);
        else
            SetGlow(-3 * Time.deltaTime, true);
    }

    private void SetGlow(float alpha, bool relative = false)
    {
        if (!relative)
            glowImage.color = new Color(glowImage.color.r, glowImage.color.g, glowImage.color.b, alpha);
        else
            glowImage.color = new Color(glowImage.color.r, glowImage.color.g, glowImage.color.b, Mathf.Clamp(glowImage.color.a + alpha, 0, 1));

    }
}
