using UnityEngine;
using System.Collections;

public class RustleSound : MonoBehaviour
{
    [SerializeField]
    private AudioClip[] sfxRustle;

    private AudioSource myAudioSource;

    void Start()
    {
        myAudioSource = GetComponent<AudioSource>();
    }


    void OnCollisionEnter2D (Collision2D coll)
    {
        if (myAudioSource.isPlaying == false)
        {
            myAudioSource.PlayOneShot(sfxRustle[Random.Range(0, sfxRustle.Length)]);
        }
    }
 

}
