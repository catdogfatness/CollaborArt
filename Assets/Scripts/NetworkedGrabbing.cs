using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;


public class NetworkedGrabbing : MonoBehaviourPunCallbacks, IPunOwnershipCallbacks
{
    PhotonView m_photonView;
    Rigidbody rb;
    // Start is called before the first frame update
    bool isBeingHeld = false;

    private void Awake()
    {
        m_photonView = GetComponent<PhotonView>(); 
    }

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if(isBeingHeld)
        {
            rb.isKinematic = true;
            gameObject.layer = 6;
        }
        else
        {
            rb.isKinematic = false;
        }
            
    }

    private void TransferOwnership()
    {
        m_photonView.RequestOwnership();
    }

    public void OnSelectEntered()
    {
        Debug.Log("Grabbed");
        m_photonView.RPC("StartNetworkGrabbing", RpcTarget.AllBuffered);
        if (m_photonView.Owner == PhotonNetwork.LocalPlayer)
        {
            Debug.Log("Do not request Ownership. Already mine");
        }
        else
        {
            TransferOwnership();
        }
    }

    public void OnSelectedExited()
    {
        Debug.Log("Realeased");
        m_photonView.RPC("StopNetworkGrabbing", RpcTarget.AllBuffered);
    }

    public void OnOwnershipRequest(PhotonView targetView, Player requestingPlayer)
    {
        if(targetView != m_photonView)
        {
            return;
        }
        Debug.Log("Ownership Requested for: " + targetView.name + " from " + requestingPlayer.NickName);
        m_photonView.TransferOwnership(requestingPlayer);
    }

    public void OnOwnershipTransfered(PhotonView targetView, Player previousOwner)
    {
        Debug.Log("OnOwnership Transferred to " + targetView.name + " from " + previousOwner.NickName);
    }

    public void OnOwnershipTransferFailed(PhotonView targetView, Player senderOfFailedRequest)
    {
        throw new System.NotImplementedException();
    }

    [PunRPC]
    public void StartNetworkGrabbing()
    {
        isBeingHeld = true;

    }

    [PunRPC]
    public void StopNetworkGrabbing()
    {
        isBeingHeld = false;
    }

}
