using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Colliding : MonoBehaviour
{
	public GameObject collidingObject;

	// Use this for initialization
	void Start () {	}
	
	// Update is called once per frame
	void Update () { }

	void OnTriggerEnter (Collider other)
	{
    // Only allow one object to be selected at once
    if (collidingObject)
    {
      return;
    }

    this.collidingObject = other.gameObject;
  }

  void OnTriggerStay (Collider other) { }

  void OnTriggerExit(Collider other)
  {
    // Only allow one object to be selected at once
    if (other.gameObject != collidingObject)
    {
      return;
    }

    this.collidingObject = null;
  }
}
