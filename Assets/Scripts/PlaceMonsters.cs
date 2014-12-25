using UnityEngine;
using System.Collections;

public class PlaceMonsters : MonoBehaviour {
public Transform monster;
	// Use this for initialization
	// make a grid of monsters
	void Start () {
		for (int y = 0; y < 5; y++) {
						for (int x = 0; x < 5; x++) {
								Instantiate (monster, new Vector2 (x, y), Quaternion.identity);
						}
				}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
