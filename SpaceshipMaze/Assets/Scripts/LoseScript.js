#pragma strict

var notifyGUI : GUIStyle;

var originalCursor : Texture2D;

var cursorSizeX: int = 32;  // set to width of your cursor texture
var cursorSizeY: int = 32;  // set to height of your cursor texture

static var showOriginal : boolean = true;

function OnGUI () {
	GUI.Box (Rect (Screen.width/2,100,0,0), "You have been lost to the Sun's Blaze!", notifyGUI);
	
	if(GUI.Button(Rect(Screen.width/2-50,Screen.height/4,100,50), "-Back to Menu-")){
		Application.LoadLevel(0);
	}
	
	if(showOriginal == true){
        GUI.DrawTexture (Rect(Input.mousePosition.x-cursorSizeX/2 + cursorSizeX/2, (Screen.height-Input.mousePosition.y)-cursorSizeY/2 + cursorSizeY/2, cursorSizeX, cursorSizeY),originalCursor);
    }
}