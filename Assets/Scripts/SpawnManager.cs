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
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public void Spawn()
    {
        Debug.Log("Attempting to spawn");
        if (PhotonNetwork.IsConnectedAndReady)
        {
            Debug.Log("Spawning...");
            OriginalXROrigin.SetActive(false);
            PhotonNetwork.Instantiate(GenericVRPlayerPrefab.name, spawnPosition, Quaternion.identity);
            Debug.Log("Spawned");

        }
        else
        {
            Debug.Log("Spawn failed. Photon network was not connecteed and ready.");
        }
    }
    
}
