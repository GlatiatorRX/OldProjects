using UnityEngine;

[System.Serializable]
public struct FloatRange {
    
    public float min, max;

    /// <summary>
    /// Returns a random number between the supplied max and minimum in the inspector.
    /// </summary>
    public float RandomInRange
    {
        get
        {
            return Random.Range(min, max);
        }
    }
}
