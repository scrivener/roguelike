﻿using UnityEngine;
using System.Collections;

public class PlaceMonsters : MonoBehaviour {
public Transform monster;
	// Use this for initialization
	// make a grid of monsters
	void Start () {
		int[] xpositions = {7, 12, -3, 14, 16, 0};
		int[] ypositions = {4, 3, 1, 0, 0, 0};
		int i = 0;
		foreach (int x in xpositions) {

		//initialize a grid of monsters with lines below
		//for (int y = 0; y < 5; y++) {
		//				for (int x = 0; x < 5; x++) {
			Instantiate (monster, new Vector2 (x, ypositions[i]), Quaternion.identity);
			i++;
						}

	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
