#pragma strict
var flickerLight : GameObject;
var particles : GameObject;
var antiEpilepsy : boolean;

var timer: float; // set duration time in seconds in the Inspector

function Start () {
	antiEpilepsy = false;
	particles.particleEmitter.emit= false; //tell the emitter to stop.
	timer = 0;
}

function Update () {
	
	timer += Time.deltaTime;
	var seconds: int = timer % 60; // calculate the seconds
	if(seconds % 3 == 0){
		flicker();
		//Debug.Log(seconds);
	}
	if(seconds % 4 == 0){
		particles.particleEmitter.emit= true; //tell the emitter to start.
	}
	else{
		particles.particleEmitter.emit= false; //tell the emitter to stop.
	}
}

function flicker() {

	var number = Random.Range(1,3);
	
	//Debug.Log(number);
	
	if(number == 1){
		flickerLight.light.enabled = false;
	}
	if(number >= 2){
		flickerLight.light.enabled = true;
	}
	yield WaitForSeconds (5);
}