using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviourPunCallbacks
{
    [SerializeField] private GameObject playerPrefab;

    void Start()
    {
        if (PhotonNetwork.IsConnectedAndReady && Player.LocalInstance == null)
        {
            PhotonNetwork.Instantiate(playerPrefab.name, new Vector3(0, 5, 0), Quaternion.identity);
        }
    }

    public override void OnJoinedRoom()
    {
        if (Player.LocalInstance == null)
        {
            PhotonNetwork.Instantiate(playerPrefab.name, new Vector3(0, 5, 0), Quaternion.identity);
        }
    }
}
