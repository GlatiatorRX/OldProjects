using UnityEngine;
using System.Collections;

public class NextLevelScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
				if (Input.GetMouseButtonDown (0)){
						Debug.Log ("Pressed left click.");
				int i = Application.loadedLevel;
				Application.LoadLevel (i + 1);
		}
	}
}
