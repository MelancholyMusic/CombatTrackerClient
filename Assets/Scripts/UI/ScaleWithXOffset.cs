using UnityEngine;

public class ScaleWithXOffset : MonoBehaviour
{
    public RectTransform cardRect;
    public RectTransform glow;
	public float screenWidth = Screen.width;
	public float maxScale = 1.0f;
	public float minScale = 0.8f;

	float height;
	float width;
	float scale;
    float prevX;

    void Awake()
    {
        prevX = cardRect.position.x - 1;
        height = cardRect.rect.height;
        width = cardRect.rect.width;
        scale = maxScale;
        cardRect.localScale = new Vector3(scale, scale);
    }

    void Update()
    {
        if (prevX != cardRect.position.x)
        {            
            scale = (maxScale - minScale) + minScale*Mathf.Clamp(1 - Mathf.Abs((prevX - screenWidth/2)/(screenWidth/2)), minScale, maxScale);
            cardRect.localScale = new Vector3(scale, scale);
            prevX = cardRect.position.x;
        }
    }

    float GetOffset()
    {
        return Mathf.Abs(prevX - (screenWidth));
    }
}
