using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class InventoryDisplay : MonoBehaviour {

    List<Item> inventory;
    Text text;

	// Use this for initialization
	void Start () {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (player != null) {
            RoguelikeCharacterController controller = player.GetComponent<RoguelikeCharacterController>();
            if (controller != null) {
                inventory = controller.inventory;
            }
        }
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
