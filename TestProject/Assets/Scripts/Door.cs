using UnityEngine;
using System.Collections;

public class Door : MonoBehaviour {

    [SerializeField]
    private Sprite doorClosed;
    [SerializeField]
    private Sprite doorOpen;

    [SerializeField]
    private AudioClip sfxDoorOpen;
    [SerializeField]
    private AudioClip sfxDoorClose;
    [SerializeField]
    private AudioClip sfxDoorHit;

    private SpriteRenderer mySpriteRenderer;
    private BoxCollider2D myBoxCollider2D;
    private AudioSource myAudioSource;


    void Awake()
    {
        mySpriteRenderer = GetComponent<SpriteRenderer>();
        myBoxCollider2D = GetComponent<BoxCollider2D>();
        myAudioSource = GetComponent<AudioSource>();
    }

    // Use this for initialization
    void Start () {
        mySpriteRenderer.sprite = doorClosed;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerStay2D (Collider2D other)
    {
        if (other.tag == "Player")
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                UseDoor();
            }
        }
    }

    private void UseDoor()
    {
        if (mySpriteRenderer.sprite == doorClosed)
        {
            mySpriteRenderer.sprite = doorOpen;
            myBoxCollider2D.enabled = false;
            myAudioSource.PlayOneShot(sfxDoorOpen);
        }
        else
        {
            mySpriteRenderer.sprite = doorClosed;
            myBoxCollider2D.enabled = true;
            myAudioSource.PlayOneShot(sfxDoorClose);
        }
    }

}
