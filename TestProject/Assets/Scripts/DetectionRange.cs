using UnityEngine;
using System.Collections;

public class DetectionRange : MonoBehaviour {
        
    private NPCControllerArab parentObject;

    //get reference to parentObject
    void Start () {
        parentObject = GetComponentInParent<NPCControllerArab>();
       
	}
	
	
	void Update () {
	
	}

    //If Player body collider (not area marker!) enters detection range AI behaviors are initialized
    void OnTriggerStay2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            parentObject.SeesPlayer = true;
            parentObject.TargetEnemy = other.gameObject;

        } 
        
        if (other.tag == "Corpse")
        {
            parentObject.SeesPlayer = false;
        }


    }

}
