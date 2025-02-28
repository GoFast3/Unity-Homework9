using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using TMPro; // Add this for TextMeshPro support

public class CreateAndJoinRooms : MonoBehaviourPunCallbacks
{
    public TMP_InputField createInput; // Change to TMP_InputField
    public TMP_InputField joinInput; // Change to TMP_InputField


    public void CreateRoom()
    {
        Debug.Log("Creating Room: " + createInput.text);
        PhotonNetwork.CreateRoom(createInput.text);
    }

    public void JoinRoom()
    {
        Debug.Log("Joining Room: " + joinInput.text);
        PhotonNetwork.JoinRoom(joinInput.text);
    }

    public override void OnJoinedRoom()
    {
        Debug.Log("(CreAndJoinRoo OnJoinedRoom func) Current Room: " + PhotonNetwork.CurrentRoom.Name);
        Debug.Log("(CreAndJoinRoo OnJoinedRoom func) Players in Room: " + PhotonNetwork.CurrentRoom.PlayerCount);

        PhotonNetwork.LoadLevel("level-1");
    }
}