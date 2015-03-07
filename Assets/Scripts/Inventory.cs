using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class Inventory : MonoBehaviour {

	public static Inventory instance;
	public List<Item> inventory = new List<Item>();

	void Awake() {
		instance = this;
	}
}
