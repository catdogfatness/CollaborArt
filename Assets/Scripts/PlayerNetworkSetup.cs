using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using Photon.Pun;

public class PlayerNetworkSetup : MonoBehaviourPunCallbacks
{
    public GameObject LocalXRRigGameobject;
    public GameObject AvatarHead;
    public GameObject AvatarBody;

    private new PhotonView photonView;

    // Start is called before the first frame update
    void Start()
    {
        photonView = GetComponent<PhotonView>();
        //makes sure that there is only one active xr rig per player game in a virtual room
        if(photonView.IsMine)
        {
            //The player is local
            LocalXRRigGameobject.SetActive(true);
            SetLayerRecursively(AvatarBody, 7);
            SetLayerRecursively(AvatarHead, 6);
        }
        else
        {
            //The player is remote
            LocalXRRigGameobject.SetActive(false);
            SetLayerRecursively(AvatarBody, 0);
            SetLayerRecursively(AvatarHead, 0);
        }
    }

    void SetLayerRecursively(GameObject go, int layerNumber)
    {
        if (go == null) return;
        foreach (Transform trans in go.GetComponentsInChildren<Transform>(true))
        {
            trans.gameObject.layer = layerNumber;
        }
    }

}
