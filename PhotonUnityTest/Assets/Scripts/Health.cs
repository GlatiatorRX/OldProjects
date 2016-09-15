using UnityEngine;
using System.Collections;

public class Health : MonoBehaviour {

    public float hitPoints;

    float currentHitpoints;

	// Use this for initialization
	void Start () {
        currentHitpoints = hitPoints;
	}
	
    [RPC]
	public void TakeDamage(float amt)
    {
        currentHitpoints -= amt;

        if(currentHitpoints <= 0)
        {
            Die();
        }
    }

    public void Die()
    {
        if (GetComponent<PhotonView>().instantiationId == 0)
        {
            Destroy(gameObject);
        }
        else
        {
            if (PhotonNetwork.isMasterClient)
            {
                PhotonNetwork.Destroy(gameObject);
            }
        }
    }
}
