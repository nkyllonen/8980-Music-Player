using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grab : MonoBehaviour
{
  public GameObject selectionSphere;

  private Transform oldParent;
  private SteamVR_TrackedObject trackedObj;
  private SteamVR_Controller.Device Controller
  {
      get { return SteamVR_Controller.Input((int)trackedObj.index); }
  }

  private bool startedGrabbing = false;
  private bool isGrabbing = false;
  private bool finishedGrabbing = false;
  public GameObject inHand;

  // shaking
  // public float mag_threshold = 0.1f; // this works for difference in position
  public float mag_threshold = 9.0f;    // this seems to be a firm shake velocity
  private Vector3 old_pos;
  private Vector3 new_pos;

  // Start is called before the first frame update
  void Start()
  {
    trackedObj = GetComponent<SteamVR_TrackedObject>();
  }  

  //Update is called once per frame
  void Update()
  {
    // User has pressed trigger
    if (Controller.GetHairTriggerDown() && !isGrabbing)
    {
      startedGrabbing = true;
      isGrabbing = true;
      finishedGrabbing = false;
      MoveObjectInHand();
    }

    // User has released trigger
    if (Controller.GetHairTriggerUp() && isGrabbing)
    {
      startedGrabbing = false;
      isGrabbing = false;
      finishedGrabbing = true;
      MoveObjectInHand();
    }

    // User is still holding trigger
    if (isGrabbing && inHand)
    {
      // store change in position
      old_pos = new_pos;
      new_pos = inHand.transform.position;

      // manually calculate velocity since physics is turned off!
      Vector3 diff = (new_pos - old_pos) / Time.deltaTime;
      //Debug.Log(diff.magnitude);
      if (diff.magnitude > mag_threshold)
      {
        Debug.Log("Fast shake");
        Shuffle();
      }
    }
  }

  void MoveObjectInHand()
  {
     if (finishedGrabbing && inHand)
    {
      // un-parent inHand from the selectionSphere
      inHand.transform.SetParent(oldParent);
      Debug.Log("Resetting parent " + oldParent);

      // set inHand's is kinematic back to false --> "turn back on" physics
      inHand.GetComponentInChildren<Rigidbody>().isKinematic = false;

      // reset!
      inHand = null;
      old_pos = new Vector3();
      new_pos = new Vector3();
    }
    else if (startedGrabbing)
    {
      // grab the public GObj from the Selector script
      inHand = selectionSphere.GetComponent<Selector>().collidingObject;

      if (!inHand) return;

      // store current position
      new_pos = inHand.transform.position;

      // parent inHand to the selectionSphere
      if (inHand.transform.parent != selectionSphere.transform) oldParent = inHand.transform.parent;
      // Debug.Log(oldParent);
      inHand.transform.SetParent(selectionSphere.gameObject.transform);

      // set inHand's is kinematic to true --> "turn off" physics
      inHand.GetComponentInChildren<Rigidbody>().isKinematic = true;
    }

  } // END MoveObjectInHand()

  void Shuffle()
  {

  }
}
