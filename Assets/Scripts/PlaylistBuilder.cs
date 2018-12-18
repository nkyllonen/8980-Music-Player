﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaylistBuilder : MonoBehaviour {
	// HashSet of unique Song objects
	public HashSet<Song> playlist;

    public TextMesh playlist_info;

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
        // display playlist information in the textmesh
        playlist_info.text = "";
        int i = 0;

        foreach (Song s in playlist)
        {
            playlist_info.text += (i+1) + ". " + s.title + " by " + s.artist_name + "\n";
            i++;
        }
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
