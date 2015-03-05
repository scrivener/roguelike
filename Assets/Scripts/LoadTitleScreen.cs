using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class LoadTitleScreen : MonoBehaviour {
	
	// Use this for initialization
	void Start () {
		GetComponent<Button>().onClick.AddListener( () => { loadTitleScene(); } );
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void loadTitleScene() {
		Application.LoadLevel("TitleScene");
	}
}
