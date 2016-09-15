#pragma strict

var door : GameObject; 
var doorOpen : AudioClip;
var doorClose : AudioClip;
static var lockDoors : boolean;

function Start(){
	lockDoors = false;
}

function OnTriggerEnter (other : Collider) {
	if(lockDoors == false){
		door.animation.Play ("DoorOpen");
		audio.PlayOneShot(doorOpen);
	}
}
function OnTriggerExit (other : Collider) {
	if(lockDoors == false){
			door.animation.Play ("DoorClose");
			audio.PlayOneShot(doorClose);
	}
}