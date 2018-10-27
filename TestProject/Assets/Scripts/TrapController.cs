using UnityEngine;
using System.Collections;

public class TrapController : MonoBehaviour {

    [SerializeField]
    private BoxCollider2D trapHolder;



    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player" || other.tag == "Enemy" || other.tag == "ObjectCollidable")
        {
            trapHolder.enabled = false;
        }

    }

    //private void OnCollisionEnter2D(Collision2D other)
    //{
    //    if (other.gameObject.tag == "Player" || other.gameObject.tag == "Enemy")
    //    {
    //        trapHolder.enabled = false;
    //    }

    //}
}
