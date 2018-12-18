using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParseCSV : MonoBehaviour
{
	public GameObject crateParent;
	public GameObject songCubePrefab;

	private string songdir_path = "";

	// Use this for initialization
	void Start ()
	{
		// TODO: verify filepath is valid?
	}
	
	// Update is called once per frame
	void Update () {}

	public List<GameObject> Parse()
	{
		// name the List with the artist name
		List<GameObject> BTS_cubes = new List<GameObject>();

		// BTS.Add(new Song("Butterfly", "Young Forever", "filepath"));
		// BTS.Add(new Song("SpineBreaker", "School Luv Affair", "filepath"));
		// BTS.Add(new Song("Maze", "Love Yourself: Tear", "somefile"));

		GameObject newSong = Instantiate(songCubePrefab, new Vector3(1.0f, 1.5f, 1.0f), Quaternion.identity, crateParent.transform);
		newSong.transform.name = "";
		BTS_cubes.Add(newSong);

		return BTS_cubes;
	}
}
