#pragma strict

var waterPushers : GameObject[] = new GameObject[4];
var waterfall : GameObject;
static var beginFlood : boolean;

function Start () {
	beginFlood = false;
	waterfall.GetComponent(ParticleEmitter).emit= false; //tell the emitter to stop.
	for(var i = 0;i<4;i++){
		waterPushers[i].collider.enabled = false;
	}
}

function Update(){
	if(UnpoweredDoorScript.atDoor == true && MissingPowerScript1.canExit == true && MissingPowerScript2.canExit == true){
		beginFlood = true;
		waterfall.GetComponent(ParticleEmitter).emit= true; //tell the emitter to begin.
		for(var j = 0;j<4;j++){
			waterPushers[j].collider.enabled = true;
		}
	 } 
	 
	 if(beginFlood){
	 	waterPushers[0].transform.position.x += 0.01;
	 	waterPushers[0].transform.position.x -= 0.01;
	 	waterPushers[0].transform.position.z -= 0.01;
	 	waterPushers[0].transform.position.z += 0.01;
	 }
}