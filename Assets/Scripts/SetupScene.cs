using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetupScene : MonoBehaviour
{
	//public Mesh crateMesh;
	// store crate mesh from assest store
	public GameObject cratePrefab;
	public GameObject crateParent;
	public GameObject songCubePrefab;
	
	private ParseCSV parse_script;

	// TODO: make this a List of artists, not one artist
	public List<Song> BTS;

	// Use this for initialization
	void Start ()
	{
		// grab the parse script + call Parse
		parse_script = gameObject.GetComponent<ParseCSV>();
		BTS = parse_script.Parse();

		// instantiate a new crate for this artist
		GameObject newCrate = Instantiate(cratePrefab, new Vector3(1.0f, 1.0f, 1.0f), Quaternion.Euler(-90,0,0), crateParent.transform);
		newCrate.transform.name = "BTS";

		// loop through and spawn song cubes
		foreach (Song s in BTS)
		{
			GameObject newSong = Instantiate(songCubePrefab, new Vector3(1.0f, 1.5f, 1.0f), Quaternion.identity, crateParent.transform);
			newSong.transform.name = s.title;
		}
	}
	
	// Update is called once per frame
	void Update () { }
}
