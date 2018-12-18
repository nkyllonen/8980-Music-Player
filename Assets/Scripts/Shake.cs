using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shake : MonoBehaviour {
	public GameObject controllerRight;
	public GameObject controllerLeft;

	private GameObject inHandRight;
	private GameObject inHandLeft;

	public double mag_threshold = 1.0e-6;

	// Use this for initialization
	void Start ()
	{
		
	}
	
	// Update is called once per frame
	void Update ()
	{
		inHandRight = controllerRight.GetComponent<Grab>().inHand;
		// inHandLeft = controllerLeft.GetComponent<LeftGrab>().inHand;

		// // check to see if they're grabbing the same object (and both aren't null)
		// if ((inHandLeft && inHandRight) && (inHandLeft == inHandRight))
		// {
		// 	Debug.Log("Grabbing same object");
		// }

		// check for rapid velocity
		if (inHandRight)
		{
			// inHandRight.GetComponent<Rigidbody>().isKinematic = false;
			double mag = inHandRight.GetComponent<Rigidbody>().velocity.magnitude;
			//Debug.Log(mag);
			if (mag > mag_threshold) Debug.Log("Fast shake");
			// inHandRight.GetComponent<Rigidbody>().isKinematic = true;
		}
	}
}
