using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class Whiteboard : MonoBehaviour
{
    public Texture2D texture;
    public Vector2 textureSize = new Vector2( 2048, 2048);

    public Color boardColor;
    private PhotonView photonview;

    void Start()
    {
        photonview = GetComponent<PhotonView>();

       if(PhotonNetwork.IsConnected)
       {
            photonview.RPC("WhiteboardSetup", RpcTarget.AllBuffered,boardColor);
       }
       else
       {
              WhiteboardSetup(boardColor);
       }
        
    }


    [PunRPC]
    void WhiteboardSetup(Color boardColor)
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
