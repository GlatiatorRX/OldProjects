using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fractal : MonoBehaviour {
    [Tooltip("Mesh to start with")]
    public Mesh[] meshes;
    [Tooltip("Material to start with")]
    public Material material;

    [Tooltip("The maximum layers of children allowed")]
    public int maxDepth;
    private int depth;

    [Tooltip("The size of the child compared to the parent")]
    public float childScale;

    public float spawnProbability;

    public float maxRotationSpeed;
    private float[] rotationSpeed;

    public float maxTwist;

    private static Vector3[] childDirections =
    {
        Vector3.up,
        Vector3.right,
        Vector3.left,
        Vector3.forward,
        Vector3.back,
        Vector3.down
    };

    private static Quaternion[] childOrentations =
    {
        Quaternion.identity,
        Quaternion.Euler(0f, 0f, -90f),
        Quaternion.Euler(0f, 0f, 90f),
        Quaternion.Euler(90f, 0f, 0f),
        Quaternion.Euler(-90f, 0f, 0f),
        Quaternion.Euler(0f, 180f, 0f)
    };

    private Material[,] materials;

    /// <summary>
    /// Called on the object's first rendered frame
    /// Called after Initialize() funtion
    /// </summary>
    public void Start()
    {
        // Create batched materials
        if(materials == null)
        {
            InitializeMaterials();
        }

        rotationSpeed = new float[] { Random.Range(-maxRotationSpeed, maxRotationSpeed), Random.Range(-maxRotationSpeed, maxRotationSpeed) };
        transform.Rotate(Random.Range(-maxTwist, maxTwist), 0f, 0f);

        //Apply mesh
        gameObject.AddComponent<MeshFilter>().mesh = 
            meshes[Random.Range(0, meshes.Length)];

        //Add batched material to renderer
        gameObject.AddComponent<MeshRenderer>().material = materials[depth, Random.Range(0, 2)];

        //Does not work with batching, creating new materials per object
        /*GetComponent<MeshRenderer>().material.color =
            Color.Lerp(Color.white, Color.green, (float)depth / maxDepth);*/

        //If child depth is not reached, keep going
        if (depth < maxDepth)
        {
            StartCoroutine(CreateChildren());
        }
    }

    /// <summary>
    /// Creates children on the fractal parent
    /// </summary>
    private IEnumerator CreateChildren()
    {
        for (int i = 0; i < childDirections.Length; i++)
        {
            if (Random.value < spawnProbability)
            {
                yield return new WaitForSeconds(Random.Range(0.1f, 0.5f));
                new GameObject("Fractal Child")
                        .AddComponent<Fractal>().Initialize(this, i);
            }
        }
    }

    /// <summary>
    /// Apply child variables based on parent,
    /// such as scale, rotation, depth, and parent transform
    /// </summary>
    /// <param name="parent">Fractal GameObject this child is under</param>
    /// <param name="childIndex">Index of direction and orientation</param>
    private void Initialize(Fractal parent, int childIndex)
    {
        meshes = parent.meshes;
        materials = parent.materials;
        material = parent.material;
        maxDepth = parent.maxDepth;
        depth = parent.depth + 1;
        childScale = parent.childScale;
        spawnProbability = parent.spawnProbability;
        maxRotationSpeed = parent.maxRotationSpeed;
        maxTwist = parent.maxTwist;
        transform.parent = parent.transform;

        transform.localScale = Vector3.one * childScale;
        transform.localPosition = childDirections[childIndex] * (0.5f + 0.5f * childScale);
        transform.localRotation = childOrentations[childIndex];
    }

    /// <summary>
    /// Creates batched materials
    /// </summary>
    private void InitializeMaterials()
    {
        materials = new Material[maxDepth + 1, 2];
        for(int i = 0; i <= maxDepth; i++)
        {
            //t is for tint
            //float t = i / (maxDepth - 1f);
            float t = i / (maxDepth - 1f);
            //t *= t;
            materials[i, 0] = new Material(material);
            materials[i, 0].color = Color.Lerp(Color.white, Color.blue, t);
            materials[i, 1] = new Material(material);
            materials[i, 1].color = Color.Lerp(Color.white, Color.green, t);
        }

        //Tip colors
        //materials[maxDepth, 0].color = Color.green;
        //materials[maxDepth, 1].color = Color.red;
    }

    private void Update()
    {
        if (depth == 0)
        {
            transform.Rotate(0f, rotationSpeed[0] * Time.deltaTime, rotationSpeed[1] * Time.deltaTime);
        }
        else
        {
            transform.Rotate(0f, rotationSpeed[0] * Time.deltaTime, 0f);
        }
    }
}
