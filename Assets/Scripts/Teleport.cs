using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : MonoBehaviour {

    public GameObject targetRoom;
    public GameObject cameraRig;

	// Use this for initialization
	void Start () {	}

    // Update is called once per frame
    void Update() { }

    void OnTriggerEnter(Collider other)
    {
        cameraRig.transform.position = targetRoom.transform.position;
    }
}
