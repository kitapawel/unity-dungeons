using UnityEngine;
using System.Collections;

public class TrapMultiSwitch : MonoBehaviour
{

    [SerializeField]
    private GameObject trapTrigger1;
    [SerializeField]
    private GameObject trapTrigger2;
    [SerializeField]
    private AudioClip sfxBrick;

    private SpriteRenderer mySpriteRenderer;
    private AudioSource myAudioSource;

    // Use this for initialization
    void Start()
    {
        mySpriteRenderer = GetComponent<SpriteRenderer>();
        myAudioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {

    }


    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                DisableTrap();
            }

        }
    }

    private void DisableTrap()
    {
        if (trapTrigger1.GetComponent<CircleCollider2D>().enabled == true)
        {
            trapTrigger1.GetComponent<CircleCollider2D>().enabled = false;
            trapTrigger2.GetComponent<CircleCollider2D>().enabled = false;
            mySpriteRenderer.color = new Color(0.45f, 0.45f, 0.45f);
            myAudioSource.PlayOneShot(sfxBrick);
        } else if(trapTrigger1.GetComponent<CircleCollider2D>().enabled == false)
        {
            trapTrigger1.GetComponent<CircleCollider2D>().enabled = true;
            trapTrigger2.GetComponent<CircleCollider2D>().enabled = true;
            mySpriteRenderer.color = new Color(1f, 1f, 1f);
            myAudioSource.PlayOneShot(sfxBrick);
        }
              
    }
}