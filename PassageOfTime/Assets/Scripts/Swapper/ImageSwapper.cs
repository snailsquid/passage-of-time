using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ImageSwapper : MonoBehaviour
{
    Image image;

    public void Awake()
    {
        image = GetComponent<Image>();
    }

    public void Swap(Sprite sprite)
    {
        image.sprite = sprite;
    }
}
