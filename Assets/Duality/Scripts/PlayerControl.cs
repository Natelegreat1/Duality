using UnityEngine;
using System.Collections;
 
[RequireComponent (typeof (Rigidbody))]
[RequireComponent (typeof (CapsuleCollider))]
 
public class PlayerControl : MonoBehaviour {
 
	public float speed = 10.0f;
	public float maxSpeed = 10.0f;
	public float jumpForce = 50.0f;
	private GravityBody gravBody;
	public bool isJumping;
 
	void Awake () {
	    rigidbody.freezeRotation = true;
	    rigidbody.useGravity = false;
		gravBody = gameObject.GetComponent<GravityBody>() as GravityBody;
	}
 
	void FixedUpdate () {
	        // Calculate movement
	        Vector3 targetVelocity = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
	        targetVelocity = transform.TransformDirection(targetVelocity);
	        targetVelocity *= speed;
			if (rigidbody.velocity.x < maxSpeed && rigidbody.velocity.y < maxSpeed && rigidbody.velocity.z < maxSpeed && !isJumping) {
				rigidbody.AddForce(targetVelocity);
			}
			// Handle jumping
			if (gravBody.grounded > 0 && Input.GetButton("Jump")) {
				rigidbody.AddRelativeForce(0,jumpForce,0);
				isJumping = true;
			}
	}
}