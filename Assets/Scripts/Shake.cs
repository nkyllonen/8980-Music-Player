using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shake : MonoBehaviour {
	public GameObject controllerRight;
	public GameObject controllerLeft;

	private GameObject inHandRight;
	private GameObject inHandLeft;

	// Use this for initialization
	void Start ()
	{
		
	}
	
	// Update is called once per frame
	void Update ()
	{
		inHandRight = controllerRight.GetComponent<Grab>().inHand;
		inHandLeft = controllerLeft.GetComponent<LeftGrab>().inHand;

		// check to see if they're grabbing the same object (and both aren't null)
		if ((inHandLeft && inHandRight) && (inHandLeft == inHandRight))
		{
			Debug.Log("Grabbing same object");
		}
	}
}
