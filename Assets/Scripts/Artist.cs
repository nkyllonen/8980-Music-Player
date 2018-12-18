using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Artist data object class
public class Artist : MonoBehaviour
{
	// list of the song cube GObjs for this Artist
	public List<GameObject> song_cubes;
	public string artist_name;

	public Artist()
	{
		song_cubes = new List<GameObject>();
		artist_name = "";
	}
}
