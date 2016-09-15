#pragma strict

var door : GameObject; 
var doorOpen : AudioClip;
var doorClose : AudioClip;

function OnTriggerEnter (other : Collider) {
	door.animation.Play ("DoorOpen");
	audio.PlayOneShot(doorOpen);
}
function OnTriggerExit (other : Collider) {
	door.animation.Play ("DoorClose");
	audio.PlayOneShot(doorClose);
}