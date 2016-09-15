#pragma strict

var mouseNeutral : GameObject;
var mouseActive : GameObject;
var mouseHazard : GameObject;
var pickUpSound : AudioClip;
var pickUpSound2 : AudioClip;
var turnValve : AudioClip;
var hitDebris : AudioClip;
var consoleSound : AudioClip;
var notifyGUI : GUIStyle;
var interactGUI : GUIStyle;

static var hasHelmet : boolean;
static var hasMoved : boolean;
static var hasJumped : boolean;
static var hasKey : boolean;
var toggle : boolean;

static var lookingAtHelmet : boolean;
static var lookingAtKey : boolean;
static var lookingAtDebris : boolean;
static var lookingAtValve : boolean;
static var lookingAtCell : boolean;
static var lookingAtSlot : boolean;
static var lookingAtConsole : boolean;

static var hit : RaycastHit;

var smack : int;
static var index = 0;

function Start ()
{
	mouseNeutral.renderer.enabled = true;
	mouseActive.renderer.enabled = false;
	mouseHazard.renderer.enabled = false;
	Screen.showCursor = false;
	
	hasHelmet = false;
	hasMoved = false;
	hasJumped = false;
	hasKey = false;
	toggle = false;
	
	lookingAtHelmet = false;
	lookingAtKey = false;
	lookingAtDebris = false;
	lookingAtValve = false;
	lookingAtCell = false;
	lookingAtSlot = false;
	lookingAtConsole = false;
	
	smack = 0;
}

function Update () {
	// Get the ray going through the center of the screen
	var ray : Ray = camera.ViewportPointToRay (Vector3(0.5,0.5,0));
	// Do a raycast
	if (Physics.Raycast (ray, hit)){
		//print ("I'm looking at " + hit.transform.name);
		if(hit.transform.name == "HelmetAsset1" && hasMoved == true && hasJumped == true){
			//GUI display
			lookingAtHelmet = true;
			mouseNeutral.renderer.enabled = false;
			mouseActive.renderer.enabled = true;
			//print ("Press E to pick up your helmet!");
			if (Input.GetKeyDown ("e")){
				//print ("E was pressed");
				audio.PlayOneShot(pickUpSound2);
				Destroy(hit.transform.gameObject); // destroy the object hit
				hasHelmet = true;
			}
		}
		else if(hit.transform.name == "MissingPowerCell1" || hit.transform.name == "MissingPowerCell2"){
			//GUI display
			lookingAtCell = true;
			mouseNeutral.renderer.enabled = false;
			mouseActive.renderer.enabled = true;
			//print ("Press E to pick the power cell!");
			if (Input.GetKeyDown ("e")){
				//print ("E was pressed");
				audio.PlayOneShot(pickUpSound2);
				Destroy(hit.transform.gameObject); // destroy the object hit
				MissingPowerScript1.count ++;
				MissingPowerScript2.count ++;
			}
		}
		else if(hit.transform.name == "MissingPowerSlot1" || hit.transform.name == "MissingPowerSlot2" ){
			//GUI display
			lookingAtSlot = true;
			mouseNeutral.renderer.enabled = false;
			mouseActive.renderer.enabled = true;
			//print ("Press E to place the power cell!");
		}
		else if(hit.transform.name == "Keycard"){
			//GUI display
			lookingAtKey = true;
			//print ("Press E to pick up your key!");
			if (Input.GetKeyDown ("e")){
				//print ("E was pressed");
				audio.PlayOneShot(pickUpSound);
				Destroy(hit.transform.gameObject); // destroy the object hit
				hasKey = true;
			}
		}
		else if(hit.transform.name == "Debris"){
			//GUI display
			lookingAtDebris = true;
			mouseNeutral.renderer.enabled = false;
			mouseHazard.renderer.enabled = true;
			//print ("Press E repeatedly to destroy debris!");
			if (Input.GetKeyDown ("e")){
				//print ("E was pressed");
				smack++;
				audio.PlayOneShot(hitDebris);
				if(smack>10){
					Destroy(hit.transform.gameObject); // destroy the object hit
				}
			}
		}//If you are hitting water valve
		else if(hit.transform.name == "WaterValve"){
			//GUI display
			lookingAtValve = true;
			mouseNeutral.renderer.enabled = false;
			mouseActive.renderer.enabled = true;
			//print ("Press E to turn!");
			if (Input.GetKeyDown ("e")){
				//print ("E was pressed");
				audio.PlayOneShot(turnValve);
				ValveScript.isTurned = true;
			}
		}
		else if(hit.transform.name == "FloodValve"){
			//GUI display
			lookingAtValve = true;
			mouseNeutral.renderer.enabled = false;
			mouseActive.renderer.enabled = true;
			//print ("Press E to turn!");
			if (Input.GetKeyDown ("e")){
				//print ("E was pressed");
				audio.PlayOneShot(turnValve);
				FloodScript.isTurned = true;
			}
		}
		else if(hit.transform.name == "console"){
			//GUI display
			lookingAtConsole = true;
			mouseNeutral.renderer.enabled = false;
			mouseActive.renderer.enabled = true;
			//print ("Press E to turn!");
			if (Input.GetKeyDown ("e")){
				audio.PlayOneShot(consoleSound);
				GameControllerScript.timerOn = false;
				index = Application.loadedLevel;		
				Application.LoadLevel(index+1);
			}
		}
		else if(hit.transform.name == "FirePrefab" || hit.transform.name == "WallPiston" || hit.transform.name == "FloorPiston"){
			mouseNeutral.renderer.enabled = false;
			mouseHazard.renderer.enabled = true;
		}		
		else{
			lookingAtHelmet = false;
			lookingAtKey = false;
			lookingAtDebris = false;
			lookingAtValve = false;
			lookingAtCell = false;
			lookingAtSlot = false;
			mouseNeutral.renderer.enabled = true;
			mouseActive.renderer.enabled = false;
			mouseHazard.renderer.enabled = false;
		}
	}
	
	//If moved
	if(Input.GetKeyDown ("w") || Input.GetKeyDown ("a") || Input.GetKeyDown ("s") || Input.GetKeyDown ("d")){
		hasMoved = true;
	}
	if(Input.GetKeyDown ("space") && hasMoved == true){
		hasJumped = true;
	}
}

