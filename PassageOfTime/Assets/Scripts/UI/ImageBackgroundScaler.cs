using UnityEngine;
using UnityEngine.UI;

[ExecuteAlways]
[RequireComponent(typeof(Image))]
public class ImageCoverFit : MonoBehaviour
{
    private Image image;
    private RectTransform rectTransform;

    void OnEnable()
    {
        image = GetComponent<Image>();
        rectTransform = GetComponent<RectTransform>();
        UpdateFit();
    }

    void OnRectTransformDimensionsChange()
    {
        UpdateFit();
    }

    void OnValidate()
    {
        UpdateFit();
    }

    private void UpdateFit()
    {
        if (image == null || image.sprite == null || rectTransform == null)
            return;

        // Parent dimensions (like screen or container)
        RectTransform parent = rectTransform.parent as RectTransform;
        if (parent == null)
            return;

        float parentWidth = parent.rect.width;
        float parentHeight = parent.rect.height;
        float parentRatio = parentWidth / parentHeight;

        float imageRatio = (float)image.sprite.texture.width / image.sprite.texture.height;

        // Stretch either width or height to cover fully
        if (imageRatio > parentRatio)
        {
            // Wider: match height
            float height = parentHeight;
            float width = height * imageRatio;
            rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, height);
            rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, width);
        }
        else
        {
            // Taller: match width
            float width = parentWidth;
            float height = width / imageRatio;
            rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, width);
            rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, height);
        }

        // Optional: center the image
        rectTransform.anchoredPosition = Vector2.zero;
    }
}
