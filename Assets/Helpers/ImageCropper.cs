using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImageCropper 
{
    // Start is called before the first frame update
    public static Texture2D RoundCrop(Texture2D sourceTexture)
    {
        int width;
        int height;
        int center;// = (sourceTexture.width < sourceTexture.height) ? (sourceTexture.width) : (sourceTexture.height);
        if (sourceTexture.width > sourceTexture.height)
        {
            center = sourceTexture.height;
        }
        else
        {
            center = sourceTexture.width;
            //sourceTexture.
        }
        width = center;
        height = center;
        if (sourceTexture.width == sourceTexture.height)
        {
            width = sourceTexture.width;
            height = sourceTexture.height;
        }
        float radius = (width < height) ? (width / 2f) : (height / 2f);
        float centerX = width / 2f;
        float centerY = height / 2f;
        Vector2 centerVector = new Vector2(centerX, centerY);
        // pixels are laid out left to right, bottom to top (i.e. row after row)
        Color[] colorArray = sourceTexture.GetPixels(0, 0, width, height);
        Color[] croppedColorArray = new Color[width * height];
        for (int row = 0; row < height; row++)
        {
            for (int column = 0; column < width; column++)
            {
                int colorIndex = (row * width) + column;
                float pointDistance = Vector2.Distance(new Vector2(column, row), centerVector);
                if (pointDistance < radius)
                {
                    croppedColorArray[colorIndex] = colorArray[colorIndex];
                }
                else
                {
                    croppedColorArray[colorIndex] = Color.clear;
                }
            }
        }
        Texture2D croppedTexture = new Texture2D(width, height);
        croppedTexture.SetPixels(croppedColorArray);
        croppedTexture.Apply();
        return croppedTexture;
    }
}
