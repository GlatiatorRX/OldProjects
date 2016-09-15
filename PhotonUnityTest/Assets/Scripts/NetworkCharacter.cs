using UnityEngine;
using System.Collections;

public class NetworkCharacter : Photon.MonoBehaviour {

    Vector3 realPosition = Vector3.zero;
    Quaternion realRotation = Quaternion.identity;

    bool gotFirstUpdate = false;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	    if(photonView.isMine)
        {
            // Do nothing for now...
        }
        else
        {
            transform.position = Vector3.Lerp(transform.position, realPosition, 0.1f);
            transform.rotation = Quaternion.Lerp(transform.rotation, realRotation, 0.1f);
        }
	}

    public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
        if(stream.isWriting)
        {
            // Local Player --- Send data TO other players
            stream.SendNext(transform.position);
            stream.SendNext(transform.rotation);
        }
        else
        {
            // Remote Players --- Receive data FROM other players
            realPosition = (Vector3)stream.ReceiveNext();
            realRotation = (Quaternion)stream.ReceiveNext();

            if(!gotFirstUpdate)
            {
                transform.position = realPosition;
                transform.rotation = realRotation;
                gotFirstUpdate = true;
            }
        }
    }
}
