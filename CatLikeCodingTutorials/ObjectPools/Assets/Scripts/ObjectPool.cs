using UnityEngine;
using System.Collections.Generic;

public class ObjectPool : MonoBehaviour {

    PooledObject prefab;
    List<PooledObject> availableObjects = new List<PooledObject>();

    /// <summary>
    /// Gets an object instance from the pool.
    /// If an instance cannot be found, one is created.
    /// </summary>
    /// <returns>Object from parent pool</returns>
	public PooledObject GetObject()
    {
        PooledObject obj;
        //Get the index of the last object in the pool
        int lastAvailableIndex = availableObjects.Count - 1;
        if (lastAvailableIndex >= 0)
        {
            //Removes last object in list.
            //We do not remove the first because shifting all objs in an ObjectPool is much more intensive.
            obj = availableObjects[lastAvailableIndex];
            availableObjects.RemoveAt(lastAvailableIndex);
            obj.gameObject.SetActive(true);
        }
        else
        {
            //When no objects are in the pool, create an object
            obj = Instantiate<PooledObject>(prefab);
            obj.transform.SetParent(transform, false);

            //Assigns the pool to return to when 'Destroyed'
            obj.Pool = this;
        }
        return obj;
    }

    /// <summary>
    /// Adds an object to this pool.
    /// </summary>
    /// <param name="obj">Object to be disabled and added to the pool.</param>
    public void AddObject (PooledObject obj)
    {
        obj.gameObject.SetActive(false);
        availableObjects.Add(obj);
    }

    /// <summary>
    /// Creates an ObjectPool for a PoolObject prefab.
    /// </summary>
    /// <param name="prefab">Prefab to specify the pool.</param>
    /// <returns>The newly created pool instance.</returns>
    public static ObjectPool GetPool(PooledObject prefab)
    {
        GameObject obj;
        ObjectPool pool;
        if(Application.isEditor)
        {
            //Unity editor recompilition will duplicate the pools because the poolInstancePrefab is not serialized.
            //So check if the gameobject already exists in the scene and grab that instance.
            obj = GameObject.Find(prefab.name + " Pool");
            if(obj)
            {
                pool = obj.GetComponent<ObjectPool>();
                if(pool)
                {
                    return pool;
                }
            }
        }

        //Create an ObjectPool instance for the prefab
        obj = new GameObject(prefab.name + " Pool");
        DontDestroyOnLoad(obj);
        pool = obj.AddComponent<ObjectPool>();
        pool.prefab = prefab;
        return pool;
    }
}
