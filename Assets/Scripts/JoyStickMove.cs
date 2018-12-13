using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JoyStickMove : MonoBehaviour
{
    public GameObject camera;
    public GameObject cameraRig;

    public float speed = 1.0f;
    public float rotationSpeed = 25.0f;

    // Use this for initialization
    void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        // update cameraRig's position using the camera's forward vector
        //      - ignoring y axis by projecting forward onto the plane of the floor
        Vector3 forward = Vector3.ProjectOnPlane(camera.transform.forward, new Vector3(0.0f, 1.0f, 0.0f));
        cameraRig.transform.position += forward * speed * Time.deltaTime * Input.GetAxis("Vertical");

        // update camera's rotation
        float rotation = Time.deltaTime * Input.GetAxis("Horizontal") * rotationSpeed;
        cameraRig.transform.Rotate(0, rotation, 0);
    }
}
