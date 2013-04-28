using UnityEngine;
using System.Collections;
 
[RequireComponent (typeof (Rigidbody))]
[RequireComponent (typeof (CapsuleCollider))]
 
public class PlayerControl : MonoBehaviour {
 
	public float speed = 10.0f;
	public float maxSpeed = 10.0f;
 
	void Awake () {
	    rigidbody.freezeRotation = true;
	    rigidbody.useGravity = false;
	}
 
	void FixedUpdate () {
	        // Calculate movement
	        Vector3 targetVelocity = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
	        targetVelocity = transform.TransformDirection(targetVelocity);
	        targetVelocity *= speed;
			if (rigidbody.velocity.x < maxSpeed && rigidbody.velocity.y < maxSpeed && rigidbody.velocity.z < maxSpeed) {
				rigidbody.AddForce(targetVelocity);
			}
	}
}