#pragma strict

var levelDoor : GameObject; 
var doorOpen : AudioClip;
var doorClose : AudioClip;

function OnTriggerEnter (other : Collider) {
		if(RaycastScript.hasKey == true){
			levelDoor.animation.Play ("DoorOpen");
			audio.PlayOneShot(doorOpen);
		}
}
function OnTriggerExit (other : Collider) {
		if(RaycastScript.hasKey == true){
			levelDoor.animation.Play ("DoorClose");
			audio.PlayOneShot(doorClose);
		}
}