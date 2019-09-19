using UnityEngine;

public class StuffSpawner : MonoBehaviour
{
    public FloatRange timeBetweenSpawns, scale, randomVelocity, angularVelocity;
    public float velocity;
    public Material stuffMaterial;
    public Stuff[] stuffPrefabs;

    float timeSinceLastSpawn;
    float currentSpawnDelay;
    
    void FixedUpdate()
    {
        //Timer to spawn next object
        timeSinceLastSpawn += Time.deltaTime;
        if (timeSinceLastSpawn >= currentSpawnDelay)
        {
            //Return spawn timer default value
            timeSinceLastSpawn -= currentSpawnDelay;

            //Add variation to spawn time
            currentSpawnDelay = timeBetweenSpawns.RandomInRange;

            SpawnStuff();
        }
    }

    /// <summary>
    /// Spawns stuff objects with random values
    /// </summary>
    void SpawnStuff()
    {
        //Select prefab to spawn
        Stuff prefab = stuffPrefabs[Random.Range(0, stuffPrefabs.Length)];

        //Get a pooled instance of the prefab
        Stuff spawn = prefab.GetPooledInstance<Stuff>();

        //Spawn stuff at location, with a random ranged scale, rotation, velocity, and angular velocity
        spawn.transform.localPosition = transform.position;
        spawn.transform.localScale = Vector3.one * scale.RandomInRange;
        spawn.transform.localRotation = Random.rotation;

        spawn.Body.velocity = transform.up * velocity +
            Random.onUnitSphere * randomVelocity.RandomInRange;
        spawn.Body.angularVelocity =
            Random.onUnitSphere * angularVelocity.RandomInRange;
        //Random.onUnitySphere is used to generate a random direction

        //Sets materials to all mesh renderers embedded in the object
        spawn.SetMaterial(stuffMaterial);
    }
}
