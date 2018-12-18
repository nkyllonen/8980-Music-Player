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
	//public List<Song> BTS;

	public Material yf_mat;
	public Material luv_mat;
	public Material ly_mat;
	public Material default_mat;

	// Use this for initialization
	void Start ()
	{
		// grab the parse script + call Parse
		parse_script = gameObject.GetComponent<ParseCSV>();
		List<Song> BTS_songs = parse_script.Parse();

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
					Debug.Log("Hit default case");
					break;
			}

			newSong.gameObject.GetComponentInChildren<Renderer>().material = m;

			BTS_cubes.Add(newSong);
		}
	}
	
	// Update is called once per frame
	void Update () { }
}
