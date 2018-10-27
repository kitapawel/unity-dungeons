using UnityEngine;
using System.Collections;

public class TrapFloor : MonoBehaviour {

    private Rigidbody2D myRigidbody2D;

	// Use this for initialization
	void Start () {
        myRigidbody2D = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player" || other.tag == "Enemy")
        myRigidbody2D.isKinematic = false;
    }
}
