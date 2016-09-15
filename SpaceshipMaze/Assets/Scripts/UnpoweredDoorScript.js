#pragma strict

var door : GameObject; 
var doorOpen : AudioClip;
var doorClose : AudioClip;
static var atDoor : boolean;

var notifyGUI : GUIStyle;

function Start(){
	atDoor = false;
}

function OnTriggerEnter (other : Collider) {
		if(MissingPowerScript1.canExit == true && MissingPowerScript2.canExit == true){
			door.animation.Play ("DoorOpen");
			audio.PlayOneShot(doorOpen);
		}
		atDoor = true;
		
}
function OnTriggerExit (other : Collider) {
		if(MissingPowerScript1.canExit == true && MissingPowerScript2.canExit == true){
			door.animation.Play ("DoorClose");
			audio.PlayOneShot(doorClose);
		}
		atDoor = false;
}

function OnGUI(){
	if((MissingPowerScript1.canExit == false || MissingPowerScript2.canExit == false) && atDoor == true){
		GUI.Box (Rect (Screen.width/2,Screen.height/4,0,0), "The door is unpowered, find the console and make sure all cells are put in.", notifyGUI);
	}
}