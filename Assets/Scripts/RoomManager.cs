using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class RoomManager : MonoBehaviourPunCallbacks
{
    [SerializeField] GameObject SpawnManager;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    #region UI Callback Methods
    public void JoinRandomRoom()
    {
        Debug.Log("Joining room...");
        PhotonNetwork.JoinRandomRoom();
    }
    #endregion

    #region Photon Callback Methods

    public override void OnJoinRandomFailed(short returnCode, string message)
    {
        Debug.Log(message);
        CreateAndJoinRoom();
    }

    public override void OnCreatedRoom()
    {
        Debug.Log("Room Created");
    }

    public override void OnJoinedRoom()
    {
        Debug.Log("The local player has joined " + PhotonNetwork.CurrentRoom.Name);
        SpawnManager.SetActive(true);
        SpawnManager.GetComponent<SpawnManager>().Spawn();
    }

    public override void OnPlayerEnteredRoom(Player newPlayer)
    {
        Debug.Log("Player count: " + PhotonNetwork.CurrentRoom.PlayerCount);
    }
    #endregion

    #region Private Methods
    private void CreateAndJoinRoom()
    {
        string roomName = "Room " + Random.Range(0, 10000);
        RoomOptions roomOptions = new RoomOptions();
        roomOptions.MaxPlayers = 4;
        PhotonNetwork.CreateRoom(roomName, roomOptions);
    }
    #endregion
}
