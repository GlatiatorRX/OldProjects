#pragma strict
static var index = 0;

function OnTriggerEnter (other : Collider) {
		index = Application.loadedLevel;		
		Application.LoadLevel(index+1);
		//print(index+1);
}