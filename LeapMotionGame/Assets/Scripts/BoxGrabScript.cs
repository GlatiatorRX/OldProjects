using UnityEngine;
using System.Collections;
using Leap;

public class BoxGrabScript : MonoBehaviour 
{
	
	private LeapManager _leapManager;
	private Hand HandMas;
	private Vector3 tilePos;
	private bool pickUp;
	public bool canGrab;
	public bool isGrabbed;
	
	
	// Use this for initialization
	void Start () 
	{
		_leapManager = (GameObject.Find("LeapManager")as GameObject).GetComponent(typeof(LeapManager)) as LeapManager;
		//  panelManager = (GameObject.Find("Panel Manager")as GameObject).GetComponent(typeof(PanelManager)) as PanelManager;
		HandMas = _leapManager.frontmostHand();
		pickUp = false;
		canGrab = true;
		isGrabbed = false;
	}
	
	// Update is called once per frame
	void Update () 
	{
		HandMas = _leapManager.frontmostHand();
		
		
		var distance = Vector3.Distance(gameObject.transform.position, HandMas.PalmPosition.ToUnityTranslated());
		
		
		
		if(_leapManager != null) 
		{ 
			if(distance <= 1 && !LeapManager.isHandOpen(HandMas) && !isGrabbed)
			{
				//    panelManager.UpdateTiles();
				pickUp = true;
			}
			
			if(LeapManager.isHandOpen(HandMas))
				pickUp = false;
				isGrabbed = false;
			
			if(pickUp && canGrab)
			{
				isGrabbed = true;
			}
			if(isGrabbed){
				//if(_leapManager.frontmostHand().PalmPosition.ToUnityTranslated().x 
				tilePos = HandMas.PalmPosition.ToUnityTranslated();
				if(tilePos.y != 0)
					tilePos = Vector3.Scale(tilePos, new Vector3(1,1,0));
				gameObject.transform.position = tilePos;
			}
		}
	}
}