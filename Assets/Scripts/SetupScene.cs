using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetupScene : MonoBehaviour
{
	//public Mesh crateMesh;
	// store crate mesh from assest store
	public GameObject crateObj;
	public GameObject crateParent;
	
	private ParseCSV parseCSV;

	// TODO: make this a List of artists, not one artist
	public List<Song> BTS;

	// Use this for initialization
	void Start ()
	{
		// grab the parse script + call Parse
		parseCSV = this.GetComponent<ParseCSV>();
		//BTS = parseCSV.Parse();

		GameObject newCrate = Instantiate(crateObj, new Vector3(1.0f, 1.0f, 1.0f), Quaternion.Euler(-90,0,0), crateParent.transform);
		newCrate.transform.name = "BTS";
	}
	
	// Update is called once per frame
	void Update () { }
}
