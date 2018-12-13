using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grab : MonoBehaviour
{
  public GameObject sphereSelector;

  private Transform oldParent;
  private SteamVR_TrackedObject trackedObj;
  private SteamVR_Controller.Device Controller
  {
      get { return SteamVR_Controller.Input((int)trackedObj.index); }
  }

  private bool startedGrabbing = false;
  private bool isGrabbing = false;
  private bool finishedGrabbing = false;

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
      startedGrabbing = true;
      isGrabbing = true;
      finishedGrabbing = false;
      MoveObjectInHand();
    }
    if (Controller.GetHairTriggerUp() && isGrabbing)
    {
      startedGrabbing = false;
      isGrabbing = false;
      finishedGrabbing = true;
      MoveObjectInHand();
    }
  }

  void MoveObjectInHand()
  {
    // grab the public GObj from the Selector script
    GameObject inHand = sphereSelector.GetComponent<Selector>().collidingObject;

    if (inHand == null)
    {
      return;
    }

    if (startedGrabbing)
    {
      // parent the collidingObject to the sphereSelector
      if (inHand.transform.parent != sphereSelector.transform) oldParent = inHand.transform.parent;
      Debug.Log(oldParent);
      inHand.transform.SetParent(sphereSelector.gameObject.transform);
    }
    else if (finishedGrabbing)
    {
      // un-parent the collidingObject from the sphereSelector
      inHand.transform.SetParent(oldParent);
      Debug.Log("Resetting parent " + oldParent);
    }
  }
}
