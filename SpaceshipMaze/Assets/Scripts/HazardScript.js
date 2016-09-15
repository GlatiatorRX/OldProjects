#pragma strict

function OnTriggerStay(other : Collider){
	GameControllerScript.currentHealth -= 4;
}

function OnTriggerEnter(other : Collider){
	if (other.tag == "Player"){
			GameControllerScript.currentHealth -= 5;
			//Debug.Log("Hit");
	}
}