function OnGUI () {
	// -------------Tutorial Room && || reused------------------
    if(hasMoved == false && Application.loadedLevel == 1){
		GUI.Box (Rect (Screen.width/2,Screen.height/4,0,0), "Use 'W, A, S, D' to move.", notifyGUI);
	}
	if(hasMoved == true && hasJumped == false && Application.loadedLevel == 1){
		GUI.Box (Rect (Screen.width/2,Screen.height/4,0,0), "Use 'Space' to jump.", notifyGUI);
	}
    if(hasMoved == true && hasJumped == true && hasHelmet == false && Application.loadedLevel == 1){
		GUI.Box (Rect (Screen.width/2,Screen.height/4,0,0), "Collect your helmet go to the next room.", notifyGUI);
	}
	if(lookingAtHelmet == true){
		GUI.Box (Rect (Screen.width/2,Screen.height/4*3,0,0), "Press E to pick up the helmet.", interactGUI);
	}
	if(lookingAtDebris == true){
		GUI.Box (Rect (Screen.width/2,Screen.height/4*3,0,0), "Press E multiple times to destroy the debris.", interactGUI);
	}
	if(lookingAtValve == true){
		GUI.Box (Rect (Screen.width/2,Screen.height/4*3,0,0), "Press E to turn the valve.", interactGUI);
	}
	
	// -------------Level One------------------
	if(lookingAtCell == true){
		GUI.Box (Rect (Screen.width/2,Screen.height/4*3,0,0), "Press E to pick the power cell!", interactGUI);
	}
	if(lookingAtSlot == true){
		GUI.Box (Rect (Screen.width/2,Screen.height/4*3,0,0), "Press E to place the power cell!", interactGUI);
	}
	
	// -------------Level Two------------------
	if(hasKey == false && Application.loadedLevel == 2 && MissingPowerScript1.canExit == true && MissingPowerScript2.canExit == true && ValveScript.isTurned == true){
		GUI.Box (Rect (Screen.width/2,Screen.height/4,0,0), "Collect the key card on the bed before you leave, you can use it to activate the escape pod.", notifyGUI);
	}
	if(lookingAtKey == true){
		GUI.Box (Rect (Screen.width/2,Screen.height/4*3,0,0), "Press E to pick up the key.", interactGUI);
	}
	// -------------Level four------------------
	if(lookingAtConsole == true){
		GUI.Box (Rect (Screen.width/2,Screen.height/4*3,0,0), "Press E to launch the pod.", interactGUI);
	}
}