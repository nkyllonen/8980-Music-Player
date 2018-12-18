using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetupScene : MonoBehaviour
{
	//public Mesh crateMesh;
	// store crate mesh from assest store
	public GameObject cratePrefab;
	public GameObject crateParent;
	public GameObject songCubePrefab;
	
	private ParseCSV parse_script;

	// TODO: make this a List of artists, not one artist

	public Material default_mat;
	// BTS mats
	public Material yf_mat;
	public Material luv_mat;
	public Material ly_mat;
	// Day6 mats
	public Material ru_mat;
	public Material mn_mat;
	public Material sm_mat;

	// Use this for initialization
	void Start ()
	{
		// grab the parse script + call Parse
		parse_script = gameObject.GetComponent<ParseCSV>();
		
		List<List<Song>> songs = parse_script.Parse();

		// BTS //
		List<Song> BTS_songs = songs[0];

		// instantiate a new crate for this artist
		GameObject newCrate = Instantiate(cratePrefab, new Vector3(1.0f, 0.5f, 1.0f), Quaternion.Euler(-90,0,0), crateParent.transform);
		newCrate.transform.name = "BTS";
		Artist a = newCrate.GetComponent<Artist>();
		a.artist_name = "BTS";

		List<GameObject> BTS_cubes = a.song_cubes;

		//loop through and spawn song cubes --> add to crate's list (within Artist)
		foreach (Song s in BTS_songs)
		{
			GameObject newSong = Instantiate(songCubePrefab, new Vector3(1.0f, 0.5f, 1.0f), Quaternion.identity, crateParent.transform);
			newSong.GetComponent<Song>().Copy(s);
			newSong.transform.name = s.title;

			// set material
			Material m = default_mat;
			switch (s.album_name)
			{
				case "Young Forever":
					m = yf_mat;
					break;
				case "School Luv Affair":
					m = luv_mat;
					break;
				case "Love Yourself: Tear":
					m = ly_mat;
					break;
				default:
					Debug.Log("Hit default case" + s.album_name);
					break;
			}

			newSong.gameObject.GetComponentInChildren<Renderer>().material = m;

			BTS_cubes.Add(newSong);
		}

		// DAY6 //
		List<Song> D6_songs = songs[1];

		// instantiate a new crate for this artist
		newCrate = Instantiate(cratePrefab, new Vector3(-1.0f, 0.5f, 1.0f), Quaternion.Euler(-90,0,0), crateParent.transform);
		newCrate.transform.name = "Day6";
		a = newCrate.GetComponent<Artist>();
		a.artist_name = "Day6";

		List<GameObject> D6_cubes = a.song_cubes;

		//loop through and spawn song cubes --> add to crate's list (within Artist)
		foreach (Song s in D6_songs)
		{
			GameObject newSong = Instantiate(songCubePrefab, new Vector3(-1.0f, 0.5f, 1.0f), Quaternion.identity, crateParent.transform);
			newSong.GetComponent<Song>().Copy(s);
			newSong.transform.name = s.title;

			// set material
			Material m = default_mat;
			switch (s.album_name)
			{
				case "Remember Us":
					m = ru_mat;
					break;
				case "Moonrise":
					m = mn_mat;
					break;
				case "Shoot Me":
					m = sm_mat;
					break;
				default:
					Debug.Log("Hit default case: " + s.album_name);
					break;
			}

			newSong.gameObject.GetComponentInChildren<Renderer>().material = m;

			D6_cubes.Add(newSong);
		}
	}
	
	// Update is called once per frame
	void Update () { }
}
