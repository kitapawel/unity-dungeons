using UnityEngine;
using System.Collections;

public class coin : MonoBehaviour {

    [SerializeField]
    private AudioClip coinSound;

    private AudioSource myAudioSource;

	// Use this for initialization
	void Start () {
        myAudioSource = GetComponent<AudioSource>();
        myAudioSource.PlayOneShot(coinSound);
    }

    // Update is called once per frame
    void OnCollisionEnter2D(Collision2D coll)
    {
        if (myAudioSource.isPlaying == false)
        {
            myAudioSource.PlayOneShot(coinSound);
        }
    }
}
