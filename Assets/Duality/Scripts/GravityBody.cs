using UnityEngine;
using System.Collections;

[RequireComponent (typeof (Rigidbody))]
public class GravityBody : MonoBehaviour {
	
	public GravityAttractor attractor;
	public int grounded;

	void Start () {
    	rigidbody.WakeUp();
    	rigidbody.useGravity = false;
	}

	// obviously this is crude since we might want to be able to stand on (and jump off) random objects
	// should probably filter based on tag in future
	void OnCollisionEnter (Collision c) {
    	if (c.gameObject.tag == "Terrain"){
        	grounded++;
    	}
	}

	void OnCollisionExit (Collision c) {
    	if (c.gameObject.tag == "Terrain" && grounded > 0){
        	grounded--;
    	}
	}

	void FixedUpdate () {
    	if (attractor){
        	attractor.Attract(this);
    	}
	}
}
