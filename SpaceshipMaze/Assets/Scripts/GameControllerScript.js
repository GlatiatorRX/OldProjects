#pragma strict

public var maxHealth = 100; // Minimum health is 0.0f (dead)
public static var currentHealth = 100; // Players current health
public static var timer: float; // set duration time in seconds in the Inspector
static var timerOn : boolean;

var healthGUI : GUIStyle;
var timeGUI : GUIStyle;

static var dead : boolean;

// Make this game object and all its transform children
// survive when loading a new scene.
function Awake () {
	DontDestroyOnLoad (transform.gameObject);
}
 
// Use this for initialization
function Start () {
	timer = 300;
	dead = false;
	timerOn = false;
}
 
// Update is called once per frame
function Update () {
 
    adjustCurrentHealth(0);
    
	if(Application.loadedLevel == 2){
		timerOn = true;
	}
    
	if(Application.loadedLevel >= 1 && timerOn == true){
		timer -= Time.deltaTime;
    }
}
function OnGUI (){   
 
 	var seconds: int = timer % 60; // calculate the seconds
 	var minutes: int = timer / 60; // calculate the minutes
 	
    GUI.Box(new Rect(10, 10, 20, 20), "" + currentHealth, healthGUI);   
 
    if (currentHealth == 0)
    {
    	Application.LoadLevel(Application.loadedLevel);
    	currentHealth = 100;
    }
 	if (timer > 0){
 		GUI.Box(new Rect(10, 25, 20, 20), minutes + ":" + seconds, timeGUI);  
 	}
 	else{
 		GUI.Box(new Rect(0,0,Screen.width,Screen.height), "Game Over", healthGUI);
 		dead = true;
 		Destroy (this);
 	}
}
public function adjustCurrentHealth(adj : int)
{
    currentHealth += adj;
 
    if (currentHealth < 0)
    {
       currentHealth = 0;
    }
    if (currentHealth > maxHealth)
    {
       currentHealth = maxHealth;
    }
    if (maxHealth < 1)
    {
       maxHealth = 1;
    }
}