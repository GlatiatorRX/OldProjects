#pragma strict

var door : GameObject; 
var doorOpen : AudioClip;
var doorClose : AudioClip;

function OnTriggerEnter (other : Collider) {
		if(RaycastScript.hasHelmet == true){
			door.animation.Play ("DoorOpen");
			audio.PlayOneShot(doorOpen);
		}
}
function OnTriggerExit (other : Collider) {
		if(RaycastScript.hasHelmet == true){
			door.animation.Play ("DoorClose");
			audio.PlayOneShot(doorClose);
		}
}