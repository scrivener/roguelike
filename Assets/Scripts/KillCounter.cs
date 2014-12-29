using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class KillCounter : MonoBehaviour {

    public int kills = 0;
    public Text xpText;
	
    // Use this for initialization
	void Start () {
        xpText.text = kills.ToString();
	}
	
	// Update is called once per frame
	void Update () {
        xpText.text = kills.ToString();
	}
}
