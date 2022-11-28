using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using Photon.Pun;

public class PlayerNetworkSetup : MonoBehaviourPunCallbacks
{
    public GameObject LocalXRRigGameobject;

   // public Transform leftHand;
   // public Transform rightHand;
   // public Transform body;
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
        }
        else
        {
            //The player is remote
            LocalXRRigGameobject.SetActive(false);
        }
    }

}
