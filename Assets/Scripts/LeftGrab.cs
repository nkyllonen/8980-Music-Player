using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeftGrab : MonoBehaviour
{
	public GameObject selectionSphere;
	private SteamVR_TrackedObject trackedObj;
	private SteamVR_Controller.Device Controller
	{
		get { return SteamVR_Controller.Input((int)trackedObj.index); }
	}

	private bool startedGrabbing = false;
	private bool isGrabbing = false;
	private bool finishedGrabbing = false;
	public GameObject inHand;

	// Start is called before the first frame update
	void Start()
	{
		trackedObj = GetComponent<SteamVR_TrackedObject>();
	}  

	//Update is called once per frame
	void Update()
	{
		if (Controller.GetHairTriggerDown() && !isGrabbing)
		{
		//   Debug.Log("Begin grabbing");
			startedGrabbing = true;
			isGrabbing = true;
			finishedGrabbing = false;
			MoveObjectInHand();
		}
		if (Controller.GetHairTriggerUp() && isGrabbing)
		{
		//   Debug.Log("Stahp grabbing");

			startedGrabbing = false;
			isGrabbing = false;
			finishedGrabbing = true;
			MoveObjectInHand();
		}
	}

	void MoveObjectInHand()
	{
		if (finishedGrabbing && inHand)
		{
			inHand = null;
		}
		else if (startedGrabbing)
		{
			// grab the public GObj from the Colliding script
			inHand = selectionSphere.GetComponent<Colliding>().collidingObject;
		}

	}
}
