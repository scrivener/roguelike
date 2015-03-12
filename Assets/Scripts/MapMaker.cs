using UnityEngine;
using System.Collections;

public class MapMaker : MonoBehaviour {
	public Transform wall;
	public Transform floor;
	public int[,] dungeonmap;

  // This will contain the one static singleton instance of MapMaker
  // for the scene. Other code can access it through:
  //
  // MapMaker.instance
  public static MapMaker instance;

  // Awake() is called before Start(). It will only be called once, since
  // only one instance of MapMaker will ever be created. And when it's
  // called, 'this' will represent that one instance of MapMaker.
  void Awake() {
    MapMaker.instance = this;
  }
	
	//structure to hold door connectivity
	public class RoomCon{
		public int keyValue; //index of door
		public int doorX;  //xpos of door (in floorMap)
		public int doorY; //ypos of door (in floorMap)
		public int doorNeighbor; //indeces of next door connected to this one
	}
	//array shuffling method
	public void reshuffle(int[] keyArray)
	{
		for (int i = 0; i < keyArray.Length; i++ )
		{
			int tmp = keyArray[i];
			int r = Random.Range(i, keyArray.Length);
			keyArray[i] = keyArray[r];
			keyArray[r] = tmp;
		}
	}
	
	// min and max for map boundaries
	//we're going to make 0,0 the CORNER, not the origin, to avoid headaches. Camera shifts accordingly.
	static int mapxmax=41;
	static int mapymax=41;
	
	//floor map array--int arrays automatically are full of 0s
	//0 is empty, 1 is temp room placement pending overlap check, 2 is room, 3 is door
	//4 is hall
	int[,] floorMap = new int[mapxmax,mapymax];
	
	//max and min number rooms per floor
	int minRoomNum = 6;
	int maxRoomNum = 10;
	
	//max and min sizes of rooms
	int minRoomXSize = 3;
	int maxRoomXSize = 10;
	int minRoomYSize = 3;
	int maxRoomYSize = 10;
	
	void Start () {
		GameObject terrainParent = new GameObject("Terrain");

		//Fill the whole dungeon with walls. We will carve out rooms afterward.
		for (int y = 0; y < mapymax; y++) {
			for (int x = 0; x < mapxmax; x++) {
				Transform spawnedWall = Instantiate (wall, new Vector2 (x, y), Quaternion.identity) as Transform;
				Transform spawnedFloor = Instantiate (floor, new Vector2 (x, y), Quaternion.identity) as Transform;
				spawnedWall.parent = terrainParent.transform;
				spawnedFloor.parent = terrainParent.transform;
			}
		}
		//array with all walls
		GameObject[] wallArray = GameObject.FindGameObjectsWithTag ("Wall");
		
		//number of rooms
		int roomNum = Random.Range (minRoomNum, maxRoomNum + 1);
		
		//room connectivity
		
		RoomCon[] roomArray = new RoomCon [roomNum];
		for (int i = 0; i < roomNum; i++) {
			roomArray [i] = new RoomCon ();
		}
		
		//make an array of keyvalues and shuffle (right now just shifted)
		int[] keyArray = new int[roomNum];
		for (int i=0; i<roomNum-1; i++) {
			keyArray [i] = i+1;
		}
		keyArray [roomNum-1] = 0;
		//reshuffle (keyArray);
		
		//make rooms
		for (int i = 0; i < roomNum; i++) {
			//room size is the inside of the room
			//*****
			//*---*
			//*---*
			//*---*
			//*****
			//is a size 3x3 room
			int roomXSize = Random.Range (minRoomXSize, maxRoomXSize + 1);
			int roomYSize = Random.Range (minRoomYSize, maxRoomYSize + 1);
			//room position defined as lower right corner of room
			int roomXPos = Random.Range (1, mapxmax - (roomXSize));
			int roomYPos = Random.Range (1, mapymax - (roomYSize));
			roomArray[i].doorX=roomXPos;
			roomArray[i].doorY=roomYPos;
			roomArray[i].keyValue=i;
			roomArray[i].doorNeighbor=keyArray[i];
			
			//mark room on floor map
			for (int x = roomXPos; x < roomXPos+roomXSize; x++) {
				for (int y = roomYPos; y < roomYPos+roomYSize; y++) {
					if (floorMap [x, y] == 0) {
						floorMap [x, y] = 1;
					}                
				}
			}        
			//carve out rooms
			for (int x = roomXPos; x < roomXPos+roomXSize+1; x++) {
				for (int y = roomYPos; y < roomYPos+roomYSize+1; y++) {
					foreach (GameObject wallObject in wallArray) {
						if (wallObject.transform.position.x == x && wallObject.transform.position.y == y) {
							Destroy (wallObject);
						}
					}
				}
			}
		}
		
		
		//for each pair of doors, figure out max x and y.
		//Draw a line from max y to min y, then from x (with max y) to other x
		
		for (int i=0; i<roomNum; i++) {
			int yo = roomArray [i].doorY;
			int yn = roomArray [roomArray [i].doorNeighbor].doorY;
			int yma = 0;
			int ymi = 0;
			int xwma =0;
			int xwmi = 0;
			if (yo >= yn) {
				yma = yo;
				ymi = yn;
				xwma = roomArray [i].doorX;
				xwmi = roomArray [roomArray [i].doorNeighbor].doorX;
			} else {
				yma = yn;
				ymi = yo;
				xwma = roomArray [roomArray [i].doorNeighbor].doorX;
				xwmi = roomArray [i].doorX;
			}
			for (int y=ymi; y<yma; y++) {
				foreach (GameObject wallObject in wallArray) {
					if (wallObject.transform.position.x == xwma && wallObject.transform.position.y == y) {
						Destroy (wallObject);}}}
			if (xwma >= xwmi) {
				for (int x=xwmi; x<xwma; x++) {
					foreach (GameObject wallObject in wallArray) {
						if (wallObject.transform.position.x == x && wallObject.transform.position.y == ymi) {
							Destroy (wallObject);}}}
			} else {
				for (int x=xwma; x<xwmi; x++) {
					foreach (GameObject wallObject in wallArray) {
						if (wallObject.transform.position.x == x && wallObject.transform.position.y == ymi) {
							Destroy (wallObject);}}}
			}
		}
		dungeonmap = floorMap;
	}
	// Update is called once per frame
	void Update () {
		
	}
}
