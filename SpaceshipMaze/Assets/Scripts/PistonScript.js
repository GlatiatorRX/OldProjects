#pragma strict

function OnTriggerStay(other : Collider){
	other.transform.position.z += 2;
}