using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Playlist : MonoBehaviour
{
	public HashSet<Song> songs;

    public TextMesh playlist_info;

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

    void OnTriggerEnter(Collider other)
    {
        Debug.Log("Entered lid of playlist crate");

        // check to see it's a song cube
        Song s = other.GetComponent<Song>();
        if (s)
        {
            if (songs.Add(s))
            {
                Debug.Log("Added " + s.title + " to playlist");

                // unparent from selector
                other.transform.SetParent(null);

                // shift playlist text up to make more room
                if (songs.Count > 5)
                {
                    playlist_info.transform.localPosition += new Vector3(0.0f, 0.0f, 0.2f);
                }
            }
            else
            {
                Debug.Log("Failed to add");
            }
        }
    }

    void OnTriggerStay(Collider other)
    {
        /*Debug.Log("Trigger stay");

        // check to see it's a song cube
        Song s = other.GetComponent<Song>();
        if (s)
        {
            if (songs.Add(s))
            {
                Debug.Log("Added " + s.title + " to playlist");

                // unparent from selector
                other.transform.SetParent(null);

                // shift playlist text up to make more room
                if (songs.Count > 5)
                {
                    playlist_info.transform.localPosition += new Vector3(0.0f, 0.0f, 0.2f);
                }
            }
        }*/
    }
}
