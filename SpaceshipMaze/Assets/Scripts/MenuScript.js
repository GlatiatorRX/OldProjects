#pragma strict

var index = 0;

var originalCursor : Texture2D;

var cursorSizeX: int = 32;  // set to width of your cursor texture
var cursorSizeY: int = 32;  // set to height of your cursor texture
 
static var showOriginal : boolean = true;

function Start () {
	Screen.showCursor = false;
	GameControllerScript.currentHealth = 100;
	//Screen.lockCursor = true;
}

function Update () {
	// Get the ray going through the center of the screen
	var ray : Ray = Camera.main.ScreenPointToRay (Input.mousePosition);
	// Do a raycast
	var hit : RaycastHit;
	if (Physics.Raycast (ray, hit)){
		//print ("I'm looking at " + hit.transform.name);
		if(hit.transform.name == "Play"){
			if(Input.GetMouseButton(0)){
				//Load Next Level
				index = Application.loadedLevel;
				Application.LoadLevel(index+1);
			}
		}
	}
	if (Input.GetKey ("escape")) {
		Application.Quit();
	}
}

function OnGUI(){
 
    if(showOriginal == true){
        GUI.DrawTexture (Rect(Input.mousePosition.x-cursorSizeX/2 + cursorSizeX/2, (Screen.height-Input.mousePosition.y)-cursorSizeY/2 + cursorSizeY/2, cursorSizeX, cursorSizeY),originalCursor);
    }
}