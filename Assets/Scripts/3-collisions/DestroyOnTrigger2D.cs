using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class DestroyOnTrigger2D : MonoBehaviourPun
{
    [Tooltip("Every object tagged with this tag will trigger the destruction of this object")]
    [SerializeField] string triggeringTag;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == triggeringTag && enabled)
        {
            // קורא לפונקציה שתהרוס את שני האובייקטים אצל כל השחקנים ברשת
            photonView.RPC("DestroyObjects", RpcTarget.All, other.gameObject.GetComponent<PhotonView>().ViewID);
        }
    }

    [PunRPC]
    private void DestroyObjects(int otherObjectID)
    {
        if (PhotonView.Find(otherObjectID) != null)
        {
            Destroy(PhotonView.Find(otherObjectID).gameObject);
        }

        Destroy(this.gameObject);
    }
}
