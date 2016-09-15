using UnityEngine;
using System.Collections;

public class SpinningScript : MonoBehaviour {

	public float rotationSpeed;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 rotationVect = new Vector3 (0, 0, rotationSpeed);
		transform.Rotate (rotationVect);
	}
}
