using UnityEngine;
using System.Collections;

public class CheckVelocity : MonoBehaviour {

    private Rigidbody2D myRigidbody2D;
    private Vector2 myVelocity;
    private HingeJoint2D myHingeJoint2D;
    private BoxCollider2D myBoxCollider2D;

    // Use this for initialization
    void Start () {
        myRigidbody2D = GetComponent<Rigidbody2D>();
        myHingeJoint2D = GetComponent<HingeJoint2D>();
        myBoxCollider2D = GetComponent<BoxCollider2D>();
    }
	
	// Update is called once per frame
	void FixedUpdate () {
        myVelocity = myRigidbody2D.velocity;
        Debug.Log(myVelocity);

	}
}
