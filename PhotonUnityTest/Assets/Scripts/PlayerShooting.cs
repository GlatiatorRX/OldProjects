using UnityEngine;
using System.Collections;

public class PlayerShooting : MonoBehaviour {

    public float damage = 25f;
    public float fireRate = 0.5f;
    float cooldown = 0f;

	// Update is called once per frame
	void Update () {
        cooldown -= Time.deltaTime;

	    if(Input.GetMouseButton(0))
        {
            Fire();
        }
	}

    void Fire()
    {
        if(cooldown > 0)
        {
            return;
        }

        Debug.Log("Fire");

        Ray ray = new Ray(Camera.main.transform.position, Camera.main.transform.forward);
        RaycastHit hitInfo;

        hitInfo = FindClosestHitInfo(ray);

        if(hitInfo.transform != null)
        {
            Health h = hitInfo.transform.GetComponent<Health>();

            if(h != null)
            {
                Debug.Log("Damaged Object");
                // RPC call - network call for all players
                h.GetComponent<PhotonView>().RPC("TakeDamage", PhotonTargets.AllBuffered, damage);
                //h.TakeDamage(damage);
            }
        }

        cooldown = fireRate;
    }

    RaycastHit FindClosestHitInfo(Ray ray)
    {
        RaycastHit[] hits = Physics.RaycastAll(ray);

        RaycastHit closestHit = new RaycastHit();
        float distance = 0f;

        foreach(RaycastHit hit in hits)
        {
            if(hit.transform != this.transform && (closestHit.transform == null || hit.distance < distance))
            {
                // We have hit:
                // - not us
                // - the first thing we hit
                // - or, an object closer than the previous

                closestHit = hit;
                distance = hit.distance;
            }
        }

        //closestHit is either null or has the closest object we hit

        return closestHit;
    }
}
