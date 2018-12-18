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

	// return a list holding lists of songs --> each corresponding to a diff artist
	public List<List<Song>> Parse()
	{
		List<List<Song>> songs = new List<List<Song>>();

		// list of BTS songs
		List<Song> BTS = new List<Song>();

		BTS.Add(new Song("Butterfly", "Young Forever", "BTS", "filepath"));
		BTS.Add(new Song("Young Forever", "Young Forever", "BTS", "filepath"));
		BTS.Add(new Song("Save Me", "Young Forever", "BTS", "filepath"));
		BTS.Add(new Song("SpineBreaker", "School Luv Affair", "BTS", "filepath"));
		BTS.Add(new Song("Boy In Luv", "School Luv Affair", "BTS", "filepath"));
		BTS.Add(new Song("Love Maze", "Love Yourself: Tear", "BTS", "somefile"));
		BTS.Add(new Song("Magic Shop", "Love Yourself: Tear", "BTS", "somefile"));
		BTS.Add(new Song("The Truth Untold", "Love Yourself: Tear", "BTS", "somefile"));

		songs.Add(BTS);

		// list of Day6 songs
		List<Song> D6 = new List<Song>();

		D6.Add(new Song("아픈 길 (Hurt Road)", "Remember Us", "Day6", "filepath"));
		D6.Add(new Song("행복했던 알들이었다 (Days Gone By)", "Remember Us", "Day6", "filepath"));
		D6.Add(new Song("Better Better", "Moonrise", "Day6", "filepath"));
		D6.Add(new Song("좋아합니다", "Moonrise", "Day6", "filepath"));
		D6.Add(new Song("Hi Hello", "Moonrise", "Day6", "filepath"));
		D6.Add(new Song("Shoot Me", "Shoot Me", "Day6", "somefile"));
		D6.Add(new Song("Feeling Good", "Shoot Me", "Day6", "somefile"));

		songs.Add(D6);

		return songs;
	}
}
