using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
public class SpawnPlayers : MonoBehaviourPunCallbacks
{
    public GameObject playerPrefab;

    public float minX;
    public float maxX;
    public float placeY;


    private void Start()
    {
        Quaternion rotation = Quaternion.Euler(0, 0, -90);
        Vector2 randomPosition = new Vector2(Random.Range(minX, maxX), placeY);
        PhotonNetwork.Instantiate(playerPrefab.name, randomPosition, rotation);

        
    }
}