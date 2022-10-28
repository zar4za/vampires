using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class CustomRenderer : MonoBehaviour
{
    [SerializeField] private Material _material;
    [SerializeField] public int pixelDensity = 200;

    private void Start()
    {
        Vector2 aspectRatioData;
        if (Screen.height > Screen.width)
            aspectRatioData = new Vector2((float)Screen.width / Screen.height, 1);
        else
            aspectRatioData = new Vector2(1, (float)Screen.height / Screen.width);
        _material.SetVector("_AspectRatioMultiplier", aspectRatioData);
        _material.SetInt("_PixelDensity", pixelDensity);
    }

    private void OnRenderImage(RenderTexture source, RenderTexture destination)
    {
        Graphics.Blit(source, destination, _material);
    }
}
