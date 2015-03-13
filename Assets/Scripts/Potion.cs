using UnityEngine;
using System.Collections;

public class Potion : Item {

	private int _offense;
	public new int offense { 
		get { return 0; } 
		private set { this._offense = value; } 
	}
	private int _defense;
	public new int defense { 
		get { return 0; } 
		private set { this._defense = value; }
	}
			
	public override string ToString() {
		return "Health Potion";
	}
}
