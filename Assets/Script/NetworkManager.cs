using UnityEngine;
using System.Collections;
using System;
//using UnityEditorInternal;
using UnityEngine.SceneManagement;

public class NetworkManager : Photon.MonoBehaviour
{

    public Transform[] spawnPoint;
    public GameObject image;
    /*private float UpgradeSpawnRate;
    public UpgradeSpawner script;*/
    void OnGUI()
    {
        //GUI.Label(new Rect(10, 10, 100, 100), PhotonNetwork.connectionStateDetailed.ToString());
        //UpgradeSpawnRate = 10f;
    }

    // Use this for initialization
    void Start()
    {
        Screen.SetResolution(1680, 720, false);
        PhotonNetwork.autoJoinLobby = true;
        PhotonNetwork.ConnectUsingSettings("PoorFight 1.1");
    }


    void OnJoinedLobby()
    {
            if (StaticInfo.Lobby == "")
                PhotonNetwork.JoinRandomRoom();
            else
            {
                RoomOptions Ro = new RoomOptions();
                Ro.IsVisible = false;
                PhotonNetwork.JoinOrCreateRoom(StaticInfo.Lobby, Ro, TypedLobby.Default);
            }
    }

    //Ho fallito la funzione JoinRandomRoom...ovvero no stanza trovata
    void OnPhotonRandomJoinFailed()
    {
            PhotonNetwork.CreateRoom(null);
    }

    void OnJoinRoomFailed() 
    {
        SceneManager.LoadScene("Menu");
        SceneManager.UnloadScene("Game");
    }
    void OnJoinedRoom()
    {
        int tmp = new System.Random().Next(0, spawnPoint.Length);
        PhotonNetwork.Instantiate("Player", spawnPoint[tmp].position, spawnPoint[tmp].rotation, 0);
        image.active = false;
    }


}