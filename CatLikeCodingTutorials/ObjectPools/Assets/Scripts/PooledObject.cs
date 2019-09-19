using UnityEngine;

public class PooledObject : MonoBehaviour {

    public ObjectPool Pool { get; set; }

    [System.NonSerialized]
    ObjectPool poolInstanceForPrefab;

    /// <summary>
    /// Recycles PoolObject back to parent pool.
    /// If PoolObject no longer exists, delete the object from memory.
    /// </summary>
    public void ReturnToPool()
    {
        if (Pool)
        {
            //Add to existing pool
            Pool.AddObject(this);
        }
        else
        {
            //Delete from memory
            Destroy(gameObject);
        }
    }

    /// <summary>
    /// Returns the instance of an ObjectPool of type 'T'.
    /// </summary>
    /// <typeparam name="T">Type of the ObjectPool objects.</typeparam>
    /// <returns>Pooled instance of type 'T'.</returns>
    public T GetPooledInstance<T>() where T : PooledObject
    {
        if(!poolInstanceForPrefab)
        {
            poolInstanceForPrefab = ObjectPool.GetPool(this);
        }
        return (T)poolInstanceForPrefab.GetObject();
    }
}
