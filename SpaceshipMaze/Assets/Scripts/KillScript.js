#pragma strict

function OnTriggerEnter (other : Collider) 
	{
		//Destroy(other.gameObject);
		if (other.tag == "Player"){
			GameControllerScript.currentHealth = 0;
			//Debug.Log("Hit");
		}
	}
