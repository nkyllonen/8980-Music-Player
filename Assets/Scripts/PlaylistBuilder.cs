using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaylistBuilder : MonoBehaviour {
	// HashSet of unique Song objects
	public HashSet<Song> playlist;

	private Color selection_color = Color.green;
	private Color old_color;

	// Use this for initialization
	void Start ()
	{
		playlist = new HashSet<Song>();
		old_color = this.GetComponent<Renderer>().material.color;
	}
	
	// Update is called once per frame
	void Update ()
	{
		
	}

	void OnTriggerEnter(Collider other)
	{
		// check to see it's a song cube
		if (other.GetComponent<Song>())
		{
			this.GetComponent<Renderer>().material.color = selection_color;
		}
	}

	void OnTriggerStay(Collider other)
	{
		// check to see it's a song cube
		Song s = other.GetComponent<Song>();
		if (s)
		{
			if (playlist.Add(s)) Debug.Log("Added " + s.title + " to playlist");
			//else Debug.Log("Failed to add");
			//other.gameObject.SetActive(false);
		}
	}

	void OnTriggerExit(Collider other)
	{
		this.GetComponent<Renderer>().material.color = old_color;
	}
}
