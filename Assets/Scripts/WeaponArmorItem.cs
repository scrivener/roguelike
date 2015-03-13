using UnityEngine;
using System.Collections;

public class WeaponArmorItem : Item  {
	
	// Use this for initialization
	void Start () {
		if (Random.value < 0.5) {
			offense = Random.Range (1, 5);
			defense = 0;
		} else {
			defense = Random.Range (1, 5);
			offense = 0;
		}
	}
	
	public override string ToString() {
		return string.Format("{0}/{1} Item", offense, defense);
	}
}
