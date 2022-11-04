using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun; 

public class SpawnManager : MonoBehaviour
{

    [SerializeField]  GameObject GenericVRPlayerPrefab;
    [SerializeField]  GameObject OriginalXROrigin;

    public Vector3 spawnPosition;
    // Start is called before the first frame update
    void Start()
    {
        if (PhotonNetwork.IsConnectedAndReady)
        {
            OriginalXROrigin.SetActive(false);
            PhotonNetwork.Instantiate(GenericVRPlayerPrefab.name, spawnPosition, Quaternion.identity);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
