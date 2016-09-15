using UnityEngine;
using System.Collections;

public class LeapMouseScript : MonoBehaviour {

	public Camera _mainCam; //Not required to be set. Defaults to camera tagged "MainCamera".
	public float buffer; // Buffer to position the mouse gui
	private float height;
	private float width;

	private GameObject palm;

	// Use this for initialization
	void Start () {
		_mainCam = (GameObject.Find("Main Camera")as GameObject).GetComponent(typeof(Camera)) as Camera;
		height = _mainCam.pixelHeight;
		width = _mainCam.pixelWidth;
		palm = (GameObject.Find ("Palm")as GameObject);
	}
	
	// Update is called once per frame
	void Update () {

		transform.position = new Vector3 (0.5f + palm.transform.position.x/(width/buffer), 0.5f + palm.transform.position.y/(height/buffer), 0.5f);
		print ("W: " + width + " H: " + height);

		if (transform.position.x > 1.0f) {
			transform.position = new Vector3 (1.0f, transform.position.y, transform.position.z);
		}
		else if (transform.position.x < 0.05f) {
			transform.position = new Vector3 (0.05f, transform.position.y, transform.position.z);
		}

		if (transform.position.y > 1.05f) {
			transform.position = new Vector3 (transform.position.x, 1.05f, transform.position.z);
		}
		else if (transform.position.y < 0.14f) {
			transform.position = new Vector3 (transform.position.x, 0.14f, transform.position.z);
		}
	}
}
