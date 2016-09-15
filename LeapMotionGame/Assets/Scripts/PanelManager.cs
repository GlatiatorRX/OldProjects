using UnityEngine;
using System.Collections;
using Leap;

//**********************************************************
//	Custom Class Tile
// 	 Handles array of interactive panels
// 	 - tileObject 	*panel to be stored
//	 - animal 		*renderer for the sprite, holds sprite texture and color overlay/alpha
//
//	 ~~~ Non-tweakable in inspector ~~~
//   - grabbed 		*boolean if it is selected
//   - canGrab		*boolean if it can be selected, 
//					default true, set to false when picked up or not equal to example
//   - mustGrab		*boolean if sprite is equal to example sprite, used to increase total number to find
//
//**********************************************************
[System.Serializable]
public class Tile
{
	public GameObject tileObject;
	public SpriteRenderer animal;
	//[HideInInspector] - Hides var below
	[HideInInspector] public bool grabbed = false;
	[HideInInspector] public bool canGrab = true;
	[HideInInspector] public bool mustGrab = false;
}

public class PanelManager : MonoBehaviour 
{

	public 	Tile[] 			tiles; 			// Board Tiles - custom class
	private LeapManager 	_leapManager; 	// Leap motion controller - used for hand gestures
	private GameObject 		palm; 			// Motion Controlled Palm - used for positioning - *moved by hand controller script
	public GameObject 		blueRing; 		// Motion Controlled Palm - used for positioning - *moved by hand controller script
	public GameObject 		redRing; 		// Motion Controlled Palm - used for positioning - *moved by hand controller script
	private bool 			canGrab; 		// Grabbing mechanics - restriction to only allow one panel to be picked at a time

	private int				findTotal = 0;		// Total number of animals to grab to win
	private int				findCount = 0;		// Number of animals grabbed so far
	private float			delayTimer = 1;		// Delays the ability to select an animal

	// These sprites store the origional sprite images, used to change the choices randomly
	public Sprite cow;
	public Sprite ele;
	public Sprite zeb;

	// Use this for initialization
	void Start () ////////////////////////////// Start Function /////////////////////////////////////////////////////////////////////////
	{
		//Sets Sprite Textures and booleans
		for(int i = 0; i < tiles.Length; i++){
			int index = Random.Range(0,3);
			if(index == 0){
				tiles[i].animal.sprite = cow; //Cow
			}
			else if(index == 1){
				tiles[i].animal.sprite = ele; //Elephant
			}
			else if(index == 2){
				tiles[i].animal.sprite = zeb; //Zebra
			}

			if(i > 0){
				// If current sprite is equal to example sprite, increase total number to find
				if(tiles[i].animal.sprite == tiles[0].animal.sprite){
					tiles[i].mustGrab = true;
					findTotal ++;
				}
				// Else make it unable to pick up.
				else{
					tiles[i].canGrab = false;
				}
			}
		}
		tiles[0].canGrab = false;

		// If no choice to match example, reload level
		if (findTotal < 1) {
			Application.LoadLevel("MatchingGame");
		}

		_leapManager = (GameObject.Find("LeapManager")as GameObject).GetComponent(typeof(LeapManager)) as LeapManager;
		palm = (GameObject.Find ("Palm")as GameObject);
		canGrab = true;
		redRing.renderer.enabled = false;
	}/////////////////////////////////////////// End Start Function /////////////////////////////////////////////////////////////////////

	void Update () ///////////////////////////// Update Function ////////////////////////////////////////////////////////////////////////
	{		
		//Timer to delay start
		if (delayTimer >= 0) {
		 	delayTimer -= Time.deltaTime;
		}

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
			for (int i = 0; i < tiles.Length; i++) {
				// Distance between palm and individual panels
				var distance = Vector3.Distance (tiles [i].tileObject.transform.position, palm.transform.position);

				// If you are within 1 unit, your hand is closed, and you can grab another panel - grab the panel and cannot pick another
				if (distance <= 4 && !LeapManager.isHandOpen (primeHand) && canGrab) {
					tiles [i].grabbed = true;
					canGrab = false;
				}
				// If your hand is open, drops panel, can grab another
				if (LeapManager.isHandOpen (primeHand) && tiles[i].grabbed) {
					tiles [i].grabbed = false;
					canGrab = true;
				}

				//*********************************** Finding Logic *********************************************************************
					if (tiles [i].grabbed && delayTimer <= 0) {
						if(tiles [i].mustGrab  && tiles [i].canGrab){
							findCount++;
							canGrab = false;
							tiles [i].animal.renderer.material.color = new Color(1f,1f,1f,0.5f);
							tiles [i].canGrab = false;
						}
					}
				//*********************************** End Finding Logic *****************************************************************

			}//End - tile for loop*
		}
		else { // If hand goes out of range, drop all objects
			for (int j = 0; j < tiles.Length; j++) {
				tiles [j].grabbed = false;
			}
			canGrab = true;
		}
		//====================================== End Grabbing Logic for Tiles ===========================================================

		//If there are no matches left, win & reload the level
		if (findCount >= findTotal) {
			print ("You Win");
			Application.LoadLevel("MatchingGame");
		}
	}/////////////////////////////////////////// End Update Function ////////////////////////////////////////////////////////////////////
}