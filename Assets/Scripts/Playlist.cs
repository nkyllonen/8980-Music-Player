using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Playlist : MonoBehaviour
{
	public HashSet<Song> songs;

	// Use this for initialization
	void Start ()
	{
		songs = new HashSet<Song>();
	}
	
	// Update is called once per frame
	void Update ()
	{
		//if (songs.Count > 0) Debug.Log("there are songs!");
	}

	public void Shuffle()
	{
		Debug.Log("Playlist shuffle!");

		HashSet<Song> hash = new HashSet<Song>();
		Song[] temp = new Song[songs.Count];
		songs.CopyTo(temp);

		while (hash.Count < songs.Count)
		{
			Song s = temp[Random.Range(0, songs.Count)];
			//Debug.Log("Shuffled: " + s);
			hash.Add(s);
		}

		//songs.Clear();
		songs = hash;

		// foreach (Song s in songs)
		// {
		// 	Debug.Log(s.title);
		// }
	}
}
