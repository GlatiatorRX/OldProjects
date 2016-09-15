using UnityEngine;
using System.Collections;
using Leap;

//**********************************************************
//	Custom Class MenuButton
// 	 Handles array of interactive Menu Buttons
// 	 - menuObject 	*panel to be stored
//   - grabbed 		*boolean if it has been selected
//**********************************************************
[System.Serializable]
public class MenuButton
{
	public GameObject menuObject;
	public bool grabbed = false;
}

public class MenuManager : MonoBehaviour 
{

	public 	MenuButton[] 	menuObjects; 	// Board Tiles - custom class
	private LeapManager 	_leapManager; 	// Leap motion controller - used for hand gestures
	private GameObject 		palm; 			// Motion Controlled Palm - used for positioning - *moved by hand controller script
	public GameObject 		blueRing; 		// Motion Controlled Palm - used for positioning - *moved by hand controller script
	public GameObject 		redRing; 		// Motion Controlled Palm - used for positioning - *moved by hand controller script
	private bool 			canGrab; 		// Grabbing mechanics - restriction to only allow one panel to be picked at a time


	// Use this for initialization
	void Start () ////////////////////////////// Start Function ///////////////////////////////////////////////////////////////////////// 
	{
		_leapManager = (GameObject.Find("LeapManager")as GameObject).GetComponent(typeof(LeapManager)) as LeapManager;
		palm = (GameObject.Find ("Palm")as GameObject);
		canGrab = true;
		redRing.renderer.enabled = false;
	}/////////////////////////////////////////// End Start Function /////////////////////////////////////////////////////////////////////
	
	// Update is called once per frame
	void Update () ///////////////////////////// Update Function ////////////////////////////////////////////////////////////////////////
	{
		//====================================== Mouse Rendering ========================================================================
		Hand primeHand = _leapManager.frontmostHand();
		if(LeapManager.isHandOpen (primeHand)){
			redRing.renderer.enabled = false;
			blueRing.renderer.enabled = true;
		}
		else{
			redRing.renderer.enabled = true;
			blueRing.renderer.enabled = false;
		}
		if (!primeHand.IsValid) {
			redRing.renderer.enabled = false;
			blueRing.renderer.enabled = false;
		}
		//====================================== End Mouse Rendering ====================================================================

		//====================================== Grabbing Logic for Tiles ===============================================================
		if (redRing.renderer.enabled) {

			for (int i = 0; i < menuObjects.Length; i++) {
				// Distance between palm and individual panels
				var distance = Vector3.Distance (menuObjects [i].menuObject.transform.position, palm.transform.position);

				// If you are within 1 unit, your hand is closed, and you can grab another panel - grab the panel and cannot pick another
				if (distance <= 10 && !LeapManager.isHandOpen (primeHand) && canGrab) {
					menuObjects [i].grabbed = true;
					canGrab = false;
				}
				// If your hand is open, drops panel, can grab another
				if (LeapManager.isHandOpen (primeHand) && menuObjects[i].grabbed) {
					menuObjects [i].grabbed = false;
					canGrab = true;
				}

				//*********************************** Level Logic ***********************************************************************
					if ((menuObjects [i].grabbed && menuObjects [i].menuObject.name == "ExitCollider") || Input.GetKey("escape")) {
						Application.Quit();
					}
					else if (menuObjects [i].grabbed && menuObjects [i].menuObject.name == "PlayCollider") {
						Application.LoadLevel("MatchingGame");
					}
				//*********************************** End Level Logic *******************************************************************

			}//End - tile for loop*
		}
		else { // If hand goes out of range, drop all objects
			for (int j = 0; j < menuObjects.Length; j++) {
				menuObjects [j].grabbed = false;
			}
			canGrab = true;
		}
		//====================================== End Grabbing Logic for Tiles ===========================================================

	}/////////////////////////////////////////// End Update Function ////////////////////////////////////////////////////////////////////
}