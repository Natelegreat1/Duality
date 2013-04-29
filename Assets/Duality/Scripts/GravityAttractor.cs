using UnityEngine;
using System.Collections;

public class GravityAttractor : MonoBehaviour {

	// Set to true for mono-directional gravity
	bool useLocalUpVector = false;
	// Force applied along gravity up-vector (negative = down)
	public float gravity = -10.0f;
	
	public void Attract (GravityBody body) {
    	Vector3 gravityUp;
    	Vector3 localUp;
    	Vector3 localForward;

    	Transform t = body.transform;
    	Rigidbody r = body.rigidbody;

    	// Figure out the body's up vector
    	if (useLocalUpVector){
        	gravityUp = transform.up;   
    	} else {
        	gravityUp = t.position - transform.position;
        	gravityUp.Normalize();
    	}

    	// Accelerate the body along its up vector
    	r.AddForce(gravityUp * gravity * r.mass);
    	if (body.grounded == 1) {
			r.drag = 0.8f;
		}

    	// Force object upright
    	if (r.freezeRotation) {
        	// Orient relative to gravity
        	localUp = t.up;
       		Quaternion q = Quaternion.FromToRotation(localUp, gravityUp);
        	q = q * t.rotation;
        	t.rotation = Quaternion.Slerp(t.rotation, q, 0.1f);
        	localForward = t.forward;
    	}

	}
}
