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
		if (Input.GetKeyDown ("e")&& RaycastScript.hit.transform.name == "MissingPowerSlot2" ){
			renderer.enabled = true;
			canExit = true;
			count --;
			MissingPowerScript1.count --;
			animation.Play ("PowerSlot2");
			collider.enabled = false;
			
			if(count < 0){
				count = 0;
			}
		}
	}
	//print(count);
}