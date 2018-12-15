using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetupScene : MonoBehaviour
{
	public Mesh crateMesh;
	
	private ParseCSV parseCSV;

	// TODO: make this a List of artists, not one artist
	public List<Song> BTS;

	// Use this for initialization
	void Start ()
	{
		// grab the parse script + call Parse
		parseCSV = this.GetComponent<ParseCSV>();
		BTS = parseCSV.Parse();
	}
	
	// Update is called once per frame
	void Update () { }
}
