using UnityEngine;
using System.Collections;

public class PlaceMonsters : MonoBehaviour {
public Transform monster;
	// Use this for initialization
	// make a grid of monsters
	void Start () {
		int mapxmax = MapMaker.mapxmax;
		int mapymax = MapMaker.mapymax;
		bool monsterinwall = true;
		int monsterx=0;
		int monstery=0;
		int nummonsters = 15;
		int monstercount = nummonsters;
		for (int i=0; i<mapxmax; i++){
			for (int j=0; j<mapymax; j++){
				print (MapMaker.instance.floorMap[i,j]);}}

		while (monstercount>0) {
			monsterinwall=true;
			while (monsterinwall==true) {
				monsterx = Random.Range (0, mapxmax);
				monstery = Random.Range (0, mapymax);
				//1 is room, 0 is wall.
				if (MapMaker.instance.floorMap [monsterx, monstery] == 1 && MapMaker.instance.floorMap [monsterx, monstery] == 1) {
					monsterinwall = false;
					monstercount = monstercount - 1;
					Instantiate (monster, new Vector3 (monsterx, monstery, -1), Quaternion.identity);
				}
			}
		}
		//int[] xpositions = {7, 12, -3, 14, 16, 0};
		//int[] ypositions = {4, 3, 1, 0, 0, 0};
		//int i = 0;
		//foreach (int x in xpositions) {

		//initialize a grid of monsters with lines below
		//for (int y = 0; y < 5; y++) {
		//				for (int x = 0; x < 5; x++) {
			
		//	i++;
		//				}

	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
