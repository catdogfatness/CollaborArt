using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Whiteboard : MonoBehaviour
{
    public Texture2D texture;
    public Vector2 textureSize = new Vector2( 2048, 2048);

    public Color boardColor;
    void Start()
    {
        var r = GetComponent<Renderer>();
        texture = new Texture2D((int)textureSize.x, (int)textureSize.y);

        Color[] colors = new Color[(int)textureSize.x * (int)textureSize.y];
        for (int i = 0; i < colors.Length; i++)
        {
            colors[i] = boardColor;
        }

            texture.SetPixels(colors);
            texture.Apply();
        r.material.mainTexture = texture;
    }
    
}
