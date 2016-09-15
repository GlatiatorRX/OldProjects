#pragma strict

static var isTurned : boolean;
var waterPlane : GameObject;
var waterParticles : GameObject[] = new GameObject[4];
var waterSound : GameObject;
var lowPosition : float;
var defaultPosition : float;
var highPosition : float;

function Start () {
	isTurned = false;
	defaultPosition = 11.59463;
	lowPosition = 8.628407;
	highPosition = 24.9128;
	waterPlane.transform.position.y = defaultPosition;
}

function Update () {
	if(isTurned == true && FloodCorridorScript.beginFlood == false){
		for(var j = 0; j < 4; j++){
			waterParticles[j].particleEmitter.maxEmission -= 0.25;
			if(j == 0 || j == 2){
				waterParticles[j].particleEmitter.maxEmission -= 1;
			}
		}
		if(waterPlane.transform.position.y > lowPosition){
			waterPlane.transform.position.y -= 0.01;
			waterParticles[1].transform.position.y -= 0.01;
			waterParticles[3].transform.position.y -= 0.01;
		}
		else{
			waterPlane.transform.position.y = lowPosition;
		}
		
		waterSound.audio.enabled = false;
	}
	if(FloodCorridorScript.beginFlood == true){
		if(waterPlane.transform.position.y < highPosition){
			waterPlane.transform.position.y += 0.01;
		}
		else{
			waterPlane.transform.position.y = highPosition;
		}
	}
}