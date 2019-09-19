using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Stuff : PooledObject
{
    public Rigidbody Body { get; private set; }
    MeshRenderer[] meshRenderers;

    void Awake()
    {
        Body = GetComponent<Rigidbody>();
        meshRenderers = GetComponentsInChildren<MeshRenderer>();
    }

    /// <summary>
    /// Sets materials for all mesh renderers embedded in an object.
    /// </summary>
    /// <param name="m"></param>
    public void SetMaterial(Material m)
    {
        for (int i = 0; i < meshRenderers.Length; i++)
        {
            meshRenderers[i].material = m;
        }
    }

    /// <summary>
    /// Returns objects to pool when hit killzone.
    /// </summary>
    /// <param name="enteredCollider"> Collider(Trigger) that is entered. </param>
    void OnTriggerEnter (Collider enteredCollider)
    {
        if(enteredCollider.CompareTag("Kill Zone"))
        {
            ReturnToPool();
        }
    }

    void OnLevelWasLoaded()
    {
        //ReturnToPool();
    }
}