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

  private SetupScene setup_script;

  // Start is called before the first frame update
  void Start()
  {
    setup_script = gameObject.GetComponent<SetupScene>();
    trackedObj = GetComponent<SteamVR_TrackedObject>();
  }  

  //Update is called once per frame
  void Update()
  {
    if (Controller.GetHairTriggerDown() && !isGrabbing)
    {
      Debug.Log("Begin grabbing");
      startedGrabbing = true;
      isGrabbing = true;
      finishedGrabbing = false;
      MoveObjectInHand();
    }
    if (Controller.GetHairTriggerUp() && isGrabbing)
    {
      Debug.Log("Stahp grabbing");

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
      // un-parent inHand from the selectionSphere
      inHand.transform.SetParent(oldParent);
      Debug.Log("Resetting parent " + oldParent);

      // set inHand's is kinematic back to false --> "turn back on" physics
      inHand.GetComponentInChildren<Rigidbody>().isKinematic = false;
      inHand = null;
    }
    else if (startedGrabbing)
    {
      // grab the public GObj from the Selector script
      inHand = selectionSphere.GetComponent<Selector>().collidingObject;

      // parent inHand to the selectionSphere
      if (inHand.transform.parent != selectionSphere.transform) oldParent = inHand.transform.parent;
      // Debug.Log(oldParent);
      inHand.transform.SetParent(selectionSphere.gameObject.transform);

      // set inHand's is kinematic to true --> "turn off" physics
      inHand.GetComponentInChildren<Rigidbody>().isKinematic = true;

      // try to access the List<Song> corresponding to this object
      // (if it exists)
      // if (inHand.transform.name == "BTS")
      // {
      //   List<Song> crate_list = setup_script.BTS;
      //   Debug.Log(crate_list);
      // }
    }

  }
}
