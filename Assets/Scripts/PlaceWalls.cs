using UnityEngine;
using System.Collections;

public class PlaceWalls : MonoBehaviour {
	public Transform wall;
	// Use this for initialization
	// make outside walls for now
	int xmax=17;
	int xmin=-17;
	int ymax=10;
	int ymin = -10;
	void Start () {
		for (int y = ymin; y < ymax; y++) {
			Instantiate (wall, new Vector2 (xmin, y), Quaternion.identity);
			Instantiate (wall, new Vector2 (xmax, y), Quaternion.identity);
				}
		for (int x = xmin; x < xmax+1; x++) {
						Instantiate (wall, new Vector2 (x, ymin), Quaternion.identity);
						Instantiate (wall, new Vector2 (x, ymax), Quaternion.identity);
				}
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}