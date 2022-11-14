using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//whiteboard

public class Whiteboard1 : MonoBehaviour
{
    public Texture2D texture;
    public Vector2 textureSize = new Vector2(2048, 2048);

    void Starts()
    {
        var r = GetComponent<Renderer>();
        texture = new Texture2D((int)textureSize.x, (int)textureSize.y);
        r.material.mainTexture = texture;
    }
}