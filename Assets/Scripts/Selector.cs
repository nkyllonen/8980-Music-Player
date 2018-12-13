// ADAPTED BRIDGER AND I'S SCRIPT FROM WIM PROTOTYPE //

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Selector : MonoBehaviour {
  ArrayList colors = new ArrayList();

  Color our_old_color;

  Color collision_color = Color.magenta;

  public GameObject collidingObject;


  // Use this for initialization
  void Start () {
    our_old_color = this.GetComponent<Renderer>().material.color;
  }

  // Update is called once per frame
  void Update () {

  }

  void OnTriggerEnter (Collider other) {
    // Only allow one object to be selected at once
    if (collidingObject)
    {
      return;
    }

    // recursively loop through all the children of other and get their current material colors
    foreach (Renderer r in other.gameObject.GetComponentsInChildren<Renderer>())
    {
      foreach (Material m in r.materials)
      {
        colors.Add(m.color);
      }
    }

    // recursively loop through all the children of other and set their material colors
    foreach (Renderer r in other.gameObject.GetComponentsInChildren<Renderer>())
    {
      foreach (Material m in r.materials)
      {
        m.color = collision_color;
      }
    }

    // change our color
    this.GetComponent<Renderer>().material.color = collision_color;

    this.collidingObject = other.gameObject;
  }

  void OnTriggerStay (Collider other) {

  }

  void OnTriggerExit(Collider other) {
    // Only allow one object to be selected at once
    if (other.gameObject != collidingObject)
    {
      return;
    }
    // Reset the colors of the object
    int i = 0;
    foreach (Renderer r in other.gameObject.GetComponentsInChildren<Renderer>())
    {
      foreach (Material m in r.materials)
      {
        m.color = (Color)colors[i++];
      }
    }

    // clear ArrayList of all colors we just added
    colors.Clear();

    // reset our color to the old color
    this.GetComponent<Renderer>().material.color =  our_old_color;

    this.collidingObject = null;

  }
}
