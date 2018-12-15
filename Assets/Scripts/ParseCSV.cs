using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Songs data object class
public class Song
{
	public string title, album_name, filepath;

	public Song()
	{
		title = "";
		album_name = "";
		filepath = "";
	}

	public Song(string name, string album, string file)
	{
		title = name;
		album_name = album;
		filepath = file;
	}
}

public class ParseCSV : MonoBehaviour
{
	private string filepath = "";

	// Use this for initialization
	void Start ()
	{
		// TODO: verify filepath is valid?
	}
	
	// Update is called once per frame
	void Update () {}

	public List<Song> Parse()
	{
		// name the List with the artist name
		List<Song> BTS = new List<Song>();

		BTS.Add(new Song("Butterfly", "Young Forever", "filepath"));
		BTS.Add(new Song("SpineBreaker", "School Luv Affair", "filepath"));
		BTS.Add(new Song("Maze", "Love Yourself: Tear", "somefile"));

		return BTS;
	}
}
