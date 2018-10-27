using UnityEngine;
using System.Collections;

public class TrapSwitch : MonoBehaviour
{

    [SerializeField]
    private GameObject trapTrigger;
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
        if (trapTrigger.GetComponent<CircleCollider2D>().enabled == true)
        {
            trapTrigger.GetComponent<CircleCollider2D>().enabled = false;
            trapTrigger.GetComponent<SpriteRenderer>().color = new Color (0.45f, 0.45f, 0.45f);
            mySpriteRenderer.color = new Color(0.45f, 0.45f, 0.45f);
            myAudioSource.PlayOneShot(sfxBrick);
        } else if(trapTrigger.GetComponent<CircleCollider2D>().enabled == false)
        {
            trapTrigger.GetComponent<CircleCollider2D>().enabled = true;
            trapTrigger.GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f);
            mySpriteRenderer.color = new Color(1f, 1f, 1f);
            myAudioSource.PlayOneShot(sfxBrick);
        }
              
    }
}