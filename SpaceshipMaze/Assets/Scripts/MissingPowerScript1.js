#pragma strict

static var count : int;
static var canExit : boolean;

function Start () {
	renderer.enabled = false;
	canExit = false;
	count = 0;
}

function Update () {
	if(count > 0){
		if (Input.GetKeyDown ("e") && RaycastScript.hit.transform.name == "MissingPowerSlot1" ){
			renderer.enabled = true;
			canExit = true;
			count --;
			MissingPowerScript2.count --;
			animation.Play ("PowerSlot1");
			collider.enabled = false;
			
			if(count < 0){
				count = 0;
			}
		}
	}
	//print(count);
}