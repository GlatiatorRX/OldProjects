#pragma strict

var hasHelmet : boolean;

function Start(){

}

function Update () {
	if (Input.GetKey ("escape")) {
		Application.Quit();
	}
	if(GameControllerScript.dead == true){
		Application.LoadLevel(8);
	}
}