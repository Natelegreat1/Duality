using UnityEngine;
using System.Collections;

public class SwitchWorld : MonoBehaviour {
	
	private bool inAntiMatter = false;
	private GravityBody gravBody;
	
	// Use this for initialization
	void Start () {
		gravBody = gameObject.GetComponent<GravityBody>() as GravityBody;
	}
	
	void switchTerrainMaterial () {
		for (int i = 0; i < gravBody.attractors.Length; i++) {
			if (inAntiMatter == false) {
				gravBody.attractors[i].gameObject.renderer.material.color = Color.red;
				inAntiMatter = true;
			} else {
				gravBody.attractors[i].gameObject.renderer.material.color = Color.green;
				inAntiMatter = false;
			}
			
		}
	} 
	
	void Update () {
		// Switching of worlds
		if (Input.GetKeyDown(KeyCode.E)) {
			foreach (GravityAttractor ga in gravBody.attractors) {
				if (inAntiMatter == false) {
					ga.renderer.material.color = Color.red;
				} else {
					ga.renderer.material.color = Color.green;
				}
			}
			inAntiMatter = !inAntiMatter;	
		}
	}
}
