using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class Inventory : MonoBehaviour {

	public static Inventory instance;
	public List<Item> inventory = new List<Item>();

	void Awake() {
		instance = this;
	}

	// For now, there's no notion of equipping. 
	// Anything in your inventory modifies your stats.
	public int getOffense() {
		int offense = 0;
		foreach (Item item in inventory) {
			offense += item.offense;
		}
		return offense;
	}

	// For now, there's no notion of equipping. 
	// Anything in your inventory modifies your stats.
	public int getDefense() {
		int defense = 0;
		foreach (Item item in inventory) {
			defense += item.defense;
		}
		return defense;
	}
}
