using UnityEngine;
using System.Collections;

public class MonsterManager : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void tick() {
        GameObject[] monsterGOs = GameObject.FindGameObjectsWithTag("Monster");
        foreach (GameObject monsterGO in monsterGOs) {
            Monster monster = monsterGO.GetComponent<Monster>();
            if (monster != null) {
                monster.tick();
            } else {
                Debug.LogError("Found a monster tagged GO without a monster component");
            }

        }
    }
}
