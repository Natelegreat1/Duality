using UnityEngine;
using System.Collections;

[RequireComponent (typeof (Rigidbody))]
public class GravityBody : MonoBehaviour {
	
	public GravityAttractor[] attractors;
	private GravityAttractor curAttractor;
	public int grounded;

	void Start () {
    	rigidbody.WakeUp();
    	rigidbody.useGravity = false;
	}

	void OnCollisionEnter (Collision c) {
		gameObject.GetComponent<PlayerControl>().isJumping = false;
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
    	if (curAttractor){
        	curAttractor.Attract(this);
    	}
	}
	
	void SetClosestAttractor () {
		if (attractors == null || attractors.Length < 1) {
			return;
		}
		GravityAttractor closestAttractor = attractors[0];
		for (int i = 1; i < attractors.Length; i++) {
			Vector3 curPosition = gameObject.transform.position;
			float curDistance = Vector3.Distance(curPosition, closestAttractor.transform.position);
			float tempDistance = Vector3.Distance(curPosition, attractors[i].transform.position);
			if (tempDistance < curDistance) {
				closestAttractor = attractors[i];
			}
		}
		curAttractor = closestAttractor;
	}
	
	void Update () {
		SetClosestAttractor();
	}
}
