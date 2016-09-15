#pragma strict

var toggle : boolean;
var notifyGUI : GUIStyle;

function Start(){
	toggle = false;
}

function OnTriggerEnter (other : Collider) {
	if (other.tag == "Player"){
		toggle = true;
	}
}
function OnTriggerExit (other : Collider) {
	if (other.tag == "Player"){
		toggle = false;
	}
}
function OnGUI(){
	if(toggle){
		//Debug.Log(toggle);
		if(ValveScript.isTurned == false && transform.name == "FireInfoTrigger"){
			GUI.Box (Rect (Screen.width/2,100,0,0), "Beware of fire. It can kill you.", notifyGUI);
		}
		if(transform.name == "PowerInfoTrigger" && MissingPowerScript1.canExit == false && MissingPowerScript2.canExit == false){
			GUI.Box (Rect (Screen.width/2,100,0,0), "There are cells on the floor! Put them where they belong.", notifyGUI);
		}
		if(transform.name == "FloodTrigger" && MissingPowerScript1.canExit == true && MissingPowerScript2.canExit == true){
			LockingDoorScript.lockDoors = true;
		}
		if(transform.name == "TimerInfoTrigger"){
			GUI.Box (Rect (Screen.width/2,100,0,0), "Your ship is on a collision course with the sun!", notifyGUI);
			GUI.Box (Rect (Screen.width/2,(Screen.height/4)*3,0,0), "You have only five minutes to make it to safety!", notifyGUI);
		}
		if(transform.name == "CoreInfoTrigger"){
			GUI.Box (Rect (Screen.width/2,100,0,0), "Beware of the red energy cores! If you get hit by one, you will die.", notifyGUI);
		}
		if(transform.name == "FloodInfoTrigger" && FloodScript.isTurned == false){
			GUI.Box (Rect (Screen.width/2,100,0,0), "Maybe if you found a turn valve, you could try to drain the water.", notifyGUI);
		}
		if(transform.name == "PistonInfoTrigger" && MissingPowerScript1.canExit == false && MissingPowerScript2.canExit == false){
			GUI.Box (Rect (Screen.width/2,100,0,0), "Be careful not to get crushed by pistons!", notifyGUI);
		}
	}
}