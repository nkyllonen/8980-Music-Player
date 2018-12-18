using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Songs data object class
public class Song : MonoBehaviour
{
	public string title, album_name, filepath;

	// public Song()
	// {
	// 	title = "";
	// 	album_name = "";
	// 	filepath = "";
	// }

	// public Song(string name, string album, string file)
	// {
	// 	title = name;
	// 	album_name = album;
	// 	filepath = file;
	// }

	public void Set(string name, string album, string file)
	{
		title = name;
		album_name = album;
		filepath = file;
	}
}