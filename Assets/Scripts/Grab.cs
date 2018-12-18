using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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

  // SHUFFLE //
  // public float mag_threshold = 0.1f; // this works for difference in position
  public float mag_threshold = 9.0f;    // this seems to be a firm shake velocity
  private Vector3 old_pos;
  private Vector3 new_pos;
  private float shuffle_time;
  private float between_time = 0.5f;

  // TEXT //
  public TextMesh song_title;

  // Start is called before the first frame update
  void Start()
  {
    trackedObj = GetComponent<SteamVR_TrackedObject>();

    // initialize text mesh properties
    song_title.text = "No song selected";
    song_title.characterSize = 0.1f;
    song_title.fontSize = 35;
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

    // User is still holding trigger --> can shuffle!
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

      // if object is song crate --> set lid box collider off
      Artist a = inHand.GetComponent<Artist>();

      if (a)
      {
        foreach (BoxCollider bc in inHand.GetComponents<BoxCollider>())
        {
            // find the lid collider
            if (bc.center.x == 0.0f && bc.center.y == 0.0f && bc.center.z > 0.0f)
            {
                bc.enabled = false;
            }
        }
      }

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

      // turn off any constraints if there are any --> for grabbing shuffled songs
      inHand.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;

      // if object is a song cube --> display song info
      Song s = inHand.GetComponent<Song>();

      if (s) DisplaySong(s);
      else
      {
        // if object is a song crate --> set lid box collider to active
        foreach (BoxCollider bc in inHand.GetComponents<BoxCollider>())
        {
          // find the lid collider
          if (bc.center.x == 0.0f && bc.center.y == 0.0f && bc.center.z > 0.0f)
          {
            bc.enabled = true;
          }
        }
      }

    }

  } // END MoveObjectInHand()

  void Shuffle()
  {
    Artist a = inHand.GetComponent<Artist>();

    // if the object has an Artist comp, must be a crate!
    if (a)
    {
      // if enough time since our last shuffle has gone by
      if (Time.time - shuffle_time > between_time)
      {
        shuffle_time = Time.time;

        if (a.song_cubes.Count <= 0) return;

        // randomly select a song
        int rand_i = Random.Range(0, a.song_cubes.Count);
        GameObject cube = a.song_cubes[rand_i];
        Song song = cube.GetComponent<Song>();

        cube.transform.position += new Vector3(0.0f, 1.0f, 0.0f);
        cube.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;

        DisplaySong(song);
      }
    }
  }

  void DisplaySong(Song s)
  {
    song_title.text = s.title + "\n" + s.album_name + "\n" + s.artist_name;
  }
}
