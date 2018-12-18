using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaylistBuilder : MonoBehaviour {
	// HashSet of unique Song objects
	public HashSet<Song> playlist;

    public TextMesh playlist_info;

	public GameObject playlist_crate;
    private Vector3 BTS_crate_pos;
    private Vector3 D6_crate_pos;
    public GameObject crateParent;

    private Color selection_color = Color.green;
	private Color old_color;

	// Use this for initialization
	void Start ()
	{
		// refer to Playlist's HashSet
		playlist = playlist_crate.GetComponent<Playlist>().songs;
		old_color = this.GetComponent<Renderer>().material.color;

        BTS_crate_pos = new Vector3(1.0f, 1.5f, 1.0f);
        D6_crate_pos = new Vector3(-1.0f, 1.5f, 1.0f);
    }
	
	// Update is called once per frame
	void Update ()
	{
        // display playlist information in the textmesh
		playlist = playlist_crate.GetComponent<Playlist>().songs;
        playlist_info.text = "Playlist:\n";
        int i = 0;

        foreach (Song s in playlist)
        {
            playlist_info.text += (i+1) + ". '" + s.title + "' by " + s.artist_name + "\n";
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
			if (playlist.Add(s))
			{
				Debug.Log("Added " + s.title + " to playlist");

				// unparent from selector
				other.transform.SetParent(null);

				// teleport cube to playlist crate
				s.transform.position = playlist_crate.transform.position + new Vector3(0.0f, 0.5f, 0.0f);

				// shift playlist text up to make more room
				if (playlist.Count > 5)
				{
					playlist_info.transform.localPosition += new Vector3(0.0f, 0.0f, 0.2f);
				}
			}
            else
            {
                // unable to add to playlist because already in playlist
                playlist.Remove(s);
                //other.gameObject.transform.SetParent(crateParent);
                other.transform.SetParent(null);

                if (s.artist_name == "BTS")
                {
                    other.transform.position = BTS_crate_pos + new Vector3(0.0f, 0.1f, 0.0f);
                }
                else if (s.artist_name == "Day6")
                {
                    other.transform.position = D6_crate_pos + new Vector3(0.0f, 0.1f, 0.0f);
                }
            }
		}
	}

	void OnTriggerExit(Collider other)
	{
		this.GetComponent<Renderer>().material.color = old_color;
	}
}
