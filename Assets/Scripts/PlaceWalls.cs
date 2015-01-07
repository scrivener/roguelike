using UnityEngine;
using System.Collections;

public class PlaceWalls : MonoBehaviour {
	public Transform wall;
	public Transform floor;
	// min and max for map boundaries
	static int xmax=17;
	static int xmin=-17;
	static int ymax=10;
	static int ymin = -10;

	//floor map array--int arrays automatically are full of 0s
	//0 is empty, 1 is temp room placement pending overlap check, 2 is room
	int[,] floorMap = new int[xmax-xmin+1,ymax-ymin+1];
	
	//max and min number rooms per floor
	int minRoomNum = 2;
	int maxRoomNum = 8;

	//max and min sizes of rooms
	int minRoomXSize = 5;
	int maxRoomXSize = 17;
	int minRoomYSize = 5;
	int maxRoomYSize = 10;

	void Start () {
				//surrounding walls and floors
				for (int y = ymin; y < ymax; y++) {
						Instantiate (wall, new Vector2 (xmin, y), Quaternion.identity);
						Instantiate (wall, new Vector2 (xmax, y), Quaternion.identity);
				}
				for (int x = xmin; x < xmax+1; x++) {
						Instantiate (wall, new Vector2 (x, ymin), Quaternion.identity);
						Instantiate (wall, new Vector2 (x, ymax), Quaternion.identity);
				}

				for (int x = xmin+1; x < xmax; x++) {
						for (int y = ymin+1; y < ymax; y++) {
								Instantiate (floor, new Vector2 (x, y), Quaternion.identity);
						}
				}

				//number of rooms
				int roomNum = Random.Range (minRoomNum, maxRoomNum + 1);
				bool overlapRoom = false;
				//make rooms
				for (int i = 0; i < roomNum; i++) {
						//room size includes the inside of the room including walls
						//*****
						//*---*
						//*---*
						//*---*
						//*****
						//is a size 5x5 room even if you can only walk in 3x3 tiles
						int roomXSize = Random.Range (minRoomXSize, maxRoomXSize + 1);
						int roomYSize = Random.Range (minRoomYSize, maxRoomYSize + 1);
						//room position defined as lower right corner of room including walls
						int roomXPos = Random.Range (xmin, xmax + 1 - (roomXSize));
						int roomYPos = Random.Range (ymin, ymax + 1 - (roomYSize));
						//mark room on floor map
						for (int x = roomXPos; x < roomXPos+roomXSize+1; x++) {
								for (int y = roomYPos; y < roomYPos+roomYSize+1; y++) {
										if (floorMap [x - xmin, y - ymin] == 0) {
												floorMap [x - xmin, y - ymin] = 1;
										} else if (floorMap [x - xmin, y - ymin] == 2) {
												overlapRoom = true;
										}

								}
						}
		
						//make room walls
						if (!overlapRoom) { //if there's no overlap, confirm room placement in map and make walls
								for (int x = roomXPos; x < roomXPos+roomXSize+1; x++) {
										Instantiate (wall, new Vector2 (x, roomYPos), Quaternion.identity);
										Instantiate (wall, new Vector2 (x, roomYPos + roomYSize), Quaternion.identity);
								}
								for (int y = roomYPos; y < roomYPos+roomYSize+1; y++) {
										Instantiate (wall, new Vector2 (roomXPos, y), Quaternion.identity);
										Instantiate (wall, new Vector2 (roomXPos + roomXSize, y), Quaternion.identity);
								}
								for (int x = roomXPos; x < roomXPos+roomXSize+1; x++) {
										for (int y = roomYPos; y < roomYPos+roomYSize+1; y++) {
												if (floorMap [x - xmin, y - ymin] == 1) {
														floorMap [x - xmin, y - ymin] = 2;
												}
										}
								}
						} else { //otherwise, clear the room from the floor map
								for (int x = roomXPos; x < roomXPos+roomXSize+1; x++) {
										for (int y = roomYPos; y < roomYPos+roomYSize+1; y++) {
												if (floorMap [x - xmin, y - ymin] == 1) {
														floorMap [x - xmin, y - ymin] = 0;
												}
										}
								}
						}
						//make room doors
						//which wall is the door in
						int doorWallIndex = Random.Range (0, 4);
						if (doorWallIndex == 0 || doorWallIndex == 2) {
								int doorWallPos = Random.Range (1, roomYSize);
						} else if (doorWallIndex == 1 || doorWallIndex == 3) {
								int doorWallPos = Random.Range (1, roomXSize);
						}

						//test destroy wall
						
						GameObject[] wallArray = GameObject.FindGameObjectsWithTag ("Wall");
						foreach (GameObject wallObject in wallArray){
				if (wallObject.transform.position.x == roomXPos+1 && wallObject.transform.position.y == roomYPos){
						Destroy (wallObject);}
				}
				}		
		}
	// Update is called once per frame
	void Update () {
		
	}
}