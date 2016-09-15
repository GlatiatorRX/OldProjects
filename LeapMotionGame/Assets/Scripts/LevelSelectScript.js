var boxbg : Texture2D;

var SceneOne : String;
var SceneOneName : String = "Minigame 1";

var SceneTwo : String;
var SceneTwoName : String = "Minigame 2";

var SceneThree : String;
var SceneThreeName : String = "Minigame 3";

var SceneFour : String;
var SceneFourName : String = "Minigame 4";

var SceneFive : String;
var SceneFiveName : String = "Minigame 5";

var SceneSix : String;
var SceneSixName : String = "Minigame 6";

var SceneSeven : String;
var SceneSevenName : String = "Minigame 7";

var SceneEight : String;
var SceneEightName : String = "Minigame 8";

var SceneNine : String;
var SceneNineName : String = "Minigame 9";

var SceneTen : String;
var SceneTenName : String = "Minigame 10";

var SceneEleven : String;
var SceneElevenName : String = "Minigame 11";

var SceneTwelve : String;
var SceneTwelveName : String = "Minigame 12";

var SceneThirteen : String;
var SceneThirteenName : String = "Minigame 13";

var SceneFourteen : String;
var SceneFourteenName : String = "Minigame 14";

var SceneFifteen : String;
var SceneFifteenName : String = "Minigame 15";

var SceneSixteen : String;
var SceneSixteenName : String = "Minigame 16";

var SceneSeventeen : String;
var SceneSeventeenName : String = "Minigame 17";

var SceneEighteen : String;
var SceneEighteenName : String = "Minigame 18";

function OnGUI()
{
	GUI.BeginGroup (Rect (Screen.width / 2 - 400, Screen.height / 2 - 200, Screen.width, Screen.height));
	
	GUI.Box (Rect (0,0,800,450), boxbg);
	
	if (GUI.Button(Rect(40,20,100,60),SceneOneName))
	{
		Application.LoadLevel(SceneOne);
	}
	
	if (GUI.Button(Rect(165,20,100,60),SceneTwoName))
	{
		Application.LoadLevel(SceneTwo);
	}
	
	if (GUI.Button(Rect(290,20,100,60),SceneThreeName))
	{
		Application.LoadLevel(SceneThree);	
	}
	
	if (GUI.Button(Rect(410,20,100,60),SceneFourName))
	{
		Application.LoadLevel(SceneFour);	
	}
	
	if (GUI.Button(Rect(535,20,100,60),SceneFiveName))
	{
		Application.LoadLevel(SceneFive);	
	}
	
	if (GUI.Button(Rect(660,20,100,60),SceneSixName))
	{
		Application.LoadLevel(SceneSix);	
	}
	
	if (GUI.Button(Rect(40,100,100,60),SceneSevenName))
	{
		Application.LoadLevel(SceneSeven);
	}
	
	if (GUI.Button(Rect(165,100,100,60),SceneEightName))
	{
		Application.LoadLevel(SceneEight);
	}
	
	if (GUI.Button(Rect(290,100,100,60),SceneNineName))
	{
		Application.LoadLevel(SceneNine);	
	}
	
	if (GUI.Button(Rect(410,100,100,60),SceneTenName))
	{
		Application.LoadLevel(SceneTen);	
	}
	
	if (GUI.Button(Rect(535,100,100,60),SceneElevenName))
	{
		Application.LoadLevel(SceneEleven);	
	}
	
	if (GUI.Button(Rect(660,100,100,60),SceneTwelveName))
	{
		Application.LoadLevel(SceneTwelve);	
	}
	
	if (GUI.Button(Rect(40,180,100,60),SceneThirteenName))
	{
		Application.LoadLevel(SceneThirteen);
	}
	
	if (GUI.Button(Rect(165,180,100,60),SceneFourteenName))
	{
		Application.LoadLevel(SceneFourteen);
	}
	
	if (GUI.Button(Rect(290,180,100,60),SceneFifteenName))
	{
		Application.LoadLevel(SceneFifteen);	
	}
	
	if (GUI.Button(Rect(410,180,100,60),SceneSixteenName))
	{
		Application.LoadLevel(SceneSixteen);	
	}
	
	if (GUI.Button(Rect(535,180,100,60),SceneSeventeenName))
	{
		Application.LoadLevel(SceneSeventeen);	
	}
	
	if (GUI.Button(Rect(660,180,100,60),SceneEighteenName))
	{
		Application.LoadLevel(SceneEighteen);	
	}
	if (GUI.Button(Rect(750,460,100,30),"Main Menu"))
	{
		Application.LoadLevel(0);
	}
	
	GUI.EndGroup();
}