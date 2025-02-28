using UnityEngine;
using UnityEngine.SceneManagement;
using Photon.Pun;

public class GotoNextLevel : MonoBehaviourPunCallbacks
{
    [SerializeField] string triggeringTag;
    [SerializeField] string sceneName;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag(triggeringTag))
        {
            other.transform.position = Vector3.zero;

            if (PhotonNetwork.IsMasterClient)
            {
                PhotonNetwork.LoadLevel(sceneName);
            }
            else
            {
                photonView.RPC("RequestLoadScene", RpcTarget.MasterClient);
                PhotonNetwork.LoadLevel(sceneName);
            }
        }
    }

    [PunRPC]
    void RequestLoadScene()
    {
        if (PhotonNetwork.IsMasterClient)
        {
            PhotonNetwork.LoadLevel(sceneName);
        }
    }
    


}
