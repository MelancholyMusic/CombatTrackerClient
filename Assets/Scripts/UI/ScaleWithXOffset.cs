using UnityEngine;

public class ScaleWithXOffset : MonoBehaviour
{
    public RectTransform cardRect;
	public float screenWidth = Screen.width;
	public float maxScale = 1.0f;
	public float minScale = 0.5f;

	float xOffset;
	float height;
	float width;
	float scale;

    void Awake()
    {
        cardRect = gameObject.GetComponent<RectTransform>();
        xOffset = GetOffset();
        height = cardRect.rect.height;
        width = cardRect.rect.width;
        scale = maxScale;
    }

    void Update()
    {
        xOffset = GetOffset();
        scale = (screenWidth / 2) / ((screenWidth / 2) + xOffset);
        cardRect.rect.size.Set(width * scale, height * scale);
    }

    float GetOffset()
    {
        return System.Math.Abs(xOffset - (screenWidth / 2));
    }
}
