using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParseCSV : MonoBehaviour
{
	private string songdir_path = "";

	// Use this for initialization
	void Start ()
	{
		// TODO: verify filepath is valid?
	}
	
	// Update is called once per frame
	void Update () {}

	public List<Song> Parse()
	{
		// Debug.Log("in Parse()");
		// name the List with the artist name
		List<Song> BTS = new List<Song>();

		BTS.Add(new Song("Butterfly", "Young Forever", "BTS", "filepath"));
		BTS.Add(new Song("Young Forever", "Young Forever", "BTS", "filepath"));
		BTS.Add(new Song("SpineBreaker", "School Luv Affair", "BTS", "filepath"));
		BTS.Add(new Song("Boy In Luv", "School Luv Affair", "BTS", "filepath"));
		BTS.Add(new Song("Love Maze", "Love Yourself: Tear", "BTS", "somefile"));
		BTS.Add(new Song("Magic Shop", "Love Yourself: Tear", "BTS", "somefile"));

		return BTS;
	}
}
