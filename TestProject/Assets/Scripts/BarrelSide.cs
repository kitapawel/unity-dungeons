using UnityEngine;
using System.Collections;

public class BarrelSide : MonoBehaviour {

    [SerializeField]
    private GameObject barrelBroken;

    [SerializeField]
    private AudioClip sfxBarrelHit;

    private SpriteRenderer mySpriteRenderer;
    private CircleCollider2D myCircleCollider2D;
    private Rigidbody2D myRigidbody;
    private AudioSource myAudioSource;

    private float myVelocity = 0;



    // Use this for initialization
    void Start()
    {
        mySpriteRenderer = GetComponent<SpriteRenderer>();
        myCircleCollider2D = GetComponent<CircleCollider2D>();
        myRigidbody = GetComponent<Rigidbody2D>();
        myAudioSource = GetComponent<AudioSource>();

    }

    void FixedUpdate()
    {
       myVelocity = myRigidbody.velocity.y;
       MyVelocityCheck();



    }

    private void MyVelocityCheck()
    {
        if (myVelocity < -7f)
        {
            gameObject.layer = 14;
        }
        else
        {
            gameObject.layer = 11;
        }
    }

    void OnCollisionEnter2D(Collision2D coll)
    {
      
        if (coll.gameObject.tag == "AttackCollider")
        {
            
            if (myAudioSource.isPlaying == false)
                myAudioSource.PlayOneShot(sfxBarrelHit);
            myRigidbody.isKinematic = true;
            myCircleCollider2D.enabled = false;
            mySpriteRenderer.enabled = false;
            barrelBroken.SetActive(true);
        } else if (myVelocity != 0)
        {
            myAudioSource.PlayOneShot(sfxBarrelHit);
        }
    }
}
