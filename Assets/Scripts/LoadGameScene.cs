using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class LoadGameScene : MonoBehaviour {
	
	// Use this for initialization
	void Start () {
		GetComponent<Button>().onClick.AddListener( () => { loadGameScene(); } );
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	void loadGameScene() {
		Application.LoadLevel("GameScene");
	}
}
