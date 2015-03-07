using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class InventoryDisplay : MonoBehaviour {

    Text text;

	// Use this for initialization
	void Start () {
        text = GetComponentInChildren<Text>();
	}
	
	// Update is called once per frame
	void Update () {
        if (text != null) {
            text.text = generateInventoryText();
        }
	}

    string generateInventoryText() {
        string text = "Inventory";
		List<Item> inventory = Inventory.instance.inventory;
        if (inventory == null) {
            Debug.LogError("Inventory is null");
            return text;
        }

        foreach (Item item in inventory) {
            Debug.Log(item.ToString());
            text += "\n" + item.ToString();
        }
//        Debug.Log("returning " + text);
        return text;
    }
}
