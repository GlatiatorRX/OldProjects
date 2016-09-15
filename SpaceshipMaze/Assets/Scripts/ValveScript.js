#pragma strict

static var isTurned : boolean;
var fireParticles : GameObject[] = new GameObject[2];
var waterParticles : GameObject[] = new GameObject[4];
var sprinklerSound : GameObject[] = new GameObject[2];
var fireSound : GameObject;
var fireLight : GameObject;
var fire : GameObject;

var Sprinkler : AudioClip;
var toggle : boolean;

function Start () {
	isTurned = false;
	toggle = true;
	for(var i = 0; i < 4; i++){
		waterParticles[i].GetComponent(ParticleEmitter).emit= false; //tell the emitter to stop.
	}
	for(var j = 0; j < 2; j++){
		sprinklerSound[j].audio.enabled = false;
	}
}

function Update () {
	if(isTurned == true){
		for(var i = 0; i < 2; i++){
			fireParticles[i].GetComponent(ParticleEmitter).emit= false; //tell the emitter to stop.
		}
		for(var j = 0; j < 4; j++){
			waterParticles[j].GetComponent(ParticleEmitter).emit= true; //tell the emitter to begin.
			waterParticles[j].particleEmitter.maxEmission -= 0.25;
			if(j == 0 || j == 2){
				waterParticles[j].particleEmitter.maxEmission -= 1;
			}
		}
		for(var k = 0; k < 2; k++){
			sprinklerSound[k].audio.enabled = true;
		}		
		playSprinkler();
		fireSound.audio.enabled = false;
		
		fireLight.light.enabled = false;
		fire.collider.enabled = false;
	}
}

function playSprinkler(){
	if(toggle == true){
		for(var k = 0; k < 2; k++){
			sprinklerSound[k].audio.PlayOneShot(Sprinkler);
		}
		//Debug.Log("SoundActive");
		toggle = false;
	}
}