using UnityEngine;
using UnityEngine.UI;

public class UI_ScaleWithXOffset : MonoBehaviour
{

    public RectTransform cardRect;
    float xOffset, height, width, scale;
    public float screenWidth = 1920f, maxScale = 1.0f, minScale = 0.5f;

    void Awake()
    {
        cardRect = gameObject.GetComponent<RectTransform>();
        xOffset = GetOffset();
        height = cardRect.rect.height;
        width = cardRect.rect.width;
        scale = maxScale;
    }

    // Update is called once per frame
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
