using UnityEngine;
using System.Collections;

public class Chest : MonoBehaviour {

    [SerializeField]
    private Sprite chestOpen;
    [SerializeField]
    private Sprite chestClosed;
    [SerializeField]
    private GameObject chestBroken;

    [SerializeField]
    private AudioClip sfxChestOpen;
    [SerializeField]
    private AudioClip sfxChestClose;
    [SerializeField]
    private AudioClip sfxChestHit;

    private SpriteRenderer mySpriteRenderer;
    private BoxCollider2D myBoxCollider2D;
    private Rigidbody2D myRigidbody2D;
    private AudioSource myAudioSource;

    private bool chestLooted = false;
    private LootDrop lootDrop;


    // Use this for initialization
    void Start () {
        mySpriteRenderer = GetComponent<SpriteRenderer>();
        myBoxCollider2D = GetComponent<BoxCollider2D>();
        myRigidbody2D = GetComponent<Rigidbody2D>();
        myAudioSource = GetComponent<AudioSource>();
        lootDrop = GetComponent<LootDrop>();

    }
	
	// Update is called once per frame
	void Update () {
	
	}

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                UseChest();
            }
        } else if (other.tag == "AttackCollider")
        {

            if (myAudioSource.isPlaying == false)
                myAudioSource.PlayOneShot(sfxChestHit);
            myRigidbody2D.isKinematic = true;
            myBoxCollider2D.enabled = false;
            mySpriteRenderer.enabled = false;
            chestBroken.SetActive(true);
            
        }
    }

    private void UseChest()
    {
        if (mySpriteRenderer.sprite == chestClosed)
        {
            mySpriteRenderer.sprite = chestOpen;
            if (mySpriteRenderer.enabled == true)
            myAudioSource.PlayOneShot(sfxChestOpen);
            if (chestLooted == false)
            {
                lootDrop.StartCoroutine("DropCoins");
                chestLooted = true;
            }
            

        } else
        {
            mySpriteRenderer.sprite = chestClosed;
            if (mySpriteRenderer.enabled == true)
                {
                    myAudioSource.Stop();
                    myAudioSource.PlayOneShot(sfxChestClose);
                }
        }
       
    }

}
