using UnityEngine;
using Photon.Pun;

public class PlayerSetup : MonoBehaviourPun
{
    private void Start()
    {
        if (!photonView.IsMine)
        {
            GetComponentInChildren<SpriteRenderer>().enabled = true; 
        }

        photonView.RPC("EnableSprite", RpcTarget.AllBuffered);
    }

    [PunRPC]
    void EnableSprite()
    {
        GetComponentInChildren<SpriteRenderer>().enabled = true;
    }
}
