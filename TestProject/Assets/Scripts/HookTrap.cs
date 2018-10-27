using UnityEngine;
using System.Collections;

public class HookTrap : MonoBehaviour {
        
    private BoxCollider2D myBoxCollider2D;
    private Rigidbody2D myRigidbody2D;

    // Use this for initialization
    void Start () {
        myBoxCollider2D = GetComponent<BoxCollider2D>();
        myRigidbody2D = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
        
        if (myRigidbody2D.velocity.x > 4f)
        {
            this.tag = "AttackCollider";
            myBoxCollider2D.enabled = true;
        }   else
        {
            this.tag = "Untagged";
        }

	}


}
