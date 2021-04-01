using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ColorMaker : MonoBehaviour
{
    public int RTColorizeSize = 4;
    public int RTAnalizeSize = 4;

    [SerializeField] private Camera _cameraOriginalArt;
    [SerializeField] private Camera _cameraRepairedArt;
    [SerializeField] private RawImage _originalArtDebug;
    [SerializeField] private RawImage _repairedArtDebug;

    private List<Color> _colors;
    public List<Color> Colors { get => _colors; }

    public void GetColors()
    {
        SetTextureSize(RTColorizeSize, _cameraOriginalArt, _originalArtDebug);
        _colors = GetColorsList(_cameraOriginalArt.targetTexture);
        SetTextureSize(RTAnalizeSize, _cameraOriginalArt, _originalArtDebug);
        SetTextureSize(RTAnalizeSize, _cameraRepairedArt, _repairedArtDebug);
    }    
    public float CompareRT()
    {
        List<Color> colorsOrig = GetColorsList(_cameraOriginalArt.targetTexture);
        List<Color> colorsRepaired = GetColorsList(_cameraRepairedArt.targetTexture);

        float result = 0.0f;
        float perc = 100.0f / colorsOrig.Count;

        for (int i = 0; i < colorsOrig.Count; i++)
        {
            if (IsEqualFloat(colorsOrig[i].r, colorsRepaired[i].r, 0.1f) &&
                IsEqualFloat(colorsOrig[i].g, colorsRepaired[i].g, 0.1f) &&
                IsEqualFloat(colorsOrig[i].b, colorsRepaired[i].b, 0.1f))
            {
                result += perc;
            }
        }
        return result;
    }

    private void SetTextureSize(int size, Camera camera, RawImage image)
    {
        if (camera.targetTexture != null)
        {
            camera.targetTexture.Release();
        }

        camera.targetTexture = new RenderTexture(size, size, 24);
        camera.targetTexture.filterMode = FilterMode.Point;
        image.texture = camera.targetTexture;
        camera.Render();
    }
    private List<Color> GetColorsList(RenderTexture rt)
    {
        List<Color> colors = new List<Color>();

        RenderTexture.active = rt;
        Texture2D tex = new Texture2D(RTColorizeSize, RTColorizeSize, TextureFormat.RGB24, false);
        tex.ReadPixels(new Rect(0, 0, RTColorizeSize, RTColorizeSize), 0, 0);
        RenderTexture.active = null;

        for (int i = 0; i < RTColorizeSize; i++)
        {
            for (int j = 0; j < RTColorizeSize; j++)
            {
                colors.Add(tex.GetPixel(i, j));
            }
        }
        DestroyImmediate(tex);

        return colors;
    }
    private bool IsEqualFloat(float float1, float float2, float delta = 0.00001f)
    {
        return (float1 + delta >= float2) && (float1 - delta <= float2);
    }

}